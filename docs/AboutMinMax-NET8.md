# 1. Overview

This article presents the results of an investigation into the actual behavior of the Max/Min/MaxNumber/MinNumber methods in .NET.

# 2. Runtime environment

| Property | Value |
|:---|:---:|
| OS | Microsoft Windows 10.0.19045 |
| Architecture | X64 |
| .Net runtime | .NET 8.0.19 |
| AdvSimd.IsSupported | False |
| PackedSimd.IsSupported | False |
| Sse.IsSupported | True |
| Sse2.IsSupported | True |
| Sse3.IsSupported | True |
| Ssse3.IsSupported | True |
| Sse41.IsSupported | True |
| Sse42.IsSupported | True |
| Avx.IsSupported | True |
| Avx2.IsSupported | True |
| Avx512F.IsSupported | False |
| Avx512CD.IsSupported | False |
| Avx512DQ.IsSupported | False |
| Avx512BW.IsSupported | False |
| Avx512Vbmi.IsSupported | False |
# 3. Explanatory notes

- "2.12e-314" is a positive subnormal number.
- "-2.12e-314" is a negative subnormal number.
- qNaN(+1) is a "quiet NaN" whose sign bit is positive and whose mantissa is 1.
- qNaN(+2) is a "quiet NaN" whose sign bit is positive and whose mantissa is 2.
- qNaN(-1) is a "quiet NaN" whose sign bit is negative and whose mantissa is 1.
- qNaN(-2) is a "quiet NaN" whose sign bit is negative and whose mantissa is 2.
- sNaN(+1) is a "signaling NaN" whose sign bit is positive and whose mantissa is 1.
- sNaN(+2) is a "signaling NaN" whose sign bit is positive and whose mantissa is 2.
- sNaN(-1) is a "signaling NaN" whose sign bit is negative and whose mantissa is 1.
- sNaN(-2) is a "signaling NaN" whose sign bit is negative and whose mantissa is 2.


# 4. For &quot;double.Max(double, double)&quot;

<table>
<tr><th colspan="2" rowspan="2"/><th colspan="16">right</th></tr>
<tr><th>+∞</th><th>123.00</th><th>2.12e-314</th><th>+0</th><th>-0</th><th>-2.12e-314</th><th>-123.00</th><th>-∞</th><th>qNaN(+1)</th><th>qNaN(+2)</th><th>qNaN(-1)</th><th>qNaN(-2)</th><th>sNaN(+1)</th><th>sNaN(+2)</th><th>sNaN(-1)</th><th>sNaN(-2)</th></tr>
<tr><th rowspan="16">left</th><th>+∞</th><td> +∞</td><td> +∞</td><td> +∞</td><td> +∞</td><td> +∞</td><td> +∞</td><td> +∞</td><td> +∞</td><td> qNaN(+1)</td><td> qNaN(+2)</td><td> qNaN(-1)</td><td> qNaN(-2)</td><td> sNaN(+1)</td><td> sNaN(+2)</td><td> sNaN(-1)</td><td> sNaN(-2)</td></tr>
<tr><th>123.00</th><td> +∞</td><td> 123.00</td><td> 123.00</td><td> 123.00</td><td> 123.00</td><td> 123.00</td><td> 123.00</td><td> 123.00</td><td> qNaN(+1)</td><td> qNaN(+2)</td><td> qNaN(-1)</td><td> qNaN(-2)</td><td> sNaN(+1)</td><td> sNaN(+2)</td><td> sNaN(-1)</td><td> sNaN(-2)</td></tr>
<tr><th>2.12e-314</th><td> +∞</td><td> 123.00</td><td> 2.12e-314</td><td> 2.12e-314</td><td> 2.12e-314</td><td> 2.12e-314</td><td> 2.12e-314</td><td> 2.12e-314</td><td> qNaN(+1)</td><td> qNaN(+2)</td><td> qNaN(-1)</td><td> qNaN(-2)</td><td> sNaN(+1)</td><td> sNaN(+2)</td><td> sNaN(-1)</td><td> sNaN(-2)</td></tr>
<tr><th>+0</th><td> +∞</td><td> 123.00</td><td> 2.12e-314</td><td> +0</td><td> +0</td><td> +0</td><td> +0</td><td> +0</td><td> qNaN(+1)</td><td> qNaN(+2)</td><td> qNaN(-1)</td><td> qNaN(-2)</td><td> sNaN(+1)</td><td> sNaN(+2)</td><td> sNaN(-1)</td><td> sNaN(-2)</td></tr>
<tr><th>-0</th><td> +∞</td><td> 123.00</td><td> 2.12e-314</td><td> +0</td><td> -0</td><td> -0</td><td> -0</td><td> -0</td><td> qNaN(+1)</td><td> qNaN(+2)</td><td> qNaN(-1)</td><td> qNaN(-2)</td><td> sNaN(+1)</td><td> sNaN(+2)</td><td> sNaN(-1)</td><td> sNaN(-2)</td></tr>
<tr><th>-2.12e-314</th><td> +∞</td><td> 123.00</td><td> 2.12e-314</td><td> +0</td><td> -0</td><td> -2.12e-314</td><td> -2.12e-314</td><td> -2.12e-314</td><td> qNaN(+1)</td><td> qNaN(+2)</td><td> qNaN(-1)</td><td> qNaN(-2)</td><td> sNaN(+1)</td><td> sNaN(+2)</td><td> sNaN(-1)</td><td> sNaN(-2)</td></tr>
<tr><th>-123.00</th><td> +∞</td><td> 123.00</td><td> 2.12e-314</td><td> +0</td><td> -0</td><td> -2.12e-314</td><td> -123.00</td><td> -123.00</td><td> qNaN(+1)</td><td> qNaN(+2)</td><td> qNaN(-1)</td><td> qNaN(-2)</td><td> sNaN(+1)</td><td>sNaN(+2)</td><td> sNaN(-1)</td><td> sNaN(-2)</td></tr>
<tr><th>-∞</th><td> +∞</td><td> 123.00</td><td> 2.12e-314</td><td> +0</td><td> -0</td><td> -2.12e-314</td><td> -123.00</td><td> -∞</td><td> qNaN(+1)</td><td> qNaN(+2)</td><td> qNaN(-1)</td><td> qNaN(-2)</td><td> sNaN(+1)</td><td> sNaN(+2)</td><td> sNaN(-1)</td><td> sNaN(-2)</td></tr>
<tr><th>qNaN(+1)</th><td> qNaN(+1)</td><td> qNaN(+1)</td><td> qNaN(+1)</td><td> qNaN(+1)</td><td> qNaN(+1)</td><td> qNaN(+1)</td><td> qNaN(+1)</td><td> qNaN(+1)</td><td> qNaN(+1)</td><td> qNaN(+1)</td><td> qNaN(+1)</td><td> qNaN(+1)</td><td> qNaN(+1)</td><td> qNaN(+1)</td><td> qNaN(+1)</td><td> qNaN(+1)</td></tr>
<tr><th>qNaN(+2)</th><td> qNaN(+2)</td><td> qNaN(+2)</td><td> qNaN(+2)</td><td> qNaN(+2)</td><td> qNaN(+2)</td><td> qNaN(+2)</td><td> qNaN(+2)</td><td> qNaN(+2)</td><td> qNaN(+2)</td><td> qNaN(+2)</td><td> qNaN(+2)</td><td> qNaN(+2)</td><td> qNaN(+2)</td><td> qNaN(+2)</td><td> qNaN(+2)</td><td> qNaN(+2)</td></tr>
<tr><th>qNaN(-1)</th><td> qNaN(-1)</td><td> qNaN(-1)</td><td> qNaN(-1)</td><td> qNaN(-1)</td><td> qNaN(-1)</td><td> qNaN(-1)</td><td> qNaN(-1)</td><td> qNaN(-1)</td><td> qNaN(-1)</td><td> qNaN(-1)</td><td> qNaN(-1)</td><td> qNaN(-1)</td><td> qNaN(-1)</td><td> qNaN(-1)</td><td> qNaN(-1)</td><td> qNaN(-1)</td></tr>
<tr><th>qNaN(-2)</th><td> qNaN(-2)</td><td> qNaN(-2)</td><td> qNaN(-2)</td><td> qNaN(-2)</td><td> qNaN(-2)</td><td> qNaN(-2)</td><td> qNaN(-2)</td><td> qNaN(-2)</td><td> qNaN(-2)</td><td> qNaN(-2)</td><td> qNaN(-2)</td><td> qNaN(-2)</td><td> qNaN(-2)</td><td> qNaN(-2)</td><td> qNaN(-2)</td><td> qNaN(-2)</td></tr>
<tr><th>sNaN(+1)</th><td> sNaN(+1)</td><td> sNaN(+1)</td><td> sNaN(+1)</td><td> sNaN(+1)</td><td> sNaN(+1)</td><td> sNaN(+1)</td><td> sNaN(+1)</td><td> sNaN(+1)</td><td> sNaN(+1)</td><td> sNaN(+1)</td><td> sNaN(+1)</td><td> sNaN(+1)</td><td> sNaN(+1)</td><td> sNaN(+1)</td><td> sNaN(+1)</td><td> sNaN(+1)</td></tr>
<tr><th>sNaN(+2)</th><td> sNaN(+2)</td><td> sNaN(+2)</td><td> sNaN(+2)</td><td> sNaN(+2)</td><td> sNaN(+2)</td><td> sNaN(+2)</td><td> sNaN(+2)</td><td> sNaN(+2)</td><td> sNaN(+2)</td><td> sNaN(+2)</td><td> sNaN(+2)</td><td> sNaN(+2)</td><td> sNaN(+2)</td><td> sNaN(+2)</td><td> sNaN(+2)</td><td> sNaN(+2)</td></tr>
<tr><th>sNaN(-1)</th><td> sNaN(-1)</td><td> sNaN(-1)</td><td> sNaN(-1)</td><td> sNaN(-1)</td><td> sNaN(-1)</td><td> sNaN(-1)</td><td> sNaN(-1)</td><td> sNaN(-1)</td><td> sNaN(-1)</td><td> sNaN(-1)</td><td> sNaN(-1)</td><td> sNaN(-1)</td><td> sNaN(-1)</td><td> sNaN(-1)</td><td> sNaN(-1)</td><td> sNaN(-1)</td></tr>
<tr><th>sNaN(-2)</th><td> sNaN(-2)</td><td> sNaN(-2)</td><td> sNaN(-2)</td><td> sNaN(-2)</td><td> sNaN(-2)</td><td> sNaN(-2)</td><td> sNaN(-2)</td><td> sNaN(-2)</td><td> sNaN(-2)</td><td> sNaN(-2)</td><td> sNaN(-2)</td><td> sNaN(-2)</td><td> sNaN(-2)</td><td> sNaN(-2)</td><td> sNaN(-2)</td><td> sNaN(-2)</td></tr>
</table>

