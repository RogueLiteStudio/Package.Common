#region License

/*
MIT License
Copyright © 2006 The Mono.Xna Team

All rights reserved.

Authors
 * Alan McGovern

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*/

#endregion License

using System;
using System.Runtime.CompilerServices;

namespace TrueSync
{

    [Serializable]
    public struct TVector2 : IEquatable<TVector2>
    {

        private static readonly TVector2 zeroVector = new TVector2(TFloat.Zero, TFloat.Zero);
        private static readonly TVector2 oneVector = new TVector2(TFloat.One, TFloat.One);

        private static readonly TVector2 rightVector = new TVector2(TFloat.One, TFloat.Zero);
        private static readonly TVector2 leftVector = new TVector2(-TFloat.One, TFloat.Zero);

        private static readonly TVector2 upVector = new TVector2(TFloat.Zero, TFloat.One);
        private static readonly TVector2 downVector = new TVector2(TFloat.Zero, -TFloat.One);
        private static readonly TVector2 positiveInfinityVector = new TVector2(TFloat.PositiveInfinity, TFloat.PositiveInfinity);

        private static readonly TVector2 negativeInfinityVector = new TVector2(TFloat.NegativeInfinity, TFloat.NegativeInfinity);

        public TFloat x;
        public TFloat y;

