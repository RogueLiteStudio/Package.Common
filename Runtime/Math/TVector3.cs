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

using System;
using System.Runtime.CompilerServices;

namespace TrueSync
{
    /// <summary>
    /// A vector structure.
    /// </summary>
    [Serializable]
    public struct TVector3
    {

        private static TFloat ZeroEpsilonSq = TMath.Epsilon;
        internal static TVector3 InternalZero;
        internal static TVector3 Arbitrary;

        /// <summary>The X component of the vector.</summary>
        public TFloat x;
        /// <summary>The Y component of the vector.</summary>
        public TFloat y;
        /// <summary>The Z component of the vector.</summary>
        public TFloat z;
        private static readonly TVector3 zeroVector = new TVector3(TFloat.Zero, TFloat.Zero, TFloat.Zero);

        private static readonly TVector3 oneVector = new TVector3(TFloat.One, TFloat.One, TFloat.One);

        private static readonly TVector3 upVector = new TVector3(TFloat.Zero, TFloat.One, TFloat.Zero);

        private static readonly TVector3 downVector = new TVector3(TFloat.Zero, -TFloat.One, TFloat.Zero);

        private static readonly TVector3 leftVector = new TVector3(-TFloat.One, TFloat.Zero, TFloat.Zero);

        private static readonly TVector3 rightVector = new TVector3(TFloat.One, TFloat.Zero, TFloat.Zero);

        private static readonly TVector3 forwardVector = new TVector3(TFloat.Zero, TFloat.Zero, TFloat.One);

        private static readonly TVector3 backVector = new TVector3(TFloat.Zero, TFloat.Zero, -TFloat.One);

        private static readonly TVector3 positiveInfinityVector = new TVector3(TFloat.PositiveInfinity, TFloat.PositiveInfinity, TFloat.PositiveInfinity);

        private static readonly TVector3 negativeInfinityVector = new TVector3(TFloat.NegativeInfinity, TFloat.NegativeInfinity, TFloat.NegativeInfinity);