# 5. For &quot;double.Min(double, double)&quot;

<table>
<tr><th colspan="2" rowspan="2"/><th colspan="16">right</th></tr>
<tr><th>+∞</th><th>123.00</th><th>2.12e-314</th><th>+0</th><th>-0</th><th>-2.12e-314</th><th>-123.00</th><th>-∞</th><th>qNaN(+1)</th><th>qNaN(+2)</th><th>qNaN(-1)</th><th>qNaN(-2)</th><th>sNaN(+1)</th><th>sNaN(+2)</th><th>sNaN(-1)</th><th>sNaN(-2)</th></tr>
<tr><th rowspan="16">left</th><th>+∞</th><td> +∞</td><td> 123.00</td><td> 2.12e-314</td><td> +0</td><td> -0</td><td> -2.12e-314</td><td> -123.00</td><td> -∞</td><td> qNaN(+1)</td><td> qNaN(+2)</td><td> qNaN(-1)</td><td> qNaN(-2)</td><td> sNaN(+1)</td><td> sNaN(+2)</td><td> sNaN(-1)</td><td> sNaN(-2)</td></tr>
<tr><th>123.00</th><td> 123.00</td><td> 123.00</td><td> 2.12e-314</td><td> +0</td><td> -0</td><td> -2.12e-314</td><td> -123.00</td><td> -∞</td><td> qNaN(+1)</td><td> qNaN(+2)</td><td> qNaN(-1)</td><td> qNaN(-2)</td><td> sNaN(+1)</td><td> sNaN(+2)</td><td> sNaN(-1)</td><td> sNaN(-2)</td></tr>
<tr><th>2.12e-314</th><td> 2.12e-314</td><td> 2.12e-314</td><td> 2.12e-314</td><td> +0</td><td> -0</td><td> -2.12e-314</td><td> -123.00</td><td> -∞</td><td> qNaN(+1)</td><td> qNaN(+2)</td><td> qNaN(-1)</td><td> qNaN(-2)</td><td> sNaN(+1)</td><td> sNaN(+2)</td><td> sNaN(-1)</td><td> sNaN(-2)</td></tr>
<tr><th>+0</th><td> +0</td><td> +0</td><td> +0</td><td> +0</td><td> -0</td><td> -2.12e-314</td><td> -123.00</td><td> -∞</td><td> qNaN(+1)</td><td> qNaN(+2)</td><td> qNaN(-1)</td><td> qNaN(-2)</td><td> sNaN(+1)</td><td> sNaN(+2)</td><td> sNaN(-1)</td><td> sNaN(-2)</td></tr>
<tr><th>-0</th><td> -0</td><td> -0</td><td> -0</td><td> -0</td><td> -0</td><td> -2.12e-314</td><td> -123.00</td><td> -∞</td><td> qNaN(+1)</td><td> qNaN(+2)</td><td> qNaN(-1)</td><td> qNaN(-2)</td><td> sNaN(+1)</td><td> sNaN(+2)</td><td> sNaN(-1)</td><td> sNaN(-2)</td></tr>
<tr><th>-2.12e-314</th><td> -2.12e-314</td><td> -2.12e-314</td><td> -2.12e-314</td><td> -2.12e-314</td><td> -2.12e-314</td><td> -2.12e-314</td><td> -123.00</td><td> -∞</td><td> qNaN(+1)</td><td> qNaN(+2)</td><td> qNaN(-1)</td><td> qNaN(-2)</td><td> sNaN(+1)</td><td> sNaN(+2)</td><td> sNaN(-1)</td><td> sNaN(-2)</td></tr>
<tr><th>-123.00</th><td> -123.00</td><td> -123.00</td><td> -123.00</td><td> -123.00</td><td> -123.00</td><td> -123.00</td><td> -123.00</td><td> -∞</td><td> qNaN(+1)</td><td> qNaN(+2)</td><td> qNaN(-1)</td><td> qNaN(-2)</td><td> sNaN(+1)</td><td> sNaN(+2)</td><td> sNaN(-1)</td><td> sNaN(-2)</td></tr>
<tr><th>-∞</th><td> -∞</td><td> -∞</td><td> -∞</td><td> -∞</td><td> -∞</td><td> -∞</td><td> -∞</td><td> -∞</td><td> qNaN(+1)</td><td> qNaN(+2)</td><td> qNaN(-1)</td><td> qNaN(-2)</td><td> sNaN(+1)</td><td> sNaN(+2)</td><td> sNaN(-1)</td><td> sNaN(-2)</td></tr>
<tr><th>qNaN(+1)</th><td> qNaN(+1)</td><td> qNaN(+1)</td><td> qNaN(+1)</td><td> qNaN(+1)</td><td> qNaN(+1)</td><td> qNaN(+1)</td><td> qNaN(+1)</td><td> qNaN(+1)</td><td> qNaN(+1)</td><td> qNaN(+1)</td><td> qNaN(+1)</td><td> qNaN(+1)</td><td> qNaN(+1)</td><td> qNaN(+1)</td><td> qNaN(+1)</td><td> qNaN(+1)</td></tr>
<tr><th>qNaN(+2)</th><td> qNaN(+2)</td><td> qNaN(+2)</td><td> qNaN(+2)</td><td> qNaN(+2)</td><td> qNaN(+2)</td><td> qNaN(+2)</td><td> qNaN(+2)</td><td> qNaN(+2)</td><td> qNaN(+2)</td><td> qNaN(+2)</td><td> qNaN(+2)</td><td> qNaN(+2)</td><td> qNaN(+2)</td><td> qNaN(+2)</td><td> qNaN(+2)</td><td> qNaN(+2)</td></tr>
<tr><th>qNaN(-1)</th><td> qNaN(-1)</td><td> qNaN(-1)</td><td> qNaN(-1)</td><td> qNaN(-1)</td><td> qNaN(-1)</td><td> qNaN(-1)</td><td> qNaN(-1)</td><td> qNaN(-1)</td><td> qNaN(-1)</td><td> qNaN(-1)</td><td> qNaN(-1)</td><td> qNaN(-1)</td><td> qNaN(-1)</td><td> qNaN(-1)</td><td> qNaN(-1)</td><td> qNaN(-1)</td></tr>
<tr><th>qNaN(-2)</th><td> qNaN(-2)</td><td> qNaN(-2)</td><td> qNaN(-2)</td><td> qNaN(-2)</td><td> qNaN(-2)</td><td> qNaN(-2)</td><td> qNaN(-2)</td><td> qNaN(-2)</td><td> qNaN(-2)</td><td> qNaN(-2)</td><td> qNaN(-2)</td><td> qNaN(-2)</td><td> qNaN(-2)</td><td> qNaN(-2)</td><td> qNaN(-2)</td><td> qNaN(-2)</td></tr>
<tr><th>sNaN(+1)</th><td> sNaN(+1)</td><td> sNaN(+1)</td><td> sNaN(+1)</td><td> sNaN(+1)</td><td> sNaN(+1)</td><td> sNaN(+1)</td><td> sNaN(+1)</td><td> sNaN(+1)</td><td> sNaN(+1)</td><td> sNaN(+1)</td><td> sNaN(+1)</td><td> sNaN(+1)</td><td> sNaN(+1)</td><td> sNaN(+1)</td><td> sNaN(+1)</td><td> sNaN(+1)</td></tr>
<tr><th>sNaN(+2)</th><td> sNaN(+2)</td><td> sNaN(+2)</td><td> sNaN(+2)</td><td> sNaN(+2)</td><td> sNaN(+2)</td><td> sNaN(+2)</td><td> sNaN(+2)</td><td> sNaN(+2)</td><td> sNaN(+2)</td><td> sNaN(+2)</td><td> sNaN(+2)</td><td> sNaN(+2)</td><td> sNaN(+2)</td><td> sNaN(+2)</td><td> sNaN(+2)</td><td> sNaN(+2)</td></tr>
<tr><th>sNaN(-1)</th><td> sNaN(-1)</td><td> sNaN(-1)</td><td> sNaN(-1)</td><td> sNaN(-1)</td><td> sNaN(-1)</td><td> sNaN(-1)</td><td> sNaN(-1)</td><td> sNaN(-1)</td><td> sNaN(-1)</td><td> sNaN(-1)</td><td> sNaN(-1)</td><td> sNaN(-1)</td><td> sNaN(-1)</td><td> sNaN(-1)</td><td> sNaN(-1)</td><td> sNaN(-1)</td></tr>
<tr><th>sNaN(-2)</th><td> sNaN(-2)</td><td> sNaN(-2)</td><td> sNaN(-2)</td><td> sNaN(-2)</td><td> sNaN(-2)</td><td> sNaN(-2)</td><td> sNaN(-2)</td><td> sNaN(-2)</td><td> sNaN(-2)</td><td> sNaN(-2)</td><td> sNaN(-2)</td><td> sNaN(-2)</td><td> sNaN(-2)</td><td> sNaN(-2)</td><td> sNaN(-2)</td><td> sNaN(-2)</td></tr>
</table>

