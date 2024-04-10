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

        /// <summary>
        /// A vector with components (0,0,0);
        /// </summary>
        public static readonly TVector3 zero;
        /// <summary>
        /// A vector with components (-1,0,0);
        /// </summary>
        public static readonly TVector3 left;
        /// <summary>
        /// A vector with components (1,0,0);
        /// </summary>
        public static readonly TVector3 right;
        /// <summary>
        /// A vector with components (0,1,0);
        /// </summary>
        public static readonly TVector3 up;
        /// <summary>
        /// A vector with components (0,-1,0);
        /// </summary>
        public static readonly TVector3 down;
        /// <summary>
        /// A vector with components (0,0,-1);
        /// </summary>
        public static readonly TVector3 back;
        /// <summary>
        /// A vector with components (0,0,1);
        /// </summary>
        public static readonly TVector3 forward;
        /// <summary>
        /// A vector with components (1,1,1);
        /// </summary>
        public static readonly TVector3 one;
        /// <summary>
        /// A vector with components 
        /// (FP.MinValue,FP.MinValue,FP.MinValue);
        /// </summary>
        public static readonly TVector3 MinValue;
        /// <summary>
        /// A vector with components 
        /// (FP.MaxValue,FP.MaxValue,FP.MaxValue);
        /// </summary>
        public static readonly TVector3 MaxValue;

        static TVector3()
        {
            one = new TVector3(1, 1, 1);
            zero = new TVector3(0, 0, 0);
            left = new TVector3(-1, 0, 0);
            right = new TVector3(1, 0, 0);
            up = new TVector3(0, 1, 0);
            down = new TVector3(0, -1, 0);
            back = new TVector3(0, 0, -1);
            forward = new TVector3(0, 0, 1);
            MinValue = new TVector3(TFloat.MinValue);
            MaxValue = new TVector3(TFloat.MaxValue);
            Arbitrary = new TVector3(1, 1, 1);
            InternalZero = zero;
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

        public static TVector3 ClampMagnitude(TVector3 vector, TFloat maxLength)
        {
            return Normalize(vector) * maxLength;
        }

        /// <summary>
        /// Gets a normalized version of the vector.
        /// </summary>
        /// <returns>Returns a normalized version of the vector.</returns>
        public TVector3 normalized
        {
            get
            {
                TVector3 result = new TVector3(x, y, z);
                result.Normalize();

                return result;
            }
        }

        /// <summary>
        /// Constructor initializing a new instance of the structure
        /// </summary>
        /// <param name="x">The X component of the vector.</param>
        /// <param name="y">The Y component of the vector.</param>
        /// <param name="z">The Z component of the vector.</param>

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

        /// <summary>
        /// Multiplies each component of the vector by the same components of the provided vector.
        /// </summary>
        public void Scale(TVector3 other)
        {
            x *= other.x;
            y *= other.y;
            z *= other.z;
        }

        /// <summary>
        /// Sets all vector component to specific values.
        /// </summary>
        /// <param name="x">The X component of the vector.</param>
        /// <param name="y">The Y component of the vector.</param>
        /// <param name="z">The Z component of the vector.</param>
        public void Set(TFloat x, TFloat y, TFloat z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        /// <summary>
        /// Constructor initializing a new instance of the structure
        /// </summary>
        /// <param name="xyz">All components of the vector are set to xyz</param>
        public TVector3(TFloat xyz)
        {
            x = xyz;
            y = xyz;
            z = xyz;
        }

        public static TVector3 Lerp(TVector3 from, TVector3 to, TFloat percent)
        {
            return from + (to - from) * percent;
        }

        /// <summary>
        /// Builds a string from the JVector.
        /// </summary>
        /// <returns>A string containing all three components.</returns>
        public override string ToString()
        {
            return string.Format("({0:f1}, {1:f1}, {2:f1})", x.AsFloat(), y.AsFloat(), z.AsFloat());
        }

        /// <summary>
        /// Tests if an object is equal to this vector.
        /// </summary>
        /// <param name="obj">The object to test.</param>
        /// <returns>Returns true if they are euqal, otherwise false.</returns>
        public override readonly bool Equals(object obj)
        {
            if (obj is not TVector3) return false;
            TVector3 other = (TVector3)obj;

            return (((x == other.x) && (y == other.y)) && (z == other.z));
        }

        /// <summary>
        /// Multiplies each component of the vector by the same components of the provided vector.
        /// </summary>
        public static TVector3 Scale(TVector3 vecA, TVector3 vecB)
        {
            TVector3 result;
            result.x = vecA.x * vecB.x;
            result.y = vecA.y * vecB.y;
            result.z = vecA.z * vecB.z;

            return result;
        }

        /// <summary>
        /// Tests if two JVector are equal.
        /// </summary>
        /// <param name="value1">The first value.</param>
        /// <param name="value2">The second value.</param>
        /// <returns>Returns true if both values are equal, otherwise false.</returns>
        public static bool operator ==(TVector3 value1, TVector3 value2)
        {
            return (((value1.x == value2.x) && (value1.y == value2.y)) && (value1.z == value2.z));
        }

        /// <summary>
        /// Tests if two JVector are not equal.
        /// </summary>
        /// <param name="value1">The first value.</param>
        /// <param name="value2">The second value.</param>
        /// <returns>Returns false if both values are equal, otherwise true.</returns>
        public static bool operator !=(TVector3 value1, TVector3 value2)
        {
            if ((value1.x == value2.x) && (value1.y == value2.y))
            {
                return (value1.z != value2.z);
            }
            return true;
        }

        /// <summary>
        /// Gets a vector with the minimum x,y and z values of both vectors.
        /// </summary>
        /// <param name="value1">The first value.</param>
        /// <param name="value2">The second value.</param>
        /// <returns>A vector with the minimum x,y and z values of both vectors.</returns>

        public static TVector3 Min(TVector3 value1, TVector3 value2)
        {
            Min(ref value1, ref value2, out var result);
            return result;
        }

        /// <summary>
        /// Gets a vector with the minimum x,y and z values of both vectors.
        /// </summary>
        /// <param name="value1">The first value.</param>
        /// <param name="value2">The second value.</param>
        /// <param name="result">A vector with the minimum x,y and z values of both vectors.</param>
        public static void Min(ref TVector3 value1, ref TVector3 value2, out TVector3 result)
        {
            result.x = (value1.x < value2.x) ? value1.x : value2.x;
            result.y = (value1.y < value2.y) ? value1.y : value2.y;
            result.z = (value1.z < value2.z) ? value1.z : value2.z;
        }

        /// <summary>
        /// Gets a vector with the maximum x,y and z values of both vectors.
        /// </summary>
        /// <param name="value1">The first value.</param>
        /// <param name="value2">The second value.</param>
        /// <returns>A vector with the maximum x,y and z values of both vectors.</returns>
        public static TVector3 Max(TVector3 value1, TVector3 value2)
        {
            Max(ref value1, ref value2, out var result);
            return result;
        }

        public static TFloat Distance(TVector3 v1, TVector3 v2)
        {
            return TFloat.Sqrt((v1.x - v2.x) * (v1.x - v2.x) + (v1.y - v2.y) * (v1.y - v2.y) + (v1.z - v2.z) * (v1.z - v2.z));
        }

        /// <summary>
        /// Gets a vector with the maximum x,y and z values of both vectors.
        /// </summary>
        /// <param name="value1">The first value.</param>
        /// <param name="value2">The second value.</param>
        /// <param name="result">A vector with the maximum x,y and z values of both vectors.</param>
        public static void Max(ref TVector3 value1, ref TVector3 value2, out TVector3 result)
        {
            result.x = (value1.x > value2.x) ? value1.x : value2.x;
            result.y = (value1.y > value2.y) ? value1.y : value2.y;
            result.z = (value1.z > value2.z) ? value1.z : value2.z;
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
        /// Transforms a vector by the given matrix.
        /// </summary>
        /// <param name="position">The vector to transform.</param>
        /// <param name="matrix">The transform matrix.</param>
        /// <returns>The transformed vector.</returns>
        public static TVector3 Transform(TVector3 position, TMatrix matrix)
        {
            Transform(ref position, ref matrix, out var result);
            return result;
        }

        /// <summary>
        /// Transforms a vector by the given matrix.
        /// </summary>
        /// <param name="position">The vector to transform.</param>
        /// <param name="matrix">The transform matrix.</param>
        /// <param name="result">The transformed vector.</param>
        public static void Transform(ref TVector3 position, ref TMatrix matrix, out TVector3 result)
        {
            TFloat num0 = ((position.x * matrix.M11) + (position.y * matrix.M21)) + (position.z * matrix.M31);
            TFloat num1 = ((position.x * matrix.M12) + (position.y * matrix.M22)) + (position.z * matrix.M32);
            TFloat num2 = ((position.x * matrix.M13) + (position.y * matrix.M23)) + (position.z * matrix.M33);

            result.x = num0;
            result.y = num1;
            result.z = num2;
        }

        /// <summary>
        /// Transforms a vector by the transposed of the given Matrix.
        /// </summary>
        /// <param name="position">The vector to transform.</param>
        /// <param name="matrix">The transform matrix.</param>
        /// <param name="result">The transformed vector.</param>
        public static void TransposedTransform(ref TVector3 position, ref TMatrix matrix, out TVector3 result)
        {
            TFloat num0 = ((position.x * matrix.M11) + (position.y * matrix.M12)) + (position.z * matrix.M13);
            TFloat num1 = ((position.x * matrix.M21) + (position.y * matrix.M22)) + (position.z * matrix.M23);
            TFloat num2 = ((position.x * matrix.M31) + (position.y * matrix.M32)) + (position.z * matrix.M33);

            result.x = num0;
            result.y = num1;
            result.z = num2;
        }

        /// <summary>
        /// Calculates the dot product of two vectors.
        /// </summary>
        /// <param name="vector1">The first vector.</param>
        /// <param name="vector2">The second vector.</param>
        /// <returns>Returns the dot product of both vectors.</returns>
        public static TFloat Dot(TVector3 vector1, TVector3 vector2)
        {
            return Dot(ref vector1, ref vector2);
        }


        /// <summary>
        /// Calculates the dot product of both vectors.
        /// </summary>
        /// <param name="vector1">The first vector.</param>
        /// <param name="vector2">The second vector.</param>
        /// <returns>Returns the dot product of both vectors.</returns>
        public static TFloat Dot(ref TVector3 vector1, ref TVector3 vector2)
        {
            return (vector1.x * vector2.x) + (vector1.y * vector2.y) + (vector1.z * vector2.z);
        }

        // Projects a vector onto another vector.
        public static TVector3 Project(TVector3 vector, TVector3 onNormal)
        {
            TFloat sqrtMag = Dot(onNormal, onNormal);
            if (sqrtMag < TMath.Epsilon)
                return zero;
            else
                return onNormal * Dot(vector, onNormal) / sqrtMag;
        }

        // Projects a vector onto a plane defined by a normal orthogonal to the plane.
        public static TVector3 ProjectOnPlane(TVector3 vector, TVector3 planeNormal)
        {
            return vector - Project(vector, planeNormal);
        }


        // Returns the angle in degrees between /from/ and /to/. This is always the smallest
        public static TFloat Angle(TVector3 from, TVector3 to)
        {
            return TMath.Acos(TMath.Clamp(Dot(from.normalized, to.normalized), -TFloat.ONE, TFloat.ONE)) * TMath.Rad2Deg;
        }

        // The smaller of the two possible angles between the two vectors is returned, therefore the result will never be greater than 180 degrees or smaller than -180 degrees.
        // If you imagine the from and to vectors as lines on a piece of paper, both originating from the same point, then the /axis/ vector would point up out of the paper.
        // The measured angle between the two vectors would be positive in a clockwise direction and negative in an anti-clockwise direction.
        public static TFloat SignedAngle(TVector3 from, TVector3 to, TVector3 axis)
        {
            TVector3 fromNorm = from.normalized, toNorm = to.normalized;
            TFloat unsignedAngle = TMath.Acos(TMath.Clamp(Dot(fromNorm, toNorm), -TFloat.ONE, TFloat.ONE)) * TMath.Rad2Deg;
            TFloat sign = TMath.Sign(Dot(axis, Cross(fromNorm, toNorm)));
            return unsignedAngle * sign;
        }

        /// <summary>
        /// Adds two vectors.
        /// </summary>
        /// <param name="value1">The first vector.</param>
        /// <param name="value2">The second vector.</param>
        /// <returns>The sum of both vectors.</returns>
        public static TVector3 Add(TVector3 value1, TVector3 value2)
        {
            Add(ref value1, ref value2, out TVector3 result);
            return result;
        }

        /// <summary>
        /// Adds to vectors.
        /// </summary>
        /// <param name="value1">The first vector.</param>
        /// <param name="value2">The second vector.</param>
        /// <param name="result">The sum of both vectors.</param>
        public static void Add(ref TVector3 value1, ref TVector3 value2, out TVector3 result)
        {
            TFloat num0 = value1.x + value2.x;
            TFloat num1 = value1.y + value2.y;
            TFloat num2 = value1.z + value2.z;

            result.x = num0;
            result.y = num1;
            result.z = num2;
        }

        /// <summary>
        /// Divides a vector by a factor.
        /// </summary>
        /// <param name="value1">The vector to divide.</param>
        /// <param name="scaleFactor">The scale factor.</param>
        /// <returns>Returns the scaled vector.</returns>
        public static TVector3 Divide(TVector3 value1, TFloat scaleFactor)
        {
            Divide(ref value1, scaleFactor, out TVector3 result);
            return result;
        }

        /// <summary>
        /// Divides a vector by a factor.
        /// </summary>
        /// <param name="value1">The vector to divide.</param>
        /// <param name="scaleFactor">The scale factor.</param>
        /// <param name="result">Returns the scaled vector.</param>
        public static void Divide(ref TVector3 value1, TFloat scaleFactor, out TVector3 result)
        {
            result.x = value1.x / scaleFactor;
            result.y = value1.y / scaleFactor;
            result.z = value1.z / scaleFactor;
        }

        /// <summary>
        /// Subtracts two vectors.
        /// </summary>
        /// <param name="value1">The first vector.</param>
        /// <param name="value2">The second vector.</param>
        /// <returns>The difference of both vectors.</returns>
        public static TVector3 Subtract(TVector3 value1, TVector3 value2)
        {
            Subtract(ref value1, ref value2, out var result);
            return result;
        }

        /// <summary>
        /// Subtracts to vectors.
        /// </summary>
        /// <param name="value1">The first vector.</param>
        /// <param name="value2">The second vector.</param>
        /// <param name="result">The difference of both vectors.</param>
        public static void Subtract(ref TVector3 value1, ref TVector3 value2, out TVector3 result)
        {
            TFloat num0 = value1.x - value2.x;
            TFloat num1 = value1.y - value2.y;
            TFloat num2 = value1.z - value2.z;

            result.x = num0;
            result.y = num1;
            result.z = num2;
        }

        /// <summary>
        /// The cross product of two vectors.
        /// </summary>
        /// <param name="vector1">The first vector.</param>
        /// <param name="vector2">The second vector.</param>
        /// <returns>The cross product of both vectors.</returns>
        public static TVector3 Cross(TVector3 vector1, TVector3 vector2)
        {
            Cross(ref vector1, ref vector2, out var result);
            return result;
        }

        /// <summary>
        /// The cross product of two vectors.
        /// </summary>
        /// <param name="vector1">The first vector.</param>
        /// <param name="vector2">The second vector.</param>
        /// <param name="result">The cross product of both vectors.</param>
        public static void Cross(ref TVector3 vector1, ref TVector3 vector2, out TVector3 result)
        {
            TFloat num3 = (vector1.y * vector2.z) - (vector1.z * vector2.y);
            TFloat num2 = (vector1.z * vector2.x) - (vector1.x * vector2.z);
            TFloat num = (vector1.x * vector2.y) - (vector1.y * vector2.x);
            result.x = num3;
            result.y = num2;
            result.z = num;
        }

        /// <summary>
        /// Gets the hashcode of the vector.
        /// </summary>
        /// <returns>Returns the hashcode of the vector.</returns>
        public override int GetHashCode()
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

        /// <summary>
        /// Inverses the direction of a vector.
        /// </summary>
        /// <param name="value">The vector to inverse.</param>
        /// <returns>The negated vector.</returns>
        public static TVector3 Negate(TVector3 value)
        {
            Negate(ref value, out TVector3 result);
            return result;
        }

        /// <summary>
        /// Inverses the direction of a vector.
        /// </summary>
        /// <param name="value">The vector to inverse.</param>
        /// <param name="result">The negated vector.</param>
        public static void Negate(ref TVector3 value, out TVector3 result)
        {
            TFloat num0 = -value.x;
            TFloat num1 = -value.y;
            TFloat num2 = -value.z;

            result.x = num0;
            result.y = num1;
            result.z = num2;
        }

        /// <summary>
        /// Normalizes the given vector.
        /// </summary>
        /// <param name="value">The vector which should be normalized.</param>
        /// <returns>A normalized vector.</returns>
        public static TVector3 Normalize(TVector3 value)
        {
            Normalize(ref value, out TVector3 result);
            return result;
        }

        /// <summary>
        /// Normalizes this vector.
        /// </summary>
        public void Normalize()
        {
            TFloat num2 = (x * x) + (y * y) + (z * z);
            TFloat num = TFloat.One / TFloat.Sqrt(num2);
            x *= num;
            y *= num;
            z *= num;
        }

        /// <summary>
        /// Normalizes the given vector.
        /// </summary>
        /// <param name="value">The vector which should be normalized.</param>
        /// <param name="result">A normalized vector.</param>
        public static void Normalize(ref TVector3 value, out TVector3 result)
        {
            TFloat num2 = ((value.x * value.x) + (value.y * value.y)) + (value.z * value.z);
            TFloat num = TFloat.One / TFloat.Sqrt(num2);
            result.x = value.x * num;
            result.y = value.y * num;
            result.z = value.z * num;
        }

        /// <summary>
        /// Swaps the components of both vectors.
        /// </summary>
        /// <param name="vector1">The first vector to swap with the second.</param>
        /// <param name="vector2">The second vector to swap with the first.</param>
        public static void Swap(ref TVector3 vector1, ref TVector3 vector2)
        {
            TFloat temp;

            temp = vector1.x;
            vector1.x = vector2.x;
            vector2.x = temp;

            temp = vector1.y;
            vector1.y = vector2.y;
            vector2.y = temp;

            temp = vector1.z;
            vector1.z = vector2.z;
            vector2.z = temp;
        }

        /// <summary>
        /// Multiply a vector with a factor.
        /// </summary>
        /// <param name="value1">The vector to multiply.</param>
        /// <param name="scaleFactor">The scale factor.</param>
        /// <returns>Returns the multiplied vector.</returns>
        public static TVector3 Multiply(TVector3 value1, TFloat scaleFactor)
        {
            Multiply(ref value1, scaleFactor, out TVector3 result);
            return result;
        }

        /// <summary>
        /// Multiply a vector with a factor.
        /// </summary>
        /// <param name="value1">The vector to multiply.</param>
        /// <param name="scaleFactor">The scale factor.</param>
        /// <param name="result">Returns the multiplied vector.</param>
        public static void Multiply(ref TVector3 value1, TFloat scaleFactor, out TVector3 result)
        {
            result.x = value1.x * scaleFactor;
            result.y = value1.y * scaleFactor;
            result.z = value1.z * scaleFactor;
        }

        /// <summary>
        /// Calculates the cross product of two vectors.
        /// </summary>
        /// <param name="value1">The first vector.</param>
        /// <param name="value2">The second vector.</param>
        /// <returns>Returns the cross product of both.</returns>
        public static TVector3 operator %(TVector3 value1, TVector3 value2)
        {
            Cross(ref value1, ref value2, out var result);
            return result;
        }

        /// <summary>
        /// Calculates the dot product of two vectors.
        /// </summary>
        /// <param name="value1">The first vector.</param>
        /// <param name="value2">The second vector.</param>
        /// <returns>Returns the dot product of both.</returns>
        public static TFloat operator *(TVector3 value1, TVector3 value2)
        {
            return Dot(ref value1, ref value2);
        }

        /// <summary>
        /// Multiplies a vector by a scale factor.
        /// </summary>
        /// <param name="value1">The vector to scale.</param>
        /// <param name="value2">The scale factor.</param>
        /// <returns>Returns the scaled vector.</returns>
        public static TVector3 operator *(TVector3 value1, TFloat value2)
        {
            Multiply(ref value1, value2, out TVector3 result);
            return result;
        }

        /// <summary>
        /// Multiplies a vector by a scale factor.
        /// </summary>
        /// <param name="value2">The vector to scale.</param>
        /// <param name="value1">The scale factor.</param>
        /// <returns>Returns the scaled vector.</returns>
        public static TVector3 operator *(TFloat value1, TVector3 value2)
        {
            Multiply(ref value2, value1, out TVector3 result);
            return result;
        }

        /// <summary>
        /// Subtracts two vectors.
        /// </summary>
        /// <param name="value1">The first vector.</param>
        /// <param name="value2">The second vector.</param>
        /// <returns>The difference of both vectors.</returns>
        public static TVector3 operator -(TVector3 value1, TVector3 value2)
        {
            Subtract(ref value1, ref value2, out var result);
            return result;
        }

        /// <summary>
        /// Adds two vectors.
        /// </summary>
        /// <param name="value1">The first vector.</param>
        /// <param name="value2">The second vector.</param>
        /// <returns>The sum of both vectors.</returns>
        public static TVector3 operator +(TVector3 value1, TVector3 value2)
        {
            Add(ref value1, ref value2, out var result);
            return result;
        }

        /// <summary>
        /// Divides a vector by a factor.
        /// </summary>
        /// <param name="value1">The vector to divide.</param>
        /// <param name="scaleFactor">The scale factor.</param>
        /// <returns>Returns the scaled vector.</returns>
        public static TVector3 operator /(TVector3 value1, TFloat value2)
        {
            Divide(ref value1, value2, out TVector3 result);
            return result;
        }

        public TVector2 ToTSVector2()
        {
            return new TVector2(x, y);
        }

        public TVector4 ToTSVector4()
        {
            return new TVector4(x, y, z, TFloat.One);
        }

    }

}