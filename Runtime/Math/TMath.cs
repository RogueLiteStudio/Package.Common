using System;
using Unity.VisualScripting.YamlDotNet.Core.Tokens;
/* Copyright (C) <2009-2011> <Thorben Linneweber, Jitter Physics>
* 
*  This software is provided 'as-is', without any express or implied
*  warranty.  In no event will the authors be held liable for any damages
*  arising from the use of this software.
*
*  Permission is granted to anyone to use this software for any purpose,
*  including commercial applications, and to alter it and redistribute it
*  freely, subject to the following restrictions:
*
*  1. The origin of this software must not be misrepresented; you must not
*      claim that you wrote the original software. If you use this software
*      in a product, an acknowledgment in the product documentation would be
*      appreciated but is not required.
*  2. Altered source versions must be plainly marked as such, and must not be
*      misrepresented as being the original software.
*  3. This notice may not be removed or altered from any source distribution. 
*/

namespace TrueSync
{

    /// <summary>
    /// Contains common math operations.
    /// </summary>
    public sealed class TMath
    {

        /// <summary>
        /// PI constant.
        /// </summary>
        public static TFloat Pi = TFloat.Pi;

        /**
        *  @brief PI over 2 constant.
        **/
        public static TFloat PiOver2 = TFloat.PiOver2;

        /// <summary>
        /// A small value often used to decide if numeric 
        /// results are zero.
        /// </summary>
        public static TFloat Epsilon = TFloat.Epsilon;

        /**
        *  @brief Degree to radians constant.
        **/
        public static TFloat Deg2Rad = TFloat.Deg2Rad;

        /**
        *  @brief Radians to degree constant.
        **/
        public static TFloat Rad2Deg = TFloat.Rad2Deg;


        /**
         * @brief FP infinity.
         * */
        public static TFloat Infinity = TFloat.MaxValue;

        /// <summary>
        /// Gets the square root.
        /// </summary>
        /// <param name="number">The number to get the square root from.</param>
        /// <returns></returns>
        public static TFloat Sqrt(TFloat number)
        {
            return TFloat.Sqrt(number);
        }

        /// <summary>
        /// Gets the maximum number of two values.
        /// </summary>
        /// <param name="val1">The first value.</param>
        /// <param name="val2">The second value.</param>
        /// <returns>Returns the largest value.</returns>
        public static TFloat Max(TFloat val1, TFloat val2)
        {
            return (val1 > val2) ? val1 : val2;
        }

        /// <summary>
        /// Gets the minimum number of two values.
        /// </summary>
        /// <param name="val1">The first value.</param>
        /// <param name="val2">The second value.</param>
        /// <returns>Returns the smallest value.</returns>
        public static TFloat Min(TFloat val1, TFloat val2)
        {
            return (val1 < val2) ? val1 : val2;
        }

        public static int Min(int a, int b)
        {
            return (a < b) ? a : b;
        }

        /// <summary>
        /// Gets the maximum number of three values.
        /// </summary>
        /// <param name="val1">The first value.</param>
        /// <param name="val2">The second value.</param>
        /// <param name="val3">The third value.</param>
        /// <returns>Returns the largest value.</returns>
        public static TFloat Max(TFloat val1, TFloat val2, TFloat val3)
        {
            TFloat max12 = (val1 > val2) ? val1 : val2;
            return (max12 > val3) ? max12 : val3;
        }

        public static int Max(int val1, int val2)
        {
            return (val1 > val2) ? val1 : val2;
        }

        /// <summary>
        /// Returns a number which is within [min,max]
        /// </summary>
        /// <param name="value">The value to clamp.</param>
        /// <param name="min">The minimum value.</param>
        /// <param name="max">The maximum value.</param>
        /// <returns>The clamped value.</returns>
        public static TFloat Clamp(TFloat value, TFloat min, TFloat max)
        {
            if (value < min)
            {
                value = min;
                return value;
            }
            if (value > max)
            {
                value = max;
            }
            return value;
        }

        public static int Clamp(int value, int min, int max)
        {
            if (value < min)
            {
                value = min;
                return value;
            }
            if (value > max)
            {
                value = max;
            }
            return value;
        }

        /// <summary>
        /// Returns a number which is within [FP.Zero, FP.One]
        /// </summary>
        /// <param name="value">The value to clamp.</param>
        /// <returns>The clamped value.</returns>
        public static TFloat Clamp01(TFloat value)
        {
            if (value < TFloat.Zero)
                return TFloat.Zero;

            if (value > TFloat.One)
                return TFloat.One;

            return value;
        }