# 6. For &quot;double.MaxNumber(double, double)&quot;

<table>
<tr><th colspan="2" rowspan="2"/><th colspan="16">right</th></tr>
<tr><th>+∞</th><th>123.00</th><th>2.12e-314</th><th>+0</th><th>-0</th><th>-2.12e-314</th><th>-123.00</th><th>-∞</th><th>qNaN(+1)</th><th>qNaN(+2)</th><th>qNaN(-1)</th><th>qNaN(-2)</th><th>sNaN(+1)</th><th>sNaN(+2)</th><th>sNaN(-1)</th><th>sNaN(-2)</th></tr>
<tr><th rowspan="16">left</th><th>+∞</th><td> +∞</td><td> +∞</td><td> +∞</td><td> +∞</td><td> +∞</td><td> +∞</td><td> +∞</td><td> +∞</td><td> +∞</td><td> +∞</td><td> +∞</td><td> +∞</td><td> +∞</td><td> +∞</td><td> +∞</td><td> +∞</td></tr>
<tr><th>123.00</th><td> +∞</td><td> 123.00</td><td> 123.00</td><td> 123.00</td><td> 123.00</td><td> 123.00</td><td> 123.00</td><td> 123.00</td><td> 123.00</td><td> 123.00</td><td> 123.00</td><td> 123.00</td><td> 123.00</td><td> 123.00</td><td> 123.00</td><td> 123.00</td></tr>
<tr><th>2.12e-314</th><td> +∞</td><td> 123.00</td><td> 2.12e-314</td><td> 2.12e-314</td><td> 2.12e-314</td><td> 2.12e-314</td><td> 2.12e-314</td><td> 2.12e-314</td><td> 2.12e-314</td><td> 2.12e-314</td><td> 2.12e-314</td><td> 2.12e-314</td><td> 2.12e-314</td><td> 2.12e-314</td><td> 2.12e-314</td><td> 2.12e-314</td></tr>
<tr><th>+0</th><td> +∞</td><td> 123.00</td><td> 2.12e-314</td><td> +0</td><td> +0</td><td> +0</td><td> +0</td><td> +0</td><td> +0</td><td> +0</td><td> +0</td><td> +0</td><td> +0</td><td> +0</td><td> +0</td><td> +0</td></tr>
<tr><th>-0</th><td> +∞</td><td> 123.00</td><td> 2.12e-314</td><td> +0</td><td> -0</td><td> -0</td><td> -0</td><td> -0</td><td> -0</td><td> -0</td><td> -0</td><td> -0</td><td> -0</td><td> -0</td><td> -0</td><td> -0</td></tr>
<tr><th>-2.12e-314</th><td> +∞</td><td> 123.00</td><td> 2.12e-314</td><td> +0</td><td> -0</td><td> -2.12e-314</td><td> -2.12e-314</td><td> -2.12e-314</td><td> -2.12e-314</td><td> -2.12e-314</td><td> -2.12e-314</td><td> -2.12e-314</td><td> -2.12e-314</td><td> -2.12e-314</td><td> -2.12e-314</td><td> -2.12e-314</td></tr>
<tr><th>-123.00</th><td> +∞</td><td> 123.00</td><td> 2.12e-314</td><td> +0</td><td> -0</td><td> -2.12e-314</td><td> -123.00</td><td> -123.00</td><td> -123.00</td><td> -123.00</td><td> -123.00</td><td> -123.00</td><td> -123.00</td><td> -123.00</td><td> -123.00</td><td> -123.00</td></tr>
<tr><th>-∞</th><td> +∞</td><td> 123.00</td><td> 2.12e-314</td><td> +0</td><td> -0</td><td> -2.12e-314</td><td> -123.00</td><td> -∞</td><td> -∞</td><td> -∞</td><td> -∞</td><td> -∞</td><td> -∞</td><td> -∞</td><td> -∞</td><td> -∞</td></tr>
<tr><th>qNaN(+1)</th><td> +∞</td><td> 123.00</td><td> 2.12e-314</td><td> +0</td><td> -0</td><td> -2.12e-314</td><td> -123.00</td><td> -∞</td><td> qNaN(+1)</td><td> qNaN(+1)</td><td> qNaN(+1)</td><td> qNaN(+1)</td><td> qNaN(+1)</td><td> qNaN(+1)</td><td> qNaN(+1)</td><td> qNaN(+1)</td></tr>
<tr><th>qNaN(+2)</th><td> +∞</td><td> 123.00</td><td> 2.12e-314</td><td> +0</td><td> -0</td><td> -2.12e-314</td><td> -123.00</td><td> -∞</td><td> qNaN(+2)</td><td> qNaN(+2)</td><td> qNaN(+2)</td><td> qNaN(+2)</td><td> qNaN(+2)</td><td> qNaN(+2)</td><td> qNaN(+2)</td><td> qNaN(+2)</td></tr>
<tr><th>qNaN(-1)</th><td> +∞</td><td> 123.00</td><td> 2.12e-314</td><td> +0</td><td> -0</td><td> -2.12e-314</td><td> -123.00</td><td> -∞</td><td> qNaN(-1)</td><td> qNaN(-1)</td><td> qNaN(-1)</td><td> qNaN(-1)</td><td> qNaN(-1)</td><td> qNaN(-1)</td><td> qNaN(-1)</td><td> qNaN(-1)</td></tr>
<tr><th>qNaN(-2)</th><td> +∞</td><td> 123.00</td><td> 2.12e-314</td><td> +0</td><td> -0</td><td> -2.12e-314</td><td> -123.00</td><td> -∞</td><td> qNaN(-2)</td><td> qNaN(-2)</td><td> qNaN(-2)</td><td> qNaN(-2)</td><td> qNaN(-2)</td><td> qNaN(-2)</td><td> qNaN(-2)</td><td> qNaN(-2)</td></tr>
<tr><th>sNaN(+1)</th><td> +∞</td><td> 123.00</td><td> 2.12e-314</td><td> +0</td><td> -0</td><td> -2.12e-314</td><td> -123.00</td><td> -∞</td><td> sNaN(+1)</td><td> sNaN(+1)</td><td> sNaN(+1)</td><td> sNaN(+1)</td><td> sNaN(+1)</td><td> sNaN(+1)</td><td> sNaN(+1)</td><td> sNaN(+1)</td></tr>
<tr><th>sNaN(+2)</th><td> +∞</td><td> 123.00</td><td> 2.12e-314</td><td> +0</td><td> -0</td><td> -2.12e-314</td><td> -123.00</td><td> -∞</td><td> sNaN(+2)</td><td> sNaN(+2)</td><td> sNaN(+2)</td><td> sNaN(+2)</td><td> sNaN(+2)</td><td> sNaN(+2)</td><td> sNaN(+2)</td><td> sNaN(+2)</td></tr>
<tr><th>sNaN(-1)</th><td> +∞</td><td> 123.00</td><td> 2.12e-314</td><td> +0</td><td> -0</td><td> -2.12e-314</td><td> -123.00</td><td> -∞</td><td> sNaN(-1)</td><td> sNaN(-1)</td><td> sNaN(-1)</td><td> sNaN(-1)</td><td> sNaN(-1)</td><td> sNaN(-1)</td><td> sNaN(-1)</td><td> sNaN(-1)</td></tr>
<tr><th>sNaN(-2)</th><td> +∞</td><td> 123.00</td><td> 2.12e-314</td><td> +0</td><td> -0</td><td> -2.12e-314</td><td> -123.00</td><td> -∞</td><td> sNaN(-2)</td><td> sNaN(-2)</td><td> sNaN(-2)</td><td> sNaN(-2)</td><td> sNaN(-2)</td><td> sNaN(-2)</td><td> sNaN(-2)</td><td> sNaN(-2)</td></tr>
</table>