        public TFloat this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                return index switch
                {
                    0 => x,
                    1 => y,
                    2 => z,
                    _ => throw new IndexOutOfRangeException("Invalid Vector3 index!"),
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
                    case 2:
                        z = value;
                        break;
                    default:
                        throw new IndexOutOfRangeException("Invalid Vector3 index!");
                }
            }
        }

        /// <summary>
        /// A vector with components (0,0,0);
        /// </summary>
        public static TVector3 zero
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                return zeroVector;
            }
        }
        /// <summary>
        /// A vector with components (-1,0,0);
        /// </summary>
        public static TVector3 left
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                return leftVector;
            }
        }
        /// <summary>
        /// A vector with components (1,0,0);
        /// </summary>
        public static TVector3 right
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                return rightVector;
            }
        }
        /// <summary>
        /// A vector with components (0,1,0);
        /// </summary>
        public static TVector3 up
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                return upVector;
            }
        }
        /// <summary>
        /// A vector with components (0,-1,0);
        /// </summary>
        public static TVector3 down
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                return downVector;
            }
        }
        /// <summary>
        /// A vector with components (0,0,-1);
        /// </summary>
        public static TVector3 back
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                return backVector;
            }
        }
        /// <summary>
        /// A vector with components (0,0,1);
        /// </summary>
        public static TVector3 forward
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                return forwardVector;
            }
        }
        /// <summary>
        /// A vector with components (1,1,1);
        /// </summary>
        public static TVector3 one
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                return oneVector;
            }
        }
        public static TVector3 positiveInfinity
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                return positiveInfinityVector;
            }
        }
        public static TVector3 negativeInfinity
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                return negativeInfinityVector;
            }
        }

        public static TVector3 Abs(TVector3 other)
        {
            return new TVector3(TFloat.Abs(other.x), TFloat.Abs(other.y), TFloat.Abs(other.z));
        }

        /// <summary>
        /// Gets the squared length of the vector.
        /// </summary>
        /// <returns>Returns the squared length of the vector.</returns>
        public TFloat sqrMagnitude
        {
            get
            {
                return (x * x) + (y * y) + (z * z);
            }
        }

        /// <summary>
        /// Gets the length of the vector.
        /// </summary>
        /// <returns>Returns the length of the vector.</returns>
        public TFloat magnitude
        {
            get
            {
                TFloat num = (x * x) + (y * y) + (z * z);
                return TFloat.Sqrt(num);
            }
        }

        public TVector3 normalized
        {
            get
            {
                TVector3 result = new TVector3(x, y, z);
                result.Normalize();

                return result;
            }
        }

        public TVector3(int x, int y, int z)
        {
            this.x = (TFloat)x;
            this.y = (TFloat)y;
            this.z = (TFloat)z;
        }

        public TVector3(TFloat x, TFloat y, TFloat z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
        
        public static TVector3 Slerp(TVector3 from, TVector3 to, TFloat t)
        {
            TFloat dot = Dot(from, to);
            TMath.Clamp(dot, -1.0f, 1.0f);
            TFloat theta = TMath.Acos(dot) * t;
            TVector3 RelativeVec = to - from * dot;
            RelativeVec.Normalize();
            return ((from * TMath.Cos(theta)) + (RelativeVec * TMath.Sin(theta)));
        }

        public void Set(TFloat x, TFloat y, TFloat z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public TVector3(TFloat xyz)
        {
            x = xyz;
            y = xyz;
            z = xyz;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TVector3 Lerp(TVector3 a, TVector3 b, TFloat t)
        {
            t = TMath.Clamp(t, TFloat.Zero, TFloat.One);
            return new TVector3(a.x + (b.x - a.x) * t, a.y + (b.y - a.y) * t, a.z + (b.z - a.z) * t);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TVector3 LerpUnclamped(TVector3 a, TVector3 b, TFloat t)
        {
            return new TVector3(a.x + (b.x - a.x) * t, a.y + (b.y - a.y) * t, a.z + (b.z - a.z) * t);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TVector3 MoveTowards(TVector3 current, TVector3 target, TFloat maxDistanceDelta)
        {
            TFloat num = target.x - current.x;
            TFloat num2 = target.y - current.y;
            TFloat num3 = target.z - current.z;
            TFloat num4 = num * num + num2 * num2 + num3 * num3;
            if (num4 == TFloat.Zero || (maxDistanceDelta >= TFloat.Zero && num4 <= maxDistanceDelta * maxDistanceDelta))
            {
                return target;
            }

            TFloat num5 = TMath.Sqrt(num4);
            return new TVector3(current.x + num / num5 * maxDistanceDelta, current.y + num2 / num5 * maxDistanceDelta, current.z + num3 / num5 * maxDistanceDelta);
        }

        public static TVector3 SmoothDamp(TVector3 current, TVector3 target, ref TVector3 currentVelocity, TFloat smoothTime, TFloat maxSpeed, TFloat deltaTime)
        {
            smoothTime = TMath.Max(TFloat.EN4, smoothTime);
            TFloat num4 = 2f / smoothTime;
            TFloat num5 = num4 * deltaTime;
            TFloat num6 = 1f / (1f + num5 + 0.48f * num5 * num5 + 0.235f * num5 * num5 * num5);
            TFloat num7 = current.x - target.x;
            TFloat num8 = current.y - target.y;
            TFloat num9 = current.z - target.z;
            TVector3 vector = target;
            TFloat num10 = maxSpeed * smoothTime;
            TFloat num11 = num10 * num10;
            TFloat num12 = num7 * num7 + num8 * num8 + num9 * num9;
            if (num12 > num11)
            {
                TFloat num13 = TMath.Sqrt(num12);
                num7 = num7 / num13 * num10;
                num8 = num8 / num13 * num10;
                num9 = num9 / num13 * num10;
            }

            target.x = current.x - num7;
            target.y = current.y - num8;
            target.z = current.z - num9;
            TFloat num14 = (currentVelocity.x + num4 * num7) * deltaTime;
            TFloat num15 = (currentVelocity.y + num4 * num8) * deltaTime;
            TFloat num16 = (currentVelocity.z + num4 * num9) * deltaTime;
            currentVelocity.x = (currentVelocity.x - num4 * num14) * num6;
            currentVelocity.y = (currentVelocity.y - num4 * num15) * num6;
            currentVelocity.z = (currentVelocity.z - num4 * num16) * num6;
            TFloat num = target.x + (num7 + num14) * num6;
            TFloat num2 = target.y + (num8 + num15) * num6;
            TFloat num3 = target.z + (num9 + num16) * num6;
            TFloat num17 = vector.x - current.x;
            TFloat num18 = vector.y - current.y;
            TFloat num19 = vector.z - current.z;
            TFloat num20 = num - vector.x;
            TFloat num21 = num2 - vector.y;
            TFloat num22 = num3 - vector.z;
            if (num17 * num20 + num18 * num21 + num19 * num22 > 0f)
            {
                num = vector.x;
                num2 = vector.y;
                num3 = vector.z;
                currentVelocity.x = (num - vector.x) / deltaTime;
                currentVelocity.y = (num2 - vector.y) / deltaTime;
                currentVelocity.z = (num3 - vector.z) / deltaTime;
            }

            return new TVector3(num, num2, num3);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Scale(TVector3 other)
        {
            x *= other.x;
            y *= other.y;
            z *= other.z;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TVector3 Scale(TVector3 vecA, TVector3 vecB)
        {
            TVector3 result;
            result.x = vecA.x * vecB.x;
            result.y = vecA.y * vecB.y;
            result.z = vecA.z * vecB.z;

            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TVector3 Cross(TVector3 lhs, TVector3 rhs)
        {
            return new TVector3(lhs.y * rhs.z - lhs.z * rhs.y, lhs.z * rhs.x - lhs.x * rhs.z, lhs.x * rhs.y - lhs.y * rhs.x);
        }
        public readonly override string ToString()
        {
            return string.Format("({0:f1}, {1:f1}, {2:f1})", x.AsFloat(), y.AsFloat(), z.AsFloat());
        }

        public override readonly bool Equals(object obj)
        {
            if (obj is not TVector3) return false;
            TVector3 other = (TVector3)obj;

            return (((x == other.x) && (y == other.y)) && (z == other.z));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TVector3 Reflect(TVector3 inDirection, TVector3 inNormal)
        {
            TFloat num = -(TFloat)2 * Dot(inNormal, inDirection);
            return new TVector3(num * inNormal.x + inDirection.x, num * inNormal.y + inDirection.y, num * inNormal.z + inDirection.z);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TVector3 Normalize(TVector3 value)
        {
            TFloat num = Magnitude(value);
            if (num > TFloat.EN5)
            {
                return value / num;
            }

            return zero;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Normalize()
        {
            TFloat num = Magnitude(this);
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
        public static TFloat Dot(TVector3 lhs, TVector3 rhs)
        {
            return lhs.x * rhs.x + lhs.y * rhs.y + lhs.z * rhs.z;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TVector3 Project(TVector3 vector, TVector3 onNormal)
        {
            TFloat num = Dot(onNormal, onNormal);
            if (num < TMath.Epsilon)
            {
                return zero;
            }

            TFloat num2 = Dot(vector, onNormal);
            return new TVector3(onNormal.x * num2 / num, onNormal.y * num2 / num, onNormal.z * num2 / num);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TVector3 ProjectOnPlane(TVector3 vector, TVector3 planeNormal)
        {
            TFloat num = Dot(planeNormal, planeNormal);
            if (num < TMath.Epsilon)
            {
                return vector;
            }

            TFloat num2 = Dot(vector, planeNormal);
            return new TVector3(vector.x - planeNormal.x * num2 / num, vector.y - planeNormal.y * num2 / num, vector.z - planeNormal.z * num2 / num);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TFloat Angle(TVector3 from, TVector3 to)
        {
            TFloat num = TMath.Sqrt(from.sqrMagnitude * to.sqrMagnitude);
            if (num < TFloat.EN5)
            {
                return 0f;
            }

            TFloat num2 = TMath.Clamp(Dot(from, to) / num, -1f, 1f);
            return TMath.Acos(num2) * 57.29578f;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TFloat SignedAngle(TVector3 from, TVector3 to, TVector3 axis)
        {
            TFloat num = Angle(from, to);
            TFloat num2 = from.y * to.z - from.z * to.y;
            TFloat num3 = from.z * to.x - from.x * to.z;
            TFloat num4 = from.x * to.y - from.y * to.x;
            TFloat num5 = TMath.Sign(axis.x * num2 + axis.y * num3 + axis.z * num4);
            return num * num5;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TFloat Distance(TVector3 a, TVector3 b)
        {
            TFloat num = a.x - b.x;
            TFloat num2 = a.y - b.y;
            TFloat num3 = a.z - b.z;
            return TMath.Sqrt(num * num + num2 * num2 + num3 * num3);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TVector3 ClampMagnitude(TVector3 vector, TFloat maxLength)
        {
            TFloat num = vector.sqrMagnitude;
            if (num > maxLength * maxLength)
            {
                TFloat num2 = TMath.Sqrt(num);
                TFloat num3 = vector.x / num2;
                TFloat num4 = vector.y / num2;
                TFloat num5 = vector.z / num2;
                return new TVector3(num3 * maxLength, num4 * maxLength, num5 * maxLength);
            }

            return vector;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TFloat Magnitude(TVector3 vector)
        {
            return TMath.Sqrt(vector.x * vector.x + vector.y * vector.y + vector.z * vector.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TFloat SqrMagnitude(TVector3 vector)
        {
            return vector.x * vector.x + vector.y * vector.y + vector.z * vector.z;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TVector3 Min(TVector3 lhs, TVector3 rhs)
        {
            return new TVector3(TMath.Min(lhs.x, rhs.x), TMath.Min(lhs.y, rhs.y), TMath.Min(lhs.z, rhs.z));
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TVector3 Max(TVector3 lhs, TVector3 rhs)
        {
            return new TVector3(TMath.Max(lhs.x, rhs.x), TMath.Max(lhs.y, rhs.y), TMath.Max(lhs.z, rhs.z));
        }
        /// <summary>
        /// Sets the length of the vector to zero.
        /// </summary>
        public void MakeZero()
        {
            x = TFloat.Zero;
            y = TFloat.Zero;
            z = TFloat.Zero;
        }

        /// <summary>
        /// Checks if the length of the vector is zero.
        /// </summary>
        /// <returns>Returns true if the vector is zero, otherwise false.</returns>
        public bool IsZero()
        {
            return (sqrMagnitude == TFloat.Zero);
        }

        /// <summary>
        /// Checks if the length of the vector is nearly zero.
        /// </summary>
        /// <returns>Returns true if the vector is nearly zero, otherwise false.</returns>
        public bool IsNearlyZero()
        {
            return sqrMagnitude < ZeroEpsilonSq;
        }

        /// <summary>
        /// Gets the hashcode of the vector.
        /// </summary>
        /// <returns>Returns the hashcode of the vector.</returns>
        public readonly override int GetHashCode()
        {
            return x.GetHashCode() ^ y.GetHashCode() ^ z.GetHashCode();
        }

        /// <summary>
        /// Inverses the direction of the vector.
        /// </summary>
        public void Negate()
        {
            x = -x;
            y = -y;
            z = -z;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TVector3 operator +(TVector3 a, TVector3 b)
        {
            return new TVector3(a.x + b.x, a.y + b.y, a.z + b.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TVector3 operator -(TVector3 a, TVector3 b)
        {
            return new TVector3(a.x - b.x, a.y - b.y, a.z - b.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TVector3 operator -(TVector3 a)
        {
            return new TVector3(- a.x, - a.y, - a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TVector3 operator *(TVector3 a, TFloat d)
        {
            return new TVector3(a.x * d, a.y * d, a.z * d);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TVector3 operator *(TFloat d, TVector3 a)
        {
            return new TVector3(a.x * d, a.y * d, a.z * d);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TVector3 operator /(TVector3 a, TFloat d)
        {
            return new TVector3(a.x / d, a.y / d, a.z / d);
        }

        public static bool operator ==(TVector3 value1, TVector3 value2)
        {
            return (((value1.x == value2.x) && (value1.y == value2.y)) && (value1.z == value2.z));
        }

        public static bool operator !=(TVector3 value1, TVector3 value2)
        {
            if ((value1.x == value2.x) && (value1.y == value2.y))
            {
                return (value1.z != value2.z);
            }
            return true;
        }

    }

}