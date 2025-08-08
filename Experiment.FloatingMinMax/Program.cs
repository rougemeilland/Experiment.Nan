using System;
using System.Buffers.Binary;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.Arm;
using System.Runtime.Intrinsics.Wasm;
using System.Runtime.Intrinsics.X86;

namespace Experiment.FloatingMinMax
{
    internal sealed class Program
    {
        private const ulong _MANTISSA_SIGNALING_MASK = 1ul << 51;
        private const ulong _MANTISSA_MAX = (1ul << 52) - 1;
        private const ulong _MANTISSA_MASK = (1ul << 52) - 1;
        private const ushort _EXP_DENORMALIZED_OR_ZERO = 0;
        private const ushort _EXP_BIAS = (1 << 10) - 1;
        private const ushort _EXP_SPECIAL = (1 << 11) - 1;
        private const ushort _EXP_MAX = (1 << 11) - 1;
        private const ushort _EXP_MASK = (1 << 11) - 1;
        private const ushort _EXP_BIT_OFFSET = 52;
        private const ushort _SIGN_BIT_OFFSET = 63;

        private static readonly double _positiveInfiniry = AssembleDouble(false, _EXP_SPECIAL, 0);
        private static readonly double _positiveNormal = 123d;
        private static readonly double _positiveSubNormal = AssembleDouble(false, _EXP_DENORMALIZED_OR_ZERO, uint.MaxValue);
        private static readonly double _positiveZero = AssembleDouble(false, _EXP_DENORMALIZED_OR_ZERO, 0);
        private static readonly double _negativeZero = AssembleDouble(true, _EXP_DENORMALIZED_OR_ZERO, 0);
        private static readonly double _negativeSubNormal = AssembleDouble(true, _EXP_DENORMALIZED_OR_ZERO, uint.MaxValue);
        private static readonly double _negativeNormal = -123d;
        private static readonly double _negativeInfiniry = AssembleDouble(true, _EXP_SPECIAL, 0);
        private static readonly double _qNaN1 = AssembleDouble(false, _EXP_SPECIAL, 1);
        private static readonly double _qNaN2 = AssembleDouble(false, _EXP_SPECIAL, 2);
        private static readonly double _qNaN3 = AssembleDouble(true, _EXP_SPECIAL, 1);
        private static readonly double _qNaN4 = AssembleDouble(true, _EXP_SPECIAL, 2);
        private static readonly double _sNaN1 = AssembleDouble(false, _EXP_SPECIAL, 1 | _MANTISSA_SIGNALING_MASK);
        private static readonly double _sNaN2 = AssembleDouble(false, _EXP_SPECIAL, 2 | _MANTISSA_SIGNALING_MASK);
        private static readonly double _sNaN3 = AssembleDouble(true, _EXP_SPECIAL, 1 | _MANTISSA_SIGNALING_MASK);
        private static readonly double _sNaN4 = AssembleDouble(true, _EXP_SPECIAL, 2 | _MANTISSA_SIGNALING_MASK);