# 7. For &quot;double.MinNumber(double, double)&quot;

<table>
<tr><th colspan="2" rowspan="2"/><th colspan="16">right</th></tr>
<tr><th>+∞</th><th>123.00</th><th>2.12e-314</th><th>+0</th><th>-0</th><th>-2.12e-314</th><th>-123.00</th><th>-∞</th><th>qNaN(+1)</th><th>qNaN(+2)</th><th>qNaN(-1)</th><th>qNaN(-2)</th><th>sNaN(+1)</th><th>sNaN(+2)</th><th>sNaN(-1)</th><th>sNaN(-2)</th></tr>
<tr><th rowspan="16">left</th><th>+∞</th><td> +∞</td><td> 123.00</td><td> 2.12e-314</td><td> +0</td><td> -0</td><td> -2.12e-314</td><td> -123.00</td><td> -∞</td><td> +∞</td><td> +∞</td><td> +∞</td><td> +∞</td><td> +∞</td><td> +∞</td><td> +∞</td><td> +∞</td></tr>
<tr><th>123.00</th><td> 123.00</td><td> 123.00</td><td> 2.12e-314</td><td> +0</td><td> -0</td><td> -2.12e-314</td><td> -123.00</td><td> -∞</td><td> 123.00</td><td> 123.00</td><td> 123.00</td><td> 123.00</td><td> 123.00</td><td> 123.00</td><td> 123.00</td><td> 123.00</td></tr>
<tr><th>2.12e-314</th><td> 2.12e-314</td><td> 2.12e-314</td><td> 2.12e-314</td><td> +0</td><td> -0</td><td> -2.12e-314</td><td> -123.00</td><td> -∞</td><td> 2.12e-314</td><td> 2.12e-314</td><td> 2.12e-314</td><td> 2.12e-314</td><td> 2.12e-314</td><td> 2.12e-314</td><td> 2.12e-314</td><td> 2.12e-314</td></tr>
<tr><th>+0</th><td> +0</td><td> +0</td><td> +0</td><td> +0</td><td> -0</td><td> -2.12e-314</td><td> -123.00</td><td> -∞</td><td> +0</td><td> +0</td><td> +0</td><td> +0</td><td> +0</td><td> +0</td><td> +0</td><td> +0</td></tr>
<tr><th>-0</th><td> -0</td><td> -0</td><td> -0</td><td> -0</td><td> -0</td><td> -2.12e-314</td><td> -123.00</td><td> -∞</td><td> -0</td><td> -0</td><td> -0</td><td> -0</td><td> -0</td><td> -0</td><td> -0</td><td> -0</td></tr>
<tr><th>-2.12e-314</th><td> -2.12e-314</td><td> -2.12e-314</td><td> -2.12e-314</td><td> -2.12e-314</td><td> -2.12e-314</td><td> -2.12e-314</td><td> -123.00</td><td> -∞</td><td> -2.12e-314</td><td> -2.12e-314</td><td> -2.12e-314</td><td> -2.12e-314</td><td> -2.12e-314</td><td> -2.12e-314</td><td> -2.12e-314</td><td> -2.12e-314</td></tr>
<tr><th>-123.00</th><td> -123.00</td><td> -123.00</td><td> -123.00</td><td> -123.00</td><td> -123.00</td><td> -123.00</td><td> -123.00</td><td> -∞</td><td> -123.00</td><td> -123.00</td><td> -123.00</td><td> -123.00</td><td> -123.00</td><td> -123.00</td><td> -123.00</td><td> -123.00</td></tr>
<tr><th>-∞</th><td> -∞</td><td> -∞</td><td> -∞</td><td> -∞</td><td> -∞</td><td> -∞</td><td> -∞</td><td> -∞</td><td> -∞</td><td> -∞</td><td> -∞</td><td> -∞</td><td> -∞</td><td> -∞</td><td> -∞</td><td> -∞</td></tr>
<tr><th>qNaN(+1)</th><td> +∞</td><td> 123.00</td><td> 2.12e-314</td><td> +0</td><td> -0</td><td> -2.12e-314</td><td> -123.00</td><td> -∞</td><td> qNaN(+1)</td><td> qNaN(+1)</td><td> qNaN(+1)</td><td> qNaN(+1)</td><td> qNaN(+1)</td><td> qNaN(+1)</td><td> qNaN(+1)</td><td> qNaN(+1)</td></tr>
<tr><th>qNaN(+2)</th><td> +∞</td><td> 123.00</td><td> 2.12e-314</td><td> +0</td><td> -0</td><td> -2.12e-314</td><td> -123.00</td><td> -∞</td><td> qNaN(+2)</td><td> qNaN(+2)</td><td> qNaN(+2)</td><td> qNaN(+2)</td><td> qNaN(+2)</td><td> qNaN(+2)</td><td> qNaN(+2)</td><td> qNaN(+2)</td></tr>
<tr><th>qNaN(-1)</th><td> +∞</td><td> 123.00</td><td> 2.12e-314</td><td> +0</td><td> -0</td><td> -2.12e-314</td><td> -123.00</td><td> -∞</td><td> qNaN(-1)</td><td> qNaN(-1)</td><td> qNaN(-1)</td><td> qNaN(-1)</td><td> qNaN(-1)</td><td> qNaN(-1)</td><td> qNaN(-1)</td><td> qNaN(-1)</td></tr>
<tr><th>qNaN(-2)</th><td> +∞</td><td> 123.00</td><td> 2.12e-314</td><td> +0</td><td> -0</td><td> -2.12e-314</td><td> -123.00</td><td> -∞</td><td> qNaN(-2)</td><td> qNaN(-2)</td><td> qNaN(-2)</td><td> qNaN(-2)</td><td> qNaN(-2)</td><td> qNaN(-2)</td><td> qNaN(-2)</td><td> qNaN(-2)</td></tr>
<tr><th>sNaN(+1)</th><td> +∞</td><td> 123.00</td><td> 2.12e-314</td><td> +0</td><td> -0</td><td> -2.12e-314</td><td> -123.00</td><td> -∞</td><td> sNaN(+1)</td><td> sNaN(+1)</td><td> sNaN(+1)</td><td> sNaN(+1)</td><td> sNaN(+1)</td><td> sNaN(+1)</td><td> sNaN(+1)</td><td> sNaN(+1)</td></tr>
<tr><th>sNaN(+2)</th><td> +∞</td><td> 123.00</td><td> 2.12e-314</td><td> +0</td><td> -0</td><td> -2.12e-314</td><td> -123.00</td><td> -∞</td><td> sNaN(+2)</td><td> sNaN(+2)</td><td> sNaN(+2)</td><td> sNaN(+2)</td><td> sNaN(+2)</td><td> sNaN(+2)</td><td> sNaN(+2)</td><td> sNaN(+2)</td></tr>
<tr><th>sNaN(-1)</th><td> +∞</td><td> 123.00</td><td> 2.12e-314</td><td> +0</td><td> -0</td><td> -2.12e-314</td><td> -123.00</td><td> -∞</td><td> sNaN(-1)</td><td> sNaN(-1)</td><td> sNaN(-1)</td><td> sNaN(-1)</td><td> sNaN(-1)</td><td> sNaN(-1)</td><td> sNaN(-1)</td><td> sNaN(-1)</td></tr>
<tr><th>sNaN(-2)</th><td> +∞</td><td> 123.00</td><td> 2.12e-314</td><td> +0</td><td> -0</td><td> -2.12e-314</td><td> -123.00</td><td> -∞</td><td> sNaN(-2)</td><td> sNaN(-2)</td><td> sNaN(-2)</td><td> sNaN(-2)</td><td> sNaN(-2)</td><td> sNaN(-2)</td><td> sNaN(-2)</td><td> sNaN(-2)</td></tr>
</table>

