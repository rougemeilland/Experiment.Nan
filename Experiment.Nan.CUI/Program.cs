using System;
using System.Buffers.Binary;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.X86;
using System.Text;

namespace Experiment.Nan.CUI
{
    internal static class Program
    {
        private const ulong _MANTISSA_SIGNALING_MASK = 1ul << 51;
        private const ulong _MANTISSA_MAX = (1ul << 52) - 1;
        private const ulong _MANTISSA_MASK = (1ul << 52) - 1;
        private const ushort _EXP_DENORMALIZED = 0;
        private const ushort _EXP_BIAS = (1 << 10) - 1;
        private const ushort _EXP_SPECIAL = (1 << 11) - 1;
        private const ushort _EXP_MAX = (1 << 11) - 1;
        private const ushort _EXP_MASK = (1 << 11) - 1;
        private const ushort _EXP_BIT_OFFSET = 52;
        private const ushort _SIGN_BIT_OFFSET = 63;

        private static void Main()
        {
            Console.WriteLine(new string('-', 20));
            Console.WriteLine(FormatExpression(FormatAsBitArray(double.MaxValue)));
            Console.WriteLine(FormatExpression(FormatAsBitArray(double.MinValue)));
            Console.WriteLine(FormatExpression(FormatAsBitArray(double.Epsilon)));
            Console.WriteLine(new string('-', 20));
            Console.WriteLine(FormatExpression(DisassembleDouble(15.0)));
            Console.WriteLine(FormatExpression(AssembleDouble(false, 1 + _EXP_BIAS, 0)));
            Console.WriteLine(FormatExpression(AssembleDouble(false, _EXP_DENORMALIZED, (1ul << 52) - 1)));
            Console.WriteLine(FormatExpression(FormatAsBitArray(AssembleDouble(false, _EXP_DENORMALIZED, (1ul << 52) - 1))));
            Console.WriteLine(FormatExpression(double.IsNormal(AssembleDouble(false, _EXP_DENORMALIZED, (1ul << 52) - 1))));
            Console.WriteLine(new string('-', 20));
            Console.WriteLine(FormatExpression(FormatAsBitArray(double.NaN)));
            Console.WriteLine(FormatExpression(double.IsNaN(double.NaN)));
            Console.WriteLine(FormatExpression(FormatAsBitArray(MakeQuietNan(1))));
            Console.WriteLine(FormatExpression(double.IsNaN(MakeQuietNan(1))));
            Console.WriteLine(FormatExpression(FormatAsBitArray(MakeQuietNan(2))));
            Console.WriteLine(FormatExpression(double.IsNaN(MakeQuietNan(2))));
            Console.WriteLine(FormatExpression(FormatAsBitArray(MakeSignalingNan(1))));
            Console.WriteLine(FormatExpression(double.IsNaN(MakeSignalingNan(1))));
            Console.WriteLine(FormatExpression(FormatAsBitArray(MakeSignalingNan(2))));
            Console.WriteLine(FormatExpression(double.IsNaN(MakeSignalingNan(2))));
            Console.WriteLine(new string('-', 20));
            Console.WriteLine(FormatExpression(FormatAsBitArray(double.NaN + 10)));
            Console.WriteLine(new string('-', 20));
            Console.WriteLine(FormatExpression(OperatorEqual(double.NaN, double.NaN)));
            Console.WriteLine(FormatExpression(OperatorNotEqual(double.NaN, double.NaN)));
            Console.WriteLine(new string('-', 20));
            Console.WriteLine(FormatExpression(double.NaN.Equals(double.NaN)));
            Console.WriteLine(FormatExpression(double.NaN.Equals((object)double.NaN)));
            Console.WriteLine(new string('-', 20));
            Console.WriteLine(FormatExpression(0.0d.CompareTo(-1.0d)));
            Console.WriteLine(FormatExpression(0.0d.CompareTo(0.0d)));
            Console.WriteLine(FormatExpression(0.0d.CompareTo(1.0d)));
            Console.WriteLine(FormatExpression(0.0d.CompareTo(double.NaN)));
            Console.WriteLine(FormatExpression(double.NaN.CompareTo(-1.0d)));
            Console.WriteLine(FormatExpression(double.NaN.CompareTo(0.0d)));
            Console.WriteLine(FormatExpression(double.NaN.CompareTo(1.0d)));
            Console.WriteLine(FormatExpression(double.NaN.CompareTo(double.NaN)));
            Console.WriteLine(new string('-', 20));
            Console.WriteLine(FormatExpression(Comparer<double>.Default.Compare(0.0d, -1.0d)));
            Console.WriteLine(FormatExpression(Comparer<double>.Default.Compare(0.0d, 0.0d)));
            Console.WriteLine(FormatExpression(Comparer<double>.Default.Compare(0.0d, 1.0d)));
            Console.WriteLine(FormatExpression(Comparer<double>.Default.Compare(0.0d, double.NaN)));
            Console.WriteLine(FormatExpression(Comparer<double>.Default.Compare(double.NaN, -1.0d)));
            Console.WriteLine(FormatExpression(Comparer<double>.Default.Compare(double.NaN, 0.0d)));
            Console.WriteLine(FormatExpression(Comparer<double>.Default.Compare(double.NaN, 1.0d)));
            Console.WriteLine(FormatExpression(Comparer<double>.Default.Compare(double.NaN, double.NaN)));
            Console.WriteLine(new string('-', 20));
            Console.WriteLine(FormatExpression(Comparer<double?>.Default.Compare(0.0d, -1.0d)));
            Console.WriteLine(FormatExpression(Comparer<double?>.Default.Compare(0.0d, 0.0d)));
            Console.WriteLine(FormatExpression(Comparer<double?>.Default.Compare(0.0d, 1.0d)));
            Console.WriteLine(FormatExpression(Comparer<double?>.Default.Compare(0.0d, double.NaN)));
            Console.WriteLine(FormatExpression(Comparer<double?>.Default.Compare(0.0d, null)));
            Console.WriteLine(FormatExpression(Comparer<double?>.Default.Compare(double.NaN, -1.0d)));
            Console.WriteLine(FormatExpression(Comparer<double?>.Default.Compare(double.NaN, 0.0d)));
            Console.WriteLine(FormatExpression(Comparer<double?>.Default.Compare(double.NaN, 1.0d)));
            Console.WriteLine(FormatExpression(Comparer<double?>.Default.Compare(double.NaN, double.NaN)));
            Console.WriteLine(FormatExpression(Comparer<double?>.Default.Compare(double.NaN, null)));
            Console.WriteLine(FormatExpression(Comparer<double?>.Default.Compare(null, -1.0d)));
            Console.WriteLine(FormatExpression(Comparer<double?>.Default.Compare(null, 0.0d)));
            Console.WriteLine(FormatExpression(Comparer<double?>.Default.Compare(null, 1.0d)));
            Console.WriteLine(FormatExpression(Comparer<double?>.Default.Compare(null, double.NaN)));
            Console.WriteLine(FormatExpression(Comparer<double?>.Default.Compare(null, null)));
            Console.WriteLine(new string('-', 20));
            Console.WriteLine(FormatExpression(double.Max(double.MinValue, double.NaN)));
            Console.WriteLine(FormatExpression(double.Max(double.MaxValue, double.NaN)));
            Console.WriteLine(FormatExpression(double.Max(double.NaN, double.MinValue)));
            Console.WriteLine(FormatExpression(double.Max(double.NaN, double.MaxValue)));
            Console.WriteLine(FormatExpression(double.Min(double.MinValue, double.NaN)));
            Console.WriteLine(FormatExpression(double.Min(double.MaxValue, double.NaN)));
            Console.WriteLine(FormatExpression(double.Min(double.NaN, double.MinValue)));
            Console.WriteLine(FormatExpression(double.Min(double.NaN, double.MaxValue)));
            Console.WriteLine(new string('-', 20));
            Console.WriteLine(FormatExpression(double.MaxNumber(double.MinValue, double.NaN)));
            Console.WriteLine(FormatExpression(double.MaxNumber(double.MaxValue, double.NaN)));
            Console.WriteLine(FormatExpression(double.MaxNumber(double.NaN, double.MinValue)));
            Console.WriteLine(FormatExpression(double.MaxNumber(double.NaN, double.MaxValue)));
            Console.WriteLine(FormatExpression(double.MinNumber(double.MinValue, double.NaN)));
            Console.WriteLine(FormatExpression(double.MinNumber(double.MaxValue, double.NaN)));
            Console.WriteLine(FormatExpression(double.MinNumber(double.NaN, double.MinValue)));
            Console.WriteLine(FormatExpression(double.MinNumber(double.NaN, double.MaxValue)));
            Console.WriteLine(new string('-', 20));

            Console.WriteLine(new string('-', 20));
            Console.WriteLine(FormatExpression(Vector.IsHardwareAccelerated));
            Console.WriteLine(FormatExpression(Vector<double>.IsSupported));
            Span<double> first = stackalloc double[Vector<double>.Count];
            Span<double> second = stackalloc double[Vector<double>.Count];
            first.Fill(2.0d);
            second[..^1].Fill(1.0d);
            second[^1] = double.NaN;
            var firstVector = Vector.LoadUnsafe(ref first[0]);
            var secondVector = Vector.LoadUnsafe(ref second[0]);
            Console.WriteLine(FormatExpression(firstVector));
            Console.WriteLine(FormatExpression(secondVector));
            Console.WriteLine(new string('-', 20));
            Console.WriteLine(FormatExpression(firstVector.Equals(secondVector)));
            Console.WriteLine(FormatExpression(firstVector == secondVector));
            Console.WriteLine(FormatExpression(firstVector != secondVector));
            Console.WriteLine(new string('-', 20));
            Console.WriteLine(FormatExpression(Vector.Equals(firstVector, secondVector)));
            Console.WriteLine(FormatExpression(Vector.EqualsAll(firstVector, secondVector)));
            Console.WriteLine(FormatExpression(Vector.EqualsAny(firstVector, secondVector)));
            Console.WriteLine(new string('-', 20));
            Console.WriteLine(FormatExpression(Vector.GreaterThan(firstVector, secondVector)));
            Console.WriteLine(FormatExpression(Vector.GreaterThanOrEqual(firstVector, secondVector)));
            Console.WriteLine(new string('-', 20));
            Console.WriteLine(FormatExpression(Vector.GreaterThanAll(firstVector, secondVector)));
            Console.WriteLine(FormatExpression(Vector.GreaterThanOrEqualAll(firstVector, secondVector)));
            Console.WriteLine(new string('-', 20));
            Console.WriteLine(FormatExpression(Vector.GreaterThanAny(firstVector, secondVector)));
            Console.WriteLine(FormatExpression(Vector.GreaterThanOrEqualAny(firstVector, secondVector)));
            Console.WriteLine(new string('-', 20));
            Console.WriteLine(FormatExpression(Vector.Max(firstVector, secondVector)));
            Console.WriteLine(FormatExpression(Vector.Min(firstVector, secondVector)));
            Console.WriteLine(new string('-', 20));
#if NET9_0_OR_GREATER
            Console.WriteLine(FormatExpression(Vector.MaxNative(firstVector, secondVector)));
            Console.WriteLine(FormatExpression(Vector.MinNative(firstVector, secondVector)));
            Console.WriteLine(new string('-', 20));
            Console.WriteLine(FormatExpression(Vector.MaxNumber(firstVector, secondVector)));
            Console.WriteLine(FormatExpression(Vector.MinNumber(firstVector, secondVector)));
            Console.WriteLine(new string('-', 20));
#endif
            Console.WriteLine(FormatExpression(new[] { double.NaN, 1.0d, 0.0d }.Max()));
            Console.WriteLine(FormatExpression(new[] { double.NaN, 1.0d, 0.0d }.Min()));
            Console.WriteLine(new string('-', 20));
            Console.WriteLine(FormatExpression(Vector<float>.IsSupported));
            Console.WriteLine(FormatExpression(Vector<double>.IsSupported));
            Console.WriteLine(FormatExpression(Vector<NFloat>.IsSupported));
            Console.WriteLine(new string('-', 20));

            if (Vector256.IsHardwareAccelerated && Vector256<double>.IsSupported)
            {
                var v512 = Vector512.Create(1d, 2d, 3d, 4d, 5d, 6d, 7d, 8d);
                var v256 = v512.GetLower() + v512.GetUpper();
                var v128 = v256.GetLower() + v256.GetUpper();
                var v64 = v128.GetLower() + v128.GetUpper();
                Console.WriteLine(FormatExpression(v512));
                Console.WriteLine(FormatExpression(v256));
                Console.WriteLine(FormatExpression(v128));
                Console.WriteLine(FormatExpression(v64));
                Console.WriteLine(new string('-', 20));
            }

            if (Sse2.IsSupported && Vector128.IsHardwareAccelerated && Vector128<double>.IsSupported)
            {
                Console.WriteLine(FormatExpression(Sse2.AddScalar(Vector128.Create(1d, 4d), Vector128.Create(9d, 16d))));
                Console.WriteLine(new string('-', 20));
            }

#if false
runtime-main\runtime-main\src\libraries\System.Private.CoreLib\src\System\Runtime\Intrinsics\X86\Sse3.cs(50):         public static Vector128<float> HorizontalAdd(Vector128<float> left, Vector128<float> right) => HorizontalAdd(left, right);
runtime-main\runtime-main\src\libraries\System.Private.CoreLib\src\System\Runtime\Intrinsics\X86\Sse3.cs(56):         public static Vector128<double> HorizontalAdd(Vector128<double> left, Vector128<double> right) => HorizontalAdd(left, right);
runtime-main\runtime-main\src\libraries\System.Private.CoreLib\src\System\Runtime\Intrinsics\X86\Ssse3.cs(123):         public static Vector128<short> HorizontalAdd(Vector128<short> left, Vector128<short> right) => HorizontalAdd(left, right);
runtime-main\runtime-main\src\libraries\System.Private.CoreLib\src\System\Runtime\Intrinsics\X86\Ssse3.cs(129):         public static Vector128<int> HorizontalAdd(Vector128<int> left, Vector128<int> right) => HorizontalAdd(left, right);

runtime-main\runtime-main\src\libraries\System.Private.CoreLib\src\System\Runtime\Intrinsics\X86\Avx.cs(493):         public static Vector256<float> HorizontalAdd(Vector256<float> left, Vector256<float> right) => HorizontalAdd(left, right);
runtime-main\runtime-main\src\libraries\System.Private.CoreLib\src\System\Runtime\Intrinsics\X86\Avx.cs(498):         public static Vector256<double> HorizontalAdd(Vector256<double> left, Vector256<double> right) => HorizontalAdd(left, right);
runtime-main\runtime-main\src\libraries\System.Private.CoreLib\src\System\Runtime\Intrinsics\X86\Avx2.cs(1696):         public static Vector256<short> HorizontalAdd(Vector256<short> left, Vector256<short> right) => HorizontalAdd(left, right);
runtime-main\runtime-main\src\libraries\System.Private.CoreLib\src\System\Runtime\Intrinsics\X86\Avx2.cs(1701):         public static Vector256<int> HorizontalAdd(Vector256<int> left, Vector256<int> right) => HorizontalAdd(left, right);
#endif

            Console.Beep();
            Console.WriteLine("Complete");
            _ = Console.ReadLine();
        }