        private static void Main()
        {
            System.Diagnostics.Debug.Assert(EqualBinary(_positiveInfiniry, double.PositiveInfinity));
            System.Diagnostics.Debug.Assert(double.IsNormal(_positiveNormal) && _positiveNormal > 0);
            System.Diagnostics.Debug.Assert(double.IsSubnormal(_positiveSubNormal) && _positiveSubNormal > 0);
            System.Diagnostics.Debug.Assert(EqualBinary(_positiveZero, 0d));
            System.Diagnostics.Debug.Assert(EqualBinary(_negativeZero, double.NegativeZero));
            System.Diagnostics.Debug.Assert(double.IsSubnormal(_negativeSubNormal) && _negativeSubNormal < 0);
            System.Diagnostics.Debug.Assert(double.IsNormal(_negativeNormal) && _negativeNormal < 0);
            System.Diagnostics.Debug.Assert(EqualBinary(_negativeInfiniry, double.NegativeInfinity));
            System.Diagnostics.Debug.Assert(double.IsNaN(_qNaN1));
            System.Diagnostics.Debug.Assert(double.IsNaN(_qNaN2));
            System.Diagnostics.Debug.Assert(double.IsNaN(_qNaN3));
            System.Diagnostics.Debug.Assert(double.IsNaN(_qNaN4));
            System.Diagnostics.Debug.Assert(double.IsNaN(_sNaN1));
            System.Diagnostics.Debug.Assert(double.IsNaN(_sNaN2));
            System.Diagnostics.Debug.Assert(double.IsNaN(_sNaN3));
            System.Diagnostics.Debug.Assert(double.IsNaN(_sNaN4));

            Console.WriteLine("# Runtime environment");
            Console.WriteLine();
            Console.WriteLine("| Property | Value |");
            Console.WriteLine("|:---|:---:|");
            Console.WriteLine($"| OS | {RuntimeInformation.OSDescription} |");
            Console.WriteLine($"| Architecture | {RuntimeInformation.ProcessArchitecture} |");
            Console.WriteLine($"| .Net runtime | {RuntimeInformation.FrameworkDescription} |");
            Console.WriteLine(FormatExpressionForTable(AdvSimd.IsSupported));
            Console.WriteLine(FormatExpressionForTable(PackedSimd.IsSupported));
            Console.WriteLine(FormatExpressionForTable(Sse.IsSupported));
            Console.WriteLine(FormatExpressionForTable(Sse2.IsSupported));
            Console.WriteLine(FormatExpressionForTable(Sse3.IsSupported));
            Console.WriteLine(FormatExpressionForTable(Ssse3.IsSupported));
            Console.WriteLine(FormatExpressionForTable(Sse41.IsSupported));
            Console.WriteLine(FormatExpressionForTable(Sse42.IsSupported));
            Console.WriteLine(FormatExpressionForTable(Avx.IsSupported));
            Console.WriteLine(FormatExpressionForTable(Avx2.IsSupported));
            Console.WriteLine(FormatExpressionForTable(Avx512F.IsSupported));
            Console.WriteLine(FormatExpressionForTable(Avx512CD.IsSupported));
            Console.WriteLine(FormatExpressionForTable(Avx512DQ.IsSupported));
            Console.WriteLine(FormatExpressionForTable(Avx512BW.IsSupported));
            Console.WriteLine(FormatExpressionForTable(Avx512Vbmi.IsSupported));
#if NET9_0_OR_GREATER   
            Console.WriteLine(FormatExpressionForTable(Avx10v1.IsSupported));
#endif
            Console.WriteLine();
            MakeTable("double.Max(double, double)", double.Max);

            Console.WriteLine();
            MakeTable("double.Min(double, double)", double.Min);

            Console.WriteLine();
            MakeTable("double.MaxNumber(double, double)", double.MaxNumber);

            Console.WriteLine();
            MakeTable("double.MinNumber(double, double)", double.MinNumber);

            Console.WriteLine();
            MakeTable(
                "Vector.Max(Vector<double>, Vector<double>)",
                (left, right) => Vector.Max(new Vector<double>(left), new Vector<double>(right))[0]);

            Console.WriteLine();
            MakeTable(
                "Vector.Min(Vector<double>, Vector<double>)",
                (left, right) => Vector.Min(new Vector<double>(left), new Vector<double>(right))[0]);

#if NET9_0_OR_GREATER   
            Console.WriteLine();
            MakeTable(
                "Vector.MaxNumber(Vector<double>, Vector<double>)",
                (left, right) => Vector.MaxNumber(new Vector<double>(left), new Vector<double>(right))[0]);
#endif

#if NET9_0_OR_GREATER   
            Console.WriteLine();
            MakeTable(
                "Vector.MinNumber(Vector<double>, Vector<double>)",
                (left, right) => Vector.MinNumber(new Vector<double>(left), new Vector<double>(right))[0]);
#endif

            Console.WriteLine();
            Console.Beep();
            _ = Console.ReadLine();
        }

        private static void MakeTable(string title, Func<double, double, double> op)
        {
            var values =
                new[]
                {
                    _positiveInfiniry,
                    _positiveNormal,
                    _positiveSubNormal,
                    _positiveZero,
                    _negativeZero,
                    _negativeSubNormal,
                    _negativeNormal,
                    _negativeInfiniry,
                    _qNaN1,
                    _qNaN2,
                    _qNaN3,
                    _qNaN4,
                    _sNaN1,
                    _sNaN2,
                    _sNaN3,
                    _sNaN4
                };

            Console.WriteLine($"# {title}");
            Console.WriteLine();

            Console.WriteLine("<table>");
            Console.Write("<tr>");
            Console.Write("<th colspan=\"2\"/>");
            Console.Write($"<th colspan=\"{values.Length}\">right</th>");
            Console.WriteLine("</tr>");

            Console.Write("<tr>");
            Console.Write("<th colspan=\"2\"/>");
            foreach (var right in values)
                Console.Write($"<th>{ToSymbolString(right)}</th>");
            Console.WriteLine("</tr>");

            var isFirstRow = true;
            foreach (var left in values)
            {
                Console.Write("<tr>");
                if (isFirstRow)
                    Console.Write($"<th rowspan=\"{values.Length}\">left</th>");
                Console.Write($"<th>{ToSymbolString(left)}</th>");
                isFirstRow = false;
                foreach (var right in values)
                    Console.Write($"<td> {ToSymbolString(op(left, right))}</td>");
                Console.WriteLine("</tr>");
            }

            Console.WriteLine("</table>");
        }

        private static string FormatExpressionForTable(object value, [CallerArgumentExpression(nameof(value))] string? expression = null) => $"| {expression} | {value} |";

        private static (bool isNegative, ushort exp, ulong significand) DisassembleDouble(double value)
        {
            var uint64Value = BitConverter.DoubleToUInt64Bits(value);
            return ((uint64Value & (1ul << 63)) != 0, (ushort)((uint64Value >> 52) & ((1u << 11) - 1)), uint64Value & ((1ul << 52) - 1));
        }

        private static double AssembleDouble(bool isNegative, ushort exp, ulong significand)
        {
            ArgumentOutOfRangeException.ThrowIfGreaterThanOrEqual(exp, 1u << 12);
            ArgumentOutOfRangeException.ThrowIfGreaterThanOrEqual(significand, 1ul << 52);

            var uint64Value = ((ulong)exp << 52) | significand;
            if (isNegative)
                uint64Value |= 1ul << 63;
            return BitConverter.UInt64BitsToDouble(uint64Value);
        }

        private static bool EqualBinary(double left, double right) => BitConverter.DoubleToUInt64Bits(left) == BitConverter.DoubleToUInt64Bits(right);

        private static string ToSymbolString(double value)
        {
            if (EqualBinary(value, _positiveInfiniry))
                return "+∞";
            if (EqualBinary(value, _negativeInfiniry))
                return "-∞";
            if (EqualBinary(value, _positiveSubNormal))
                return $"{value.ToString("e2", CultureInfo.InvariantCulture)}";
            if (EqualBinary(value, _negativeSubNormal))
                return $"{value.ToString("e2", CultureInfo.InvariantCulture)}";
            if (EqualBinary(value, _positiveZero))
                return "+0";
            if (EqualBinary(value, _negativeZero))
                return "-0";
            if (EqualBinary(value, _qNaN1))
                return "qNaN(+1)";
            if (EqualBinary(value, _qNaN2))
                return "qNaN(+2)";
            if (EqualBinary(value, _qNaN3))
                return "qNaN(-1)";
            if (EqualBinary(value, _qNaN4))
                return "qNaN(-2)";
            if (EqualBinary(value, _sNaN1))
                return "sNaN(+1)";
            if (EqualBinary(value, _sNaN2))
                return "sNaN(+2)";
            if (EqualBinary(value, _sNaN3))
                return "sNaN(-1)";
            if (EqualBinary(value, _sNaN4))
                return "sNaN(-2)";
            if (double.IsNormal(value))
                return value.ToString("f2", CultureInfo.InvariantCulture);
            if (double.IsNaN(value))
                return "NaN";
            return "???";
        }
    }
}