# 8. For &quot;Vector.Max(Vector&lt;double&gt;, Vector&lt;double&gt;)&quot;

<table>
<tr><th colspan="2" rowspan="2"/><th colspan="16">right</th></tr>
<tr><th>+∞</th><th>123.00</th><th>2.12e-314</th><th>+0</th><th>-0</th><th>-2.12e-314</th><th>-123.00</th><th>-∞</th><th>qNaN(+1)</th><th>qNaN(+2)</th><th>qNaN(-1)</th><th>qNaN(-2)</th><th>sNaN(+1)</th><th>sNaN(+2)</th><th>sNaN(-1)</th><th>sNaN(-2)</th></tr>
<tr><th rowspan="16">left</th><th>+∞</th><td> +∞</td><td> +∞</td><td> +∞</td><td> +∞</td><td> +∞</td><td> +∞</td><td> +∞</td><td> +∞</td><td> qNaN(+1)</td><td> qNaN(+2)</td><td> qNaN(-1)</td><td> qNaN(-2)</td><td> sNaN(+1)</td><td> sNaN(+2)</td><td> sNaN(-1)</td><td> sNaN(-2)</td></tr>
<tr><th>123.00</th><td> +∞</td><td> 123.00</td><td> 123.00</td><td> 123.00</td><td> 123.00</td><td> 123.00</td><td> 123.00</td><td> 123.00</td><td> qNaN(+1)</td><td> qNaN(+2)</td><td> qNaN(-1)</td><td> qNaN(-2)</td><td> sNaN(+1)</td><td> sNaN(+2)</td><td> sNaN(-1)</td><td> sNaN(-2)</td></tr>
<tr><th>2.12e-314</th><td> +∞</td><td> 123.00</td><td> 2.12e-314</td><td> 2.12e-314</td><td> 2.12e-314</td><td> 2.12e-314</td><td> 2.12e-314</td><td> 2.12e-314</td><td> qNaN(+1)</td><td> qNaN(+2)</td><td> qNaN(-1)</td><td> qNaN(-2)</td><td> sNaN(+1)</td><td> sNaN(+2)</td><td> sNaN(-1)</td><td> sNaN(-2)</td></tr>
<tr><th>+0</th><td> +∞</td><td> 123.00</td><td> 2.12e-314</td><td> +0</td><td> -0</td><td> +0</td><td> +0</td><td> +0</td><td> qNaN(+1)</td><td> qNaN(+2)</td><td> qNaN(-1)</td><td> qNaN(-2)</td><td> sNaN(+1)</td><td> sNaN(+2)</td><td> sNaN(-1)</td><td> sNaN(-2)</td></tr>
<tr><th>-0</th><td> +∞</td><td> 123.00</td><td> 2.12e-314</td><td> +0</td><td> -0</td><td> -0</td><td> -0</td><td> -0</td><td> qNaN(+1)</td><td> qNaN(+2)</td><td> qNaN(-1)</td><td> qNaN(-2)</td><td> sNaN(+1)</td><td> sNaN(+2)</td><td> sNaN(-1)</td><td> sNaN(-2)</td></tr>
<tr><th>-2.12e-314</th><td> +∞</td><td> 123.00</td><td> 2.12e-314</td><td> +0</td><td> -0</td><td> -2.12e-314</td><td> -2.12e-314</td><td> -2.12e-314</td><td> qNaN(+1)</td><td> qNaN(+2)</td><td> qNaN(-1)</td><td> qNaN(-2)</td><td> sNaN(+1)</td><td> sNaN(+2)</td><td> sNaN(-1)</td><td> sNaN(-2)</td></tr>
<tr><th>-123.00</th><td> +∞</td><td> 123.00</td><td> 2.12e-314</td><td> +0</td><td> -0</td><td> -2.12e-314</td><td> -123.00</td><td> -123.00</td><td> qNaN(+1)</td><td> qNaN(+2)</td><td> qNaN(-1)</td><td> qNaN(-2)</td><td> sNaN(+1)</td><td>sNaN(+2)</td><td> sNaN(-1)</td><td> sNaN(-2)</td></tr>
<tr><th>-∞</th><td> +∞</td><td> 123.00</td><td> 2.12e-314</td><td> +0</td><td> -0</td><td> -2.12e-314</td><td> -123.00</td><td> -∞</td><td> qNaN(+1)</td><td> qNaN(+2)</td><td> qNaN(-1)</td><td> qNaN(-2)</td><td> sNaN(+1)</td><td> sNaN(+2)</td><td> sNaN(-1)</td><td> sNaN(-2)</td></tr>
<tr><th>qNaN(+1)</th><td> +∞</td><td> 123.00</td><td> 2.12e-314</td><td> +0</td><td> -0</td><td> -2.12e-314</td><td> -123.00</td><td> -∞</td><td> qNaN(+1)</td><td> qNaN(+2)</td><td> qNaN(-1)</td><td> qNaN(-2)</td><td> sNaN(+1)</td><td> sNaN(+2)</td><td> sNaN(-1)</td><td> sNaN(-2)</td></tr>
<tr><th>qNaN(+2)</th><td> +∞</td><td> 123.00</td><td> 2.12e-314</td><td> +0</td><td> -0</td><td> -2.12e-314</td><td> -123.00</td><td> -∞</td><td> qNaN(+1)</td><td> qNaN(+2)</td><td> qNaN(-1)</td><td> qNaN(-2)</td><td> sNaN(+1)</td><td> sNaN(+2)</td><td> sNaN(-1)</td><td> sNaN(-2)</td></tr>
<tr><th>qNaN(-1)</th><td> +∞</td><td> 123.00</td><td> 2.12e-314</td><td> +0</td><td> -0</td><td> -2.12e-314</td><td> -123.00</td><td> -∞</td><td> qNaN(+1)</td><td> qNaN(+2)</td><td> qNaN(-1)</td><td> qNaN(-2)</td><td> sNaN(+1)</td><td> sNaN(+2)</td><td> sNaN(-1)</td><td> sNaN(-2)</td></tr>
<tr><th>qNaN(-2)</th><td> +∞</td><td> 123.00</td><td> 2.12e-314</td><td> +0</td><td> -0</td><td> -2.12e-314</td><td> -123.00</td><td> -∞</td><td> qNaN(+1)</td><td> qNaN(+2)</td><td> qNaN(-1)</td><td> qNaN(-2)</td><td> sNaN(+1)</td><td> sNaN(+2)</td><td> sNaN(-1)</td><td> sNaN(-2)</td></tr>
<tr><th>sNaN(+1)</th><td> +∞</td><td> 123.00</td><td> 2.12e-314</td><td> +0</td><td> -0</td><td> -2.12e-314</td><td> -123.00</td><td> -∞</td><td> qNaN(+1)</td><td> qNaN(+2)</td><td> qNaN(-1)</td><td> qNaN(-2)</td><td> sNaN(+1)</td><td> sNaN(+2)</td><td> sNaN(-1)</td><td> sNaN(-2)</td></tr>
<tr><th>sNaN(+2)</th><td> +∞</td><td> 123.00</td><td> 2.12e-314</td><td> +0</td><td> -0</td><td> -2.12e-314</td><td> -123.00</td><td> -∞</td><td> qNaN(+1)</td><td> qNaN(+2)</td><td> qNaN(-1)</td><td> qNaN(-2)</td><td> sNaN(+1)</td><td> sNaN(+2)</td><td> sNaN(-1)</td><td> sNaN(-2)</td></tr>
<tr><th>sNaN(-1)</th><td> +∞</td><td> 123.00</td><td> 2.12e-314</td><td> +0</td><td> -0</td><td> -2.12e-314</td><td> -123.00</td><td> -∞</td><td> qNaN(+1)</td><td> qNaN(+2)</td><td> qNaN(-1)</td><td> qNaN(-2)</td><td> sNaN(+1)</td><td> sNaN(+2)</td><td> sNaN(-1)</td><td> sNaN(-2)</td></tr>
<tr><th>sNaN(-2)</th><td> +∞</td><td> 123.00</td><td> 2.12e-314</td><td> +0</td><td> -0</td><td> -2.12e-314</td><td> -123.00</td><td> -∞</td><td> qNaN(+1)</td><td> qNaN(+2)</td><td> qNaN(-1)</td><td> qNaN(-2)</td><td> sNaN(+1)</td><td> sNaN(+2)</td><td> sNaN(-1)</td><td> sNaN(-2)</td></tr>
</table>

# 9. For &quot;Vector.Min(Vector&lt;double&gt;, Vector&lt;double&gt;)&quot;

<table>
<tr><th colspan="2" rowspan="2"/><th colspan="16">right</th></tr>
<tr><th>+∞</th><th>123.00</th><th>2.12e-314</th><th>+0</th><th>-0</th><th>-2.12e-314</th><th>-123.00</th><th>-∞</th><th>qNaN(+1)</th><th>qNaN(+2)</th><th>qNaN(-1)</th><th>qNaN(-2)</th><th>sNaN(+1)</th><th>sNaN(+2)</th><th>sNaN(-1)</th><th>sNaN(-2)</th></tr>
<tr><th rowspan="16">left</th><th>+∞</th><td> +∞</td><td> 123.00</td><td> 2.12e-314</td><td> +0</td><td> -0</td><td> -2.12e-314</td><td> -123.00</td><td> -∞</td><td> qNaN(+1)</td><td> qNaN(+2)</td><td> qNaN(-1)</td><td> qNaN(-2)</td><td> sNaN(+1)</td><td> sNaN(+2)</td><td> sNaN(-1)</td><td> sNaN(-2)</td></tr>
<tr><th>123.00</th><td> 123.00</td><td> 123.00</td><td> 2.12e-314</td><td> +0</td><td> -0</td><td> -2.12e-314</td><td> -123.00</td><td> -∞</td><td> qNaN(+1)</td><td> qNaN(+2)</td><td> qNaN(-1)</td><td> qNaN(-2)</td><td> sNaN(+1)</td><td> sNaN(+2)</td><td> sNaN(-1)</td><td> sNaN(-2)</td></tr>
<tr><th>2.12e-314</th><td> 2.12e-314</td><td> 2.12e-314</td><td> 2.12e-314</td><td> +0</td><td> -0</td><td> -2.12e-314</td><td> -123.00</td><td> -∞</td><td> qNaN(+1)</td><td> qNaN(+2)</td><td> qNaN(-1)</td><td> qNaN(-2)</td><td> sNaN(+1)</td><td> sNaN(+2)</td><td> sNaN(-1)</td><td> sNaN(-2)</td></tr>
<tr><th>+0</th><td> +0</td><td> +0</td><td> +0</td><td> +0</td><td> -0</td><td> -2.12e-314</td><td> -123.00</td><td> -∞</td><td> qNaN(+1)</td><td> qNaN(+2)</td><td> qNaN(-1)</td><td> qNaN(-2)</td><td> sNaN(+1)</td><td> sNaN(+2)</td><td> sNaN(-1)</td><td> sNaN(-2)</td></tr>
<tr><th>-0</th><td> -0</td><td> -0</td><td> -0</td><td> +0</td><td> -0</td><td> -2.12e-314</td><td> -123.00</td><td> -∞</td><td> qNaN(+1)</td><td> qNaN(+2)</td><td> qNaN(-1)</td><td> qNaN(-2)</td><td> sNaN(+1)</td><td> sNaN(+2)</td><td> sNaN(-1)</td><td> sNaN(-2)</td></tr>
<tr><th>-2.12e-314</th><td> -2.12e-314</td><td> -2.12e-314</td><td> -2.12e-314</td><td> -2.12e-314</td><td> -2.12e-314</td><td> -2.12e-314</td><td> -123.00</td><td> -∞</td><td> qNaN(+1)</td><td> qNaN(+2)</td><td> qNaN(-1)</td><td> qNaN(-2)</td><td> sNaN(+1)</td><td> sNaN(+2)</td><td> sNaN(-1)</td><td> sNaN(-2)</td></tr>
<tr><th>-123.00</th><td> -123.00</td><td> -123.00</td><td> -123.00</td><td> -123.00</td><td> -123.00</td><td> -123.00</td><td> -123.00</td><td> -∞</td><td> qNaN(+1)</td><td> qNaN(+2)</td><td> qNaN(-1)</td><td> qNaN(-2)</td><td> sNaN(+1)</td><td> sNaN(+2)</td><td> sNaN(-1)</td><td> sNaN(-2)</td></tr>
<tr><th>-∞</th><td> -∞</td><td> -∞</td><td> -∞</td><td> -∞</td><td> -∞</td><td> -∞</td><td> -∞</td><td> -∞</td><td> qNaN(+1)</td><td> qNaN(+2)</td><td> qNaN(-1)</td><td> qNaN(-2)</td><td> sNaN(+1)</td><td> sNaN(+2)</td><td> sNaN(-1)</td><td> sNaN(-2)</td></tr>
<tr><th>qNaN(+1)</th><td> +∞</td><td> 123.00</td><td> 2.12e-314</td><td> +0</td><td> -0</td><td> -2.12e-314</td><td> -123.00</td><td> -∞</td><td> qNaN(+1)</td><td> qNaN(+2)</td><td> qNaN(-1)</td><td> qNaN(-2)</td><td> sNaN(+1)</td><td> sNaN(+2)</td><td> sNaN(-1)</td><td> sNaN(-2)</td></tr>
<tr><th>qNaN(+2)</th><td> +∞</td><td> 123.00</td><td> 2.12e-314</td><td> +0</td><td> -0</td><td> -2.12e-314</td><td> -123.00</td><td> -∞</td><td> qNaN(+1)</td><td> qNaN(+2)</td><td> qNaN(-1)</td><td> qNaN(-2)</td><td> sNaN(+1)</td><td> sNaN(+2)</td><td> sNaN(-1)</td><td> sNaN(-2)</td></tr>
<tr><th>qNaN(-1)</th><td> +∞</td><td> 123.00</td><td> 2.12e-314</td><td> +0</td><td> -0</td><td> -2.12e-314</td><td> -123.00</td><td> -∞</td><td> qNaN(+1)</td><td> qNaN(+2)</td><td> qNaN(-1)</td><td> qNaN(-2)</td><td> sNaN(+1)</td><td> sNaN(+2)</td><td> sNaN(-1)</td><td> sNaN(-2)</td></tr>
<tr><th>qNaN(-2)</th><td> +∞</td><td> 123.00</td><td> 2.12e-314</td><td> +0</td><td> -0</td><td> -2.12e-314</td><td> -123.00</td><td> -∞</td><td> qNaN(+1)</td><td> qNaN(+2)</td><td> qNaN(-1)</td><td> qNaN(-2)</td><td> sNaN(+1)</td><td> sNaN(+2)</td><td> sNaN(-1)</td><td> sNaN(-2)</td></tr>
<tr><th>sNaN(+1)</th><td> +∞</td><td> 123.00</td><td> 2.12e-314</td><td> +0</td><td> -0</td><td> -2.12e-314</td><td> -123.00</td><td> -∞</td><td> qNaN(+1)</td><td> qNaN(+2)</td><td> qNaN(-1)</td><td> qNaN(-2)</td><td> sNaN(+1)</td><td> sNaN(+2)</td><td> sNaN(-1)</td><td> sNaN(-2)</td></tr>
<tr><th>sNaN(+2)</th><td> +∞</td><td> 123.00</td><td> 2.12e-314</td><td> +0</td><td> -0</td><td> -2.12e-314</td><td> -123.00</td><td> -∞</td><td> qNaN(+1)</td><td> qNaN(+2)</td><td> qNaN(-1)</td><td> qNaN(-2)</td><td> sNaN(+1)</td><td> sNaN(+2)</td><td> sNaN(-1)</td><td> sNaN(-2)</td></tr>
<tr><th>sNaN(-1)</th><td> +∞</td><td> 123.00</td><td> 2.12e-314</td><td> +0</td><td> -0</td><td> -2.12e-314</td><td> -123.00</td><td> -∞</td><td> qNaN(+1)</td><td> qNaN(+2)</td><td> qNaN(-1)</td><td> qNaN(-2)</td><td> sNaN(+1)</td><td> sNaN(+2)</td><td> sNaN(-1)</td><td> sNaN(-2)</td></tr>
<tr><th>sNaN(-2)</th><td> +∞</td><td> 123.00</td><td> 2.12e-314</td><td> +0</td><td> -0</td><td> -2.12e-314</td><td> -123.00</td><td> -∞</td><td> qNaN(+1)</td><td> qNaN(+2)</td><td> qNaN(-1)</td><td> qNaN(-2)</td><td> sNaN(+1)</td><td> sNaN(+2)</td><td> sNaN(-1)</td><td> sNaN(-2)</td></tr>
</table>