        /// <summary>
        /// Changes every sign of the matrix entry to '+'
        /// </summary>
        /// <param name="matrix">The matrix.</param>
        /// <param name="result">The absolute matrix.</param>
        public static void Absolute(ref TMatrix matrix, out TMatrix result)
        {
            result.M11 = TFloat.Abs(matrix.M11);
            result.M12 = TFloat.Abs(matrix.M12);
            result.M13 = TFloat.Abs(matrix.M13);
            result.M21 = TFloat.Abs(matrix.M21);
            result.M22 = TFloat.Abs(matrix.M22);
            result.M23 = TFloat.Abs(matrix.M23);
            result.M31 = TFloat.Abs(matrix.M31);
            result.M32 = TFloat.Abs(matrix.M32);
            result.M33 = TFloat.Abs(matrix.M33);
        }

        /// <summary>
        /// Returns the sine of value.
        /// </summary>
        public static TFloat Sin(TFloat value)
        {
            return TFloat.Sin(value);
        }

        /// <summary>
        /// Returns the cosine of value.
        /// </summary>
        public static TFloat Cos(TFloat value)
        {
            return TFloat.Cos(value);
        }

        /// <summary>
        /// Returns the tan of value.
        /// </summary>
        public static TFloat Tan(TFloat value)
        {
            return TFloat.Tan(value);
        }

        /// <summary>
        /// Returns the arc sine of value.
        /// </summary>
        public static TFloat Asin(TFloat value)
        {
            return TFloat.Asin(value);
        }

        /// <summary>
        /// Returns the arc cosine of value.
        /// </summary>
        public static TFloat Acos(TFloat value)
        {
            return TFloat.Acos(value);
        }

        /// <summary>
        /// Returns the arc tan of value.
        /// </summary>
        public static TFloat Atan(TFloat value)
        {
            return TFloat.Atan(value);
        }

        /// <summary>
        /// Returns the arc tan of coordinates x-y.
        /// </summary>
        public static TFloat Atan2(TFloat y, TFloat x)
        {
            return TFloat.Atan2(y, x);
        }

        /// <summary>
        /// Returns the largest integer less than or equal to the specified number.
        /// </summary>
        public static TFloat Floor(TFloat value)
        {
            return TFloat.Floor(value);
        }

        public static int FloorToInt(TFloat value)
        {
            return (int)TFloat.Floor(value);
        }

        /// <summary>
        /// Returns the smallest integral value that is greater than or equal to the specified number.
        /// </summary>
        public static TFloat Ceil(TFloat value)
        { 
            return TFloat.Ceiling(value);
        }

        public static int CeilToInt(TFloat value)
        {
            return (int)TFloat.Ceiling(value);
        }

        /// <summary>
        /// Rounds a value to the nearest integral value.
        /// If the value is halfway between an even and an uneven value, returns the even value.
        /// </summary>
        public static TFloat Round(TFloat value)
        {
            return TFloat.Round(value);
        }

        public static int RoundToInt(TFloat value)
        {
            return (int)TFloat.Round(value);
        }

        /// <summary>
        /// Returns a number indicating the sign of a Fix64 number.
        /// Returns 1 if the value is positive, 0 if is 0, and -1 if it is negative.
        /// </summary>
        public static int Sign(TFloat value)
        {
            return TFloat.Sign(value);
        }

        /// <summary>
        /// Returns the absolute value of a Fix64 number.
        /// Note: Abs(Fix64.MinValue) == Fix64.MaxValue.
        /// </summary>
        public static TFloat Abs(TFloat value)
        {
            return TFloat.Abs(value);
        }

        public static TFloat Barycentric(TFloat value1, TFloat value2, TFloat value3, TFloat amount1, TFloat amount2)
        {
            return value1 + (value2 - value1) * amount1 + (value3 - value1) * amount2;
        }

        public static TFloat CatmullRom(TFloat value1, TFloat value2, TFloat value3, TFloat value4, TFloat amount)
        {
            // Using formula from http://www.mvps.org/directx/articles/catmull/
            // Internally using FPs not to lose precission
            TFloat amountSquared = amount * amount;
            TFloat amountCubed = amountSquared * amount;
            return (TFloat)(0.5 * (2.0 * value2 +
                                 (value3 - value1) * amount +
                                 (2.0 * value1 - 5.0 * value2 + 4.0 * value3 - value4) * amountSquared +
                                 (3.0 * value2 - value1 - 3.0 * value3 + value4) * amountCubed));
        }

        public static TFloat Distance(TFloat value1, TFloat value2)
        {
            return TFloat.Abs(value1 - value2);
        }

