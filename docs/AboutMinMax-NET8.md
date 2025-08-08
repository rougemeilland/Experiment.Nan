# Runtime environment

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

# double.Max(double, double)

<table>
<tr><th colspan="2"/><th colspan="16">right</th></tr>
<tr><th colspan="2"/><th>+∞</th><th>123.00</th><th>2.12e-314</th><th>+0</th><th>-0</th><th>-2.12e-314</th><th>-123.00</th><th>-∞</th><th>qNaN(+1)</th><th>qNaN(+2)</th><th>qNaN(-1)</th><th>qNaN(-2)</th><th>sNaN(+1)</th><th>sNaN(+2)</th><th>sNaN(-1)</th><th>sNaN(-2)</th></tr>
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

# double.Min(double, double)

<table>
<tr><th colspan="2"/><th colspan="16">right</th></tr>
<tr><th colspan="2"/><th>+∞</th><th>123.00</th><th>2.12e-314</th><th>+0</th><th>-0</th><th>-2.12e-314</th><th>-123.00</th><th>-∞</th><th>qNaN(+1)</th><th>qNaN(+2)</th><th>qNaN(-1)</th><th>qNaN(-2)</th><th>sNaN(+1)</th><th>sNaN(+2)</th><th>sNaN(-1)</th><th>sNaN(-2)</th></tr>
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

# double.MaxNumber(double, double)

<table>
<tr><th colspan="2"/><th colspan="16">right</th></tr>
<tr><th colspan="2"/><th>+∞</th><th>123.00</th><th>2.12e-314</th><th>+0</th><th>-0</th><th>-2.12e-314</th><th>-123.00</th><th>-∞</th><th>qNaN(+1)</th><th>qNaN(+2)</th><th>qNaN(-1)</th><th>qNaN(-2)</th><th>sNaN(+1)</th><th>sNaN(+2)</th><th>sNaN(-1)</th><th>sNaN(-2)</th></tr>
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

# double.MinNumber(double, double)

<table>
<tr><th colspan="2"/><th colspan="16">right</th></tr>
<tr><th colspan="2"/><th>+∞</th><th>123.00</th><th>2.12e-314</th><th>+0</th><th>-0</th><th>-2.12e-314</th><th>-123.00</th><th>-∞</th><th>qNaN(+1)</th><th>qNaN(+2)</th><th>qNaN(-1)</th><th>qNaN(-2)</th><th>sNaN(+1)</th><th>sNaN(+2)</th><th>sNaN(-1)</th><th>sNaN(-2)</th></tr>
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

# Vector.Max(Vector<double>, Vector<double>)

<table>
<tr><th colspan="2"/><th colspan="16">right</th></tr>
<tr><th colspan="2"/><th>+∞</th><th>123.00</th><th>2.12e-314</th><th>+0</th><th>-0</th><th>-2.12e-314</th><th>-123.00</th><th>-∞</th><th>qNaN(+1)</th><th>qNaN(+2)</th><th>qNaN(-1)</th><th>qNaN(-2)</th><th>sNaN(+1)</th><th>sNaN(+2)</th><th>sNaN(-1)</th><th>sNaN(-2)</th></tr>
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

# Vector.Min(Vector<double>, Vector<double>)

<table>
<tr><th colspan="2"/><th colspan="16">right</th></tr>
<tr><th colspan="2"/><th>+∞</th><th>123.00</th><th>2.12e-314</th><th>+0</th><th>-0</th><th>-2.12e-314</th><th>-123.00</th><th>-∞</th><th>qNaN(+1)</th><th>qNaN(+2)</th><th>qNaN(-1)</th><th>qNaN(-2)</th><th>sNaN(+1)</th><th>sNaN(+2)</th><th>sNaN(-1)</th><th>sNaN(-2)</th></tr>
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