        private static string FormatExpression(object value, [CallerArgumentExpression(nameof(value))] string? expression = null) => $"{expression}={value}";

        private static bool OperatorEqual<VALUE_T>(VALUE_T first, VALUE_T second)
            where VALUE_T : IEqualityOperators<VALUE_T, VALUE_T, bool>
            => first == second;

        private static bool OperatorNotEqual<VALUE_T>(VALUE_T first, VALUE_T second)
            where VALUE_T : IEqualityOperators<VALUE_T, VALUE_T, bool>
            => first != second;

        private static bool IsQuietNan(double value)
        {
            var (_, exp, significand) = DisassembleDouble(value);
            return exp == _EXP_SPECIAL && significand != 0 && (significand & _MANTISSA_SIGNALING_MASK) == 0;
        }

        private static bool IsSignalingNan(double value)
        {
            var (_, exp, significand) = DisassembleDouble(value);
            return exp == _EXP_SPECIAL && significand != 0 && (significand & _MANTISSA_SIGNALING_MASK) != 0;
        }

        private static double MakeQuietNan(ulong payload)
        {
            ArgumentOutOfRangeException.ThrowIfGreaterThanOrEqual(payload, 1ul << 51);
            ArgumentOutOfRangeException.ThrowIfLessThan(payload, 1ul);

            return AssembleDouble(false, _EXP_SPECIAL, payload);
        }