        public TFloat this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                return index switch
                {
                    0 => x,
                    1 => y,
                    _ => throw new IndexOutOfRangeException("Invalid Vector2 index!"),
                };
            }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                switch (index)
                {
                    case 0:
                        x = value;
                        break;
                    case 1:
                        y = value;
                        break;
                    default:
                        throw new IndexOutOfRangeException("Invalid Vector2 index!");
                }
            }
        }

        public TVector2 normalized
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                TVector2 result = new TVector2(x, y);
                result.Normalize();
                return result;
            }
        }

        public TFloat magnitude
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                return TMath.Sqrt(x * x + y * y);
            }
        }
        public TFloat sqrMagnitude
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                return x * x + y * y;
            }
        }

        public static TVector2 zero
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return zeroVector; }
        }

        public static TVector2 one
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return oneVector; }
        }

        public static TVector2 right
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return rightVector; }
        }

        public static TVector2 left
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return leftVector; }
        }

        public static TVector2 up
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return upVector; }
        }

        public static TVector2 down
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return downVector; }
        }
        public static TVector2 positiveInfinity
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                return positiveInfinityVector;
            }
        }
        public static TVector2 negativeInfinity
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                return negativeInfinityVector;
            }
        }

        /// <summary>
        /// Constructor foe standard 2D vector.
        /// </summary>
        /// <param name="x">
        /// A <see cref="System.Single"/>
        /// </param>
        /// <param name="y">
        /// A <see cref="System.Single"/>
        /// </param>
        public TVector2(TFloat x, TFloat y)
        {
            this.x = x;
            this.y = y;
        }

        /// <summary>
        /// Constructor for "square" vector.
        /// </summary>
        /// <param name="value">
        /// A <see cref="System.Single"/>
        /// </param>
        public TVector2(TFloat value)
        {
            x = value;
            y = value;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Set(TFloat x, TFloat y)
        {
            this.x = x;
            this.y = y;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TVector2 Lerp(TVector2 value1, TVector2 value2, TFloat amount)
        {
            amount = TMath.Clamp(amount, TFloat.Zero, TFloat.One);

            return new TVector2(
                TMath.Lerp(value1.x, value2.x, amount),
                TMath.Lerp(value1.y, value2.y, amount));
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TVector2 LerpUnclamped(TVector2 value1, TVector2 value2, TFloat amount)
        {
            return new TVector2(
                TMath.Lerp(value1.x, value2.x, amount),
                TMath.Lerp(value1.y, value2.y, amount));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TVector2 MoveTowards(TVector2 current, TVector2 target, TFloat maxDistanceDelta)
        {
            TFloat num = target.x - current.x;
            TFloat num2 = target.y - current.y;
            TFloat num3 = num * num + num2 * num2;
            if (num3 == TFloat.Zero || (maxDistanceDelta >= TFloat.Zero && num3 <= maxDistanceDelta * maxDistanceDelta))
            {
                return target;
            }

            TFloat num4 = TMath.Sqrt(num3);
            return new TVector2(current.x + num / num4 * maxDistanceDelta, current.y + num2 / num4 * maxDistanceDelta);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Scale(TVector2 other)
        {
            x *= other.x;
            y *= other.y;
        }

        public static TVector2 Scale(TVector2 value1, TVector2 value2)
        {
            TVector2 result;
            result.x = value1.x * value2.x;
            result.y = value1.y * value2.y;

            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Normalize()
        {
            TFloat num = magnitude;
            if (num > TFloat.EN5)
            {
                this /= num;
            }
            else
            {
                this = zero;
            }
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TVector2 Reflect(TVector2 inDirection, TVector2 inNormal)
        {
            TFloat num = -(TFloat)2 * Dot(inNormal, inDirection);
            return new TVector2(num * inNormal.x + inDirection.x, num * inNormal.y + inDirection.y);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TVector2 Perpendicular(TVector2 inDirection)
        {
            return new TVector2( - inDirection.y, inDirection.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TFloat Dot(TVector2 value1, TVector2 value2)
        {
            return value1.x * value2.x + value1.y * value2.y;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TFloat Angle(TVector2 from, TVector2 to)
        {
            TFloat num = TMath.Sqrt(from.sqrMagnitude * to.sqrMagnitude);
            if (num < TFloat.EN5)
            {
                return TFloat.Zero;
            }

            TFloat num2 = TMath.Clamp(Dot(from, to) / num, -TFloat.One, TFloat.One);
            return TMath.Acos(num2) * TFloat.Rad2Deg;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TFloat SignedAngle(TVector2 from, TVector2 to)
        {
            TFloat num = Angle(from, to);
            TFloat num2 = TMath.Sign(from.x * to.y - from.y * to.x);
            return num * num2;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TFloat Distance(TVector2 a, TVector2 b)
        {
            TFloat num = a.x - b.x;
            TFloat num2 = a.y - b.y;
            return TMath.Sqrt(num * num + num2 * num2);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TVector2 ClampMagnitude(TVector2 vector, TFloat maxLength)
        {
            TFloat num = vector.sqrMagnitude;
            if (num > maxLength * maxLength)
            {
                TFloat num2 = TMath.Sqrt(num);
                TFloat num3 = vector.x / num2;
                TFloat num4 = vector.y / num2;
                return new TVector2(num3 * maxLength, num4 * maxLength);
            }

            return vector;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TFloat SqrMagnitude(TVector2 a)
        {
            return a.x * a.x + a.y * a.y;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly TFloat SqrMagnitude()
        {
            return x * x + y * y;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TVector2 Max(TVector2 value1, TVector2 value2)
        {
            return new TVector2(
                TMath.Max(value1.x, value2.x),
                TMath.Max(value1.y, value2.y));
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TVector2 Min(TVector2 value1, TVector2 value2)
        {
            return new TVector2(
                TMath.Min(value1.x, value2.x),
                TMath.Min(value1.y, value2.y));
        }

        public static TVector2 SmoothDamp(TVector2 current, TVector2 target, ref TVector2 currentVelocity, TFloat smoothTime, TFloat maxSpeed, TFloat deltaTime)
        {
            smoothTime = TMath.Max(TFloat.EN4, smoothTime);
            TFloat num = 2 / smoothTime;
            TFloat num2 = num * deltaTime;
            TFloat num3 = TFloat.One / (TFloat.One + num2 + 0.48f * num2 * num2 + 0.235f * num2 * num2 * num2);
            TFloat num4 = current.x - target.x;
            TFloat num5 = current.y - target.y;
            TVector2 vector = target;
            TFloat num6 = maxSpeed * smoothTime;
            TFloat num7 = num6 * num6;
            TFloat num8 = num4 * num4 + num5 * num5;
            if (num8 > num7)
            {
                TFloat num9 = TMath.Sqrt(num8);
                num4 = num4 / num9 * num6;
                num5 = num5 / num9 * num6;
            }

            target.x = current.x - num4;
            target.y = current.y - num5;
            TFloat num10 = (currentVelocity.x + num * num4) * deltaTime;
            TFloat num11 = (currentVelocity.y + num * num5) * deltaTime;
            currentVelocity.x = (currentVelocity.x - num * num10) * num3;
            currentVelocity.y = (currentVelocity.y - num * num11) * num3;
            TFloat num12 = target.x + (num4 + num10) * num3;
            TFloat num13 = target.y + (num5 + num11) * num3;
            TFloat num14 = vector.x - current.x;
            TFloat num15 = vector.y - current.y;
            TFloat num16 = num12 - vector.x;
            TFloat num17 = num13 - vector.y;
            if (num14 * num16 + num15 * num17 > TFloat.Zero)
            {
                num12 = vector.x;
                num13 = vector.y;
                currentVelocity.x = (num12 - vector.x) / deltaTime;
                currentVelocity.y = (num13 - vector.y) / deltaTime;
            }

            return new TVector2(num12, num13);
        }


        public static TVector2 Barycentric(TVector2 value1, TVector2 value2, TVector2 value3, TFloat amount1, TFloat amount2)
        {
            return new TVector2(
                TMath.Barycentric(value1.x, value2.x, value3.x, amount1, amount2),
                TMath.Barycentric(value1.y, value2.y, value3.y, amount1, amount2));
        }
        //计算重心
        public static void Barycentric(ref TVector2 value1, ref TVector2 value2, ref TVector2 value3, TFloat amount1,
                                       TFloat amount2, out TVector2 result)
        {
            result = new TVector2(
                TMath.Barycentric(value1.x, value2.x, value3.x, amount1, amount2),
                TMath.Barycentric(value1.y, value2.y, value3.y, amount1, amount2));
        }

        public static TVector2 CatmullRom(TVector2 value1, TVector2 value2, TVector2 value3, TVector2 value4, TFloat amount)
        {
            return new TVector2(
                TMath.CatmullRom(value1.x, value2.x, value3.x, value4.x, amount),
                TMath.CatmullRom(value1.y, value2.y, value3.y, value4.y, amount));
        }

        public static void CatmullRom(ref TVector2 value1, ref TVector2 value2, ref TVector2 value3, ref TVector2 value4,
                                      TFloat amount, out TVector2 result)
        {
            result = new TVector2(
                TMath.CatmullRom(value1.x, value2.x, value3.x, value4.x, amount),
                TMath.CatmullRom(value1.y, value2.y, value3.y, value4.y, amount));
        }

        public static TVector2 Clamp(TVector2 value1, TVector2 min, TVector2 max)
        {
            return new TVector2(
                TMath.Clamp(value1.x, min.x, max.x),
                TMath.Clamp(value1.y, min.y, max.y));
        }

        public static void Clamp(ref TVector2 value1, ref TVector2 min, ref TVector2 max, out TVector2 result)
        {
            result = new TVector2(
                TMath.Clamp(value1.x, min.x, max.x),
                TMath.Clamp(value1.y, min.y, max.y));
        }

        public static TFloat DistanceSquared(TVector2 value1, TVector2 value2)
        {
            TFloat result;
            DistanceSquared(ref value1, ref value2, out result);
            return result;
        }

        public static void DistanceSquared(ref TVector2 value1, ref TVector2 value2, out TFloat result)
        {
            result = (value1.x - value2.x) * (value1.x - value2.x) + (value1.y - value2.y) * (value1.y - value2.y);
        }

        public override readonly bool Equals(object obj)
        {
            return (obj is TVector2) ? this == ((TVector2)obj) : false;
        }

        public readonly bool Equals(TVector2 other)
        {
            return this == other;
        }

        public override readonly int GetHashCode()
        {
            return (int)(x + y);
        }

        public static TVector2 Hermite(TVector2 value1, TVector2 tangent1, TVector2 value2, TVector2 tangent2, TFloat amount)
        {
            TVector2 result = new TVector2();
            Hermite(ref value1, ref tangent1, ref value2, ref tangent2, amount, out result);
            return result;
        }

        public static void Hermite(ref TVector2 value1, ref TVector2 tangent1, ref TVector2 value2, ref TVector2 tangent2,
                                   TFloat amount, out TVector2 result)
        {
            result.x = TMath.Hermite(value1.x, tangent1.x, value2.x, tangent2.x, amount);
            result.y = TMath.Hermite(value1.y, tangent1.y, value2.y, tangent2.y, amount);
        }


        public static TVector2 Negate(TVector2 value)
        {
            value.x = -value.x;
            value.y = -value.y;
            return value;
        }


        public static TVector2 SmoothStep(TVector2 value1, TVector2 value2, TFloat amount)
        {
            return new TVector2(
                TMath.SmoothStep(value1.x, value2.x, amount),
                TMath.SmoothStep(value1.y, value2.y, amount));
        }

        public static void SmoothStep(ref TVector2 value1, ref TVector2 value2, TFloat amount, out TVector2 result)
        {
            result = new TVector2(
                TMath.SmoothStep(value1.x, value2.x, amount),
                TMath.SmoothStep(value1.y, value2.y, amount));
        }

        public readonly override string ToString()
        {
            return string.Format("({0:f1}, {1:f1})", x.AsFloat(), y.AsFloat());
        }

        public static TVector2 operator -(TVector2 value)
        {
            value.x = -value.x;
            value.y = -value.y;
            return value;
        }

        public static bool operator ==(TVector2 value1, TVector2 value2)
        {
            return value1.x == value2.x && value1.y == value2.y;
        }

        public static bool operator !=(TVector2 value1, TVector2 value2)
        {
            return value1.x != value2.x || value1.y != value2.y;
        }

        public static TVector2 operator +(TVector2 value1, TVector2 value2)
        {
            value1.x += value2.x;
            value1.y += value2.y;
            return value1;
        }

        public static TVector2 operator -(TVector2 value1, TVector2 value2)
        {
            value1.x -= value2.x;
            value1.y -= value2.y;
            return value1;
        }

        public static TFloat operator *(TVector2 value1, TVector2 value2)
        {
            return Dot(value1, value2);
        }

        public static TVector2 operator *(TVector2 value, TFloat scaleFactor)
        {
            value.x *= scaleFactor;
            value.y *= scaleFactor;
            return value;
        }

        public static TVector2 operator *(TFloat scaleFactor, TVector2 value)
        {
            value.x *= scaleFactor;
            value.y *= scaleFactor;
            return value;
        }

        public static TVector2 operator /(TVector2 value1, TVector2 value2)
        {
            value1.x /= value2.x;
            value1.y /= value2.y;
            return value1;
        }

        public static TVector2 operator /(TVector2 value1, TFloat divider)
        {
            TFloat factor = TFloat.One / divider;
            value1.x *= factor;
            value1.y *= factor;
            return value1;
        }

    }
}