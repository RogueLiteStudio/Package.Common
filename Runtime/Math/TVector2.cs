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

namespace TrueSync
{

    [Serializable]
    public struct TVector2 : IEquatable<TVector2>
    {

        private static TVector2 zeroVector = new TVector2(0, 0);
        private static TVector2 oneVector = new TVector2(1, 1);

        private static TVector2 rightVector = new TVector2(1, 0);
        private static TVector2 leftVector = new TVector2(-1, 0);

        private static TVector2 upVector = new TVector2(0, 1);
        private static TVector2 downVector = new TVector2(0, -1);


        public TFloat x;
        public TFloat y;



        public static TVector2 zero
        {
            get { return zeroVector; }
        }

        public static TVector2 one
        {
            get { return oneVector; }
        }

        public static TVector2 right
        {
            get { return rightVector; }
        }

        public static TVector2 left
        {
            get { return leftVector; }
        }

        public static TVector2 up
        {
            get { return upVector; }
        }

        public static TVector2 down
        {
            get { return downVector; }
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

        public void Set(TFloat x, TFloat y)
        {
            this.x = x;
            this.y = y;
        }


        public static void Reflect(ref TVector2 vector, ref TVector2 normal, out TVector2 result)
        {
            TFloat dot = Dot(vector, normal);
            result.x = vector.x - ((2f * dot) * normal.x);
            result.y = vector.y - ((2f * dot) * normal.y);
        }

        public static TVector2 Reflect(TVector2 vector, TVector2 normal)
        {
            TVector2 result;
            Reflect(ref vector, ref normal, out result);
            return result;
        }

        public static TVector2 Add(TVector2 value1, TVector2 value2)
        {
            value1.x += value2.x;
            value1.y += value2.y;
            return value1;
        }

        public static void Add(ref TVector2 value1, ref TVector2 value2, out TVector2 result)
        {
            result.x = value1.x + value2.x;
            result.y = value1.y + value2.y;
        }

        public static TVector2 Barycentric(TVector2 value1, TVector2 value2, TVector2 value3, TFloat amount1, TFloat amount2)
        {
            return new TVector2(
                TMath.Barycentric(value1.x, value2.x, value3.x, amount1, amount2),
                TMath.Barycentric(value1.y, value2.y, value3.y, amount1, amount2));
        }

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

        /// <summary>
        /// Returns FP precison distanve between two vectors
        /// </summary>
        /// <param name="value1">
        /// A <see cref="TVector2"/>
        /// </param>
        /// <param name="value2">
        /// A <see cref="TVector2"/>
        /// </param>
        /// <returns>
        /// A <see cref="System.Single"/>
        /// </returns>
        public static TFloat Distance(TVector2 value1, TVector2 value2)
        {
            TFloat result;
            DistanceSquared(ref value1, ref value2, out result);
            return (TFloat)TFloat.Sqrt(result);
        }


        public static void Distance(ref TVector2 value1, ref TVector2 value2, out TFloat result)
        {
            DistanceSquared(ref value1, ref value2, out result);
            result = (TFloat)TFloat.Sqrt(result);
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

        /// <summary>
        /// Devide first vector with the secund vector
        /// </summary>
        /// <param name="value1">
        /// A <see cref="TVector2"/>
        /// </param>
        /// <param name="value2">
        /// A <see cref="TVector2"/>
        /// </param>
        /// <returns>
        /// A <see cref="TVector2"/>
        /// </returns>
        public static TVector2 Divide(TVector2 value1, TVector2 value2)
        {
            value1.x /= value2.x;
            value1.y /= value2.y;
            return value1;
        }

        public static void Divide(ref TVector2 value1, ref TVector2 value2, out TVector2 result)
        {
            result.x = value1.x / value2.x;
            result.y = value1.y / value2.y;
        }

        public static TVector2 Divide(TVector2 value1, TFloat divider)
        {
            TFloat factor = 1 / divider;
            value1.x *= factor;
            value1.y *= factor;
            return value1;
        }

        public static void Divide(ref TVector2 value1, TFloat divider, out TVector2 result)
        {
            TFloat factor = 1 / divider;
            result.x = value1.x * factor;
            result.y = value1.y * factor;
        }

        public static TFloat Dot(TVector2 value1, TVector2 value2)
        {
            return value1.x * value2.x + value1.y * value2.y;
        }

        public static void Dot(ref TVector2 value1, ref TVector2 value2, out TFloat result)
        {
            result = value1.x * value2.x + value1.y * value2.y;
        }

        public override bool Equals(object obj)
        {
            return (obj is TVector2) ? this == ((TVector2)obj) : false;
        }

        public bool Equals(TVector2 other)
        {
            return this == other;
        }

        public override int GetHashCode()
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

        public TFloat magnitude
        {
            get
            {
                TFloat result;
                DistanceSquared(ref this, ref zeroVector, out result);
                return TFloat.Sqrt(result);
            }
        }

        public static TVector2 ClampMagnitude(TVector2 vector, TFloat maxLength)
        {
            return Normalize(vector) * maxLength;
        }

        public TFloat LengthSquared()
        {
            TFloat result;
            DistanceSquared(ref this, ref zeroVector, out result);
            return result;
        }

        public static TVector2 Lerp(TVector2 value1, TVector2 value2, TFloat amount)
        {
            amount = TMath.Clamp(amount, 0, 1);

            return new TVector2(
                TMath.Lerp(value1.x, value2.x, amount),
                TMath.Lerp(value1.y, value2.y, amount));
        }

        public static TVector2 LerpUnclamped(TVector2 value1, TVector2 value2, TFloat amount)
        {
            return new TVector2(
                TMath.Lerp(value1.x, value2.x, amount),
                TMath.Lerp(value1.y, value2.y, amount));
        }

        public static void LerpUnclamped(ref TVector2 value1, ref TVector2 value2, TFloat amount, out TVector2 result)
        {
            result = new TVector2(
                TMath.Lerp(value1.x, value2.x, amount),
                TMath.Lerp(value1.y, value2.y, amount));
        }

        public static TVector2 Max(TVector2 value1, TVector2 value2)
        {
            return new TVector2(
                TMath.Max(value1.x, value2.x),
                TMath.Max(value1.y, value2.y));
        }

        public static void Max(ref TVector2 value1, ref TVector2 value2, out TVector2 result)
        {
            result.x = TMath.Max(value1.x, value2.x);
            result.y = TMath.Max(value1.y, value2.y);
        }

        public static TVector2 Min(TVector2 value1, TVector2 value2)
        {
            return new TVector2(
                TMath.Min(value1.x, value2.x),
                TMath.Min(value1.y, value2.y));
        }

        public static void Min(ref TVector2 value1, ref TVector2 value2, out TVector2 result)
        {
            result.x = TMath.Min(value1.x, value2.x);
            result.y = TMath.Min(value1.y, value2.y);
        }

        public void Scale(TVector2 other)
        {
            this.x = x * other.x;
            this.y = y * other.y;
        }

        public static TVector2 Scale(TVector2 value1, TVector2 value2)
        {
            TVector2 result;
            result.x = value1.x * value2.x;
            result.y = value1.y * value2.y;

            return result;
        }

        public static TVector2 Multiply(TVector2 value1, TVector2 value2)
        {
            value1.x *= value2.x;
            value1.y *= value2.y;
            return value1;
        }

        public static TVector2 Multiply(TVector2 value1, TFloat scaleFactor)
        {
            value1.x *= scaleFactor;
            value1.y *= scaleFactor;
            return value1;
        }

        public static void Multiply(ref TVector2 value1, TFloat scaleFactor, out TVector2 result)
        {
            result.x = value1.x * scaleFactor;
            result.y = value1.y * scaleFactor;
        }

        public static void Multiply(ref TVector2 value1, ref TVector2 value2, out TVector2 result)
        {
            result.x = value1.x * value2.x;
            result.y = value1.y * value2.y;
        }

        public static TVector2 Negate(TVector2 value)
        {
            value.x = -value.x;
            value.y = -value.y;
            return value;
        }

        public static void Negate(ref TVector2 value, out TVector2 result)
        {
            result.x = -value.x;
            result.y = -value.y;
        }

        public void Normalize()
        {
            Normalize(ref this, out this);
        }

        public static TVector2 Normalize(TVector2 value)
        {
            Normalize(ref value, out value);
            return value;
        }

        public TVector2 normalized
        {
            get
            {
                TVector2 result;
                TVector2.Normalize(ref this, out result);

                return result;
            }
        }

        public static void Normalize(ref TVector2 value, out TVector2 result)
        {
            TFloat factor;
            DistanceSquared(ref value, ref zeroVector, out factor);
            factor = 1f / (TFloat)TFloat.Sqrt(factor);
            result.x = value.x * factor;
            result.y = value.y * factor;
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

        public static TVector2 Subtract(TVector2 value1, TVector2 value2)
        {
            value1.x -= value2.x;
            value1.y -= value2.y;
            return value1;
        }

        public static void Subtract(ref TVector2 value1, ref TVector2 value2, out TVector2 result)
        {
            result.x = value1.x - value2.x;
            result.y = value1.y - value2.y;
        }

        public static TFloat Angle(TVector2 a, TVector2 b)
        {
            return TFloat.Acos(a.normalized * b.normalized) * TFloat.Rad2Deg;
        }

        public TVector3 ToTSVector()
        {
            return new TVector3(x, y, 0);
        }

        public override string ToString()
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
            return TVector2.Dot(value1, value2);
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
            TFloat factor = 1 / divider;
            value1.x *= factor;
            value1.y *= factor;
            return value1;
        }

    }
}