        public static TFloat Hermite(TFloat value1, TFloat tangent1, TFloat value2, TFloat tangent2, TFloat amount)
        {
            // All transformed to FP not to lose precission
            // Otherwise, for high numbers of param:amount the result is NaN instead of Infinity
            TFloat v1 = value1, v2 = value2, t1 = tangent1, t2 = tangent2, s = amount, result;
            TFloat sCubed = s * s * s;
            TFloat sSquared = s * s;

            if (amount == 0f)
                result = value1;
            else if (amount == 1f)
                result = value2;
            else
                result = (2 * v1 - 2 * v2 + t2 + t1) * sCubed +
                         (3 * v2 - 3 * v1 - 2 * t1 - t2) * sSquared +
                         t1 * s +
                         v1;
            return (TFloat)result;
        }

        public static TFloat Lerp(TFloat value1, TFloat value2, TFloat amount)
        {
            return value1 + (value2 - value1) * Clamp01(amount);
        }

        public static TFloat InverseLerp(TFloat value1, TFloat value2, TFloat amount)
        {
            if (value1 != value2)
                return Clamp01((amount - value1) / (value2 - value1));
            return TFloat.Zero;
        }

        public static TFloat SmoothStep(TFloat value1, TFloat value2, TFloat amount)
        {
            // It is expected that 0 < amount < 1
            // If amount < 0, return value1
            // If amount > 1, return value2
            TFloat result = Clamp(amount, 0f, 1f);
            result = Hermite(value1, 0f, value2, 0f, result);
            return result;
        }


        /// <summary>
        /// Returns 2 raised to the specified power.
        /// Provides at least 6 decimals of accuracy.
        /// </summary>
        internal static TFloat Pow2(TFloat x)
        {
            if (x.RawValue == 0)
            {
                return TFloat.One;
            }

            // Avoid negative arguments by exploiting that exp(-x) = 1/exp(x).
            bool neg = x.RawValue < 0;
            if (neg)
            {
                x = -x;
            }

            if (x == TFloat.One)
            {
                return neg ? TFloat.One / (TFloat)2 : (TFloat)2;
            }
            if (x >= TFloat.Log2Max)
            {
                return neg ? TFloat.One / TFloat.MaxValue : TFloat.MaxValue;
            }
            if (x <= TFloat.Log2Min)
            {
                return neg ? TFloat.MaxValue : TFloat.Zero;
            }

            /* The algorithm is based on the power series for exp(x):
             * http://en.wikipedia.org/wiki/Exponential_function#Formal_definition
             * 
             * From term n, we get term n+1 by multiplying with x/n.
             * When the sum term drops to zero, we can stop summing.
             */

            int integerPart = (int)Floor(x);
            // Take fractional part of exponent
            x = TFloat.FromRaw(x.RawValue & 0x00000000FFFFFFFF);

            var result = TFloat.One;
            var term = TFloat.One;
            int i = 1;
            while (term.RawValue != 0)
            {
                term = TFloat.FastMul(TFloat.FastMul(x, term), TFloat.Ln2) / (TFloat)i;
                result += term;
                i++;
            }

            result = TFloat.FromRaw(result.RawValue << integerPart);
            if (neg)
            {
                result = TFloat.One / result;
            }

            return result;
        }

        /// <summary>
        /// Returns the base-2 logarithm of a specified number.
        /// Provides at least 9 decimals of accuracy.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">
        /// The argument was non-positive
        /// </exception>
        internal static TFloat Log2(TFloat x)
        {
            if (x.RawValue <= 0)
            {
                throw new ArgumentOutOfRangeException("Non-positive value passed to Ln", "x");
            }

            // This implementation is based on Clay. S. Turner's fast binary logarithm
            // algorithm (C. S. Turner,  "A Fast Binary Logarithm Algorithm", IEEE Signal
            //     Processing Mag., pp. 124,140, Sep. 2010.)

            long b = 1U << (TFloat.FRACTIONAL_PLACES - 1);
            long y = 0;

            long rawX = x.RawValue;
            while (rawX < TFloat.ONE)
            {
                rawX <<= 1;
                y -= TFloat.ONE;
            }

            while (rawX >= (TFloat.ONE << 1))
            {
                rawX >>= 1;
                y += TFloat.ONE;
            }

            var z = TFloat.FromRaw(rawX);

            for (int i = 0; i < TFloat.FRACTIONAL_PLACES; i++)
            {
                z = TFloat.FastMul(z, z);
                if (z.RawValue >= (TFloat.ONE << 1))
                {
                    z = TFloat.FromRaw(z.RawValue >> 1);
                    y += b;
                }
                b >>= 1;
            }

            return TFloat.FromRaw(y);
        }

        /// <summary>
        /// Returns the natural logarithm of a specified number.
        /// Provides at least 7 decimals of accuracy.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">
        /// The argument was non-positive
        /// </exception>
        public static TFloat Ln(TFloat x)
        {
            return TFloat.FastMul(Log2(x), TFloat.Ln2);
        }

        /// <summary>
        /// Returns a specified number raised to the specified power.
        /// Provides about 5 digits of accuracy for the result.
        /// </summary>
        /// <exception cref="DivideByZeroException">
        /// The base was zero, with a negative exponent
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// The base was negative, with a non-zero exponent
        /// </exception>
        public static TFloat Pow(TFloat b, TFloat exp)
        {
            if (b == TFloat.One)
            {
                return TFloat.One;
            }

            if (exp.RawValue == 0)
            {
                return TFloat.One;
            }

            if (b.RawValue == 0)
            {
                if (exp.RawValue < 0)
                {
                    //throw new DivideByZeroException();
                    return TFloat.MaxValue;
                }
                return TFloat.Zero;
            }

            TFloat log2 = Log2(b);
            return Pow2(exp * log2);
        }

        public static TFloat MoveTowards(TFloat current, TFloat target, TFloat maxDelta)
        {
            if (Abs(target - current) <= maxDelta)
                return target;
            return (current + (Sign(target - current)) * maxDelta);
        }

        public static TFloat Repeat(TFloat t, TFloat length)
        {
            return (t - (Floor(t / length) * length));
        }

        public static TFloat DeltaAngle(TFloat current, TFloat target)
        {
            TFloat num = Repeat(target - current, (TFloat)360f);
            if (num > (TFloat)180f)
            {
                num -= (TFloat)360f;
            }
            return num;
        }

        public static TFloat MoveTowardsAngle(TFloat current, TFloat target, float maxDelta)
        {
            target = current + DeltaAngle(current, target);
            return MoveTowards(current, target, maxDelta);
        }

        public static TFloat SmoothDamp(TFloat current, TFloat target, ref TFloat currentVelocity, TFloat smoothTime, TFloat maxSpeed)
        {
            TFloat deltaTime = TFloat.EN2;
            return SmoothDamp(current, target, ref currentVelocity, smoothTime, maxSpeed, deltaTime);
        }

        public static TFloat SmoothDamp(TFloat current, TFloat target, ref TFloat currentVelocity, TFloat smoothTime)
        {
            TFloat deltaTime = TFloat.EN2;
            TFloat positiveInfinity = -TFloat.MaxValue;
            return SmoothDamp(current, target, ref currentVelocity, smoothTime, positiveInfinity, deltaTime);
        }

        public static TFloat SmoothDamp(TFloat current, TFloat target, ref TFloat currentVelocity, TFloat smoothTime, TFloat maxSpeed, TFloat deltaTime)
        {
            smoothTime = Max(TFloat.EN4, smoothTime);
            TFloat num = (TFloat)2f / smoothTime;
            TFloat num2 = num * deltaTime;
            TFloat num3 = TFloat.One / (((TFloat.One + num2) + (((TFloat)0.48f * num2) * num2)) + ((((TFloat)0.235f * num2) * num2) * num2));
            TFloat num4 = current - target;
            TFloat num5 = target;
            TFloat max = maxSpeed * smoothTime;
            num4 = Clamp(num4, -max, max);
            target = current - num4;
            TFloat num7 = (currentVelocity + (num * num4)) * deltaTime;
            currentVelocity = (currentVelocity - (num * num7)) * num3;
            TFloat num8 = target + ((num4 + num7) * num3);
            if (((num5 - current) > TFloat.Zero) == (num8 > num5))
            {
                num8 = num5;
                currentVelocity = (num8 - num5) / deltaTime;
            }
            return num8;
        }

        public static int NextPowerOfTwo(int value)
        {
            value--;
            value |= value >> 16;
            value |= value >> 8;
            value |= value >> 4;
            value |= value >> 2;
            value |= value >> 1;
            return value + 1;
        }
        public static int ClosestPowerOfTwo(int value)
        {
            int num = NextPowerOfTwo(value);
            int num2 = num >> 1;
            if (value - num2 < num - value)
            {
                return num2;
            }

            return num;
        }

        public static bool IsPowerOfTwo(int value)
        {
            return (value & (value - 1)) == 0;
        }
    }
}