        private static double MakeSignalingNan(ulong payload)
        {
            ArgumentOutOfRangeException.ThrowIfGreaterThanOrEqual(payload, 1ul << 51);

            return AssembleDouble(false, _EXP_SPECIAL, payload | _MANTISSA_SIGNALING_MASK);
        }

        private static string FormatAsBitArray(double value)
        {
            Span<byte> buffer = stackalloc byte[8];
            BinaryPrimitives.WriteDoubleLittleEndian(buffer, value);
            var valueAsUInt64 = BinaryPrimitives.ReadUInt64LittleEndian(buffer);
            var sb = new StringBuilder(66);
            var bitPos = 63;
            _ = sb.Append((valueAsUInt64 & (1ul << bitPos)) != 0 ? '1' : '0');
            --bitPos;
            _ = sb.Append('_');
            while (bitPos >= 52)
            {
                _ = sb.Append((valueAsUInt64 & (1ul << bitPos)) != 0 ? '1' : '0');
                --bitPos;
            }

            _ = sb.Append('_');
            while (bitPos >= 0)
            {
                _ = sb.Append((valueAsUInt64 & (1ul << bitPos)) != 0 ? '1' : '0');
                --bitPos;
            }

            return sb.ToString();
        }

        private static (bool isNegative, ushort exp, ulong significand) DisassembleDouble(double value)
        {
            Span<byte> buffer = stackalloc byte[8];
            BinaryPrimitives.WriteDoubleLittleEndian(buffer, value);
            var uint64Value = BinaryPrimitives.ReadUInt64LittleEndian(buffer);
            return ((uint64Value & (1ul << 63)) != 0, (ushort)((uint64Value >> 52) & ((1u << 11) - 1)), uint64Value & ((1ul << 52) - 1));
        }

        private static double AssembleDouble(bool isNegative, ushort exp, ulong significand)
        {
            ArgumentOutOfRangeException.ThrowIfGreaterThanOrEqual(exp, 1u << 12);
            ArgumentOutOfRangeException.ThrowIfGreaterThanOrEqual(significand, 1ul << 52);

            var uint64Value = ((ulong)exp << 52) | significand;
            if (isNegative)
                uint64Value |= 1ul << 63;
            Span<byte> buffer = stackalloc byte[8];
            BinaryPrimitives.WriteUInt64LittleEndian(buffer, uint64Value);
            return BinaryPrimitives.ReadDoubleLittleEndian(buffer);
        }
    }
}
