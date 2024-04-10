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
    /// 3x3 Matrix.
    /// </summary>
    public struct TMatrix
    {
        /// <summary>
        /// M11
        /// </summary>
        public TFloat M11; // 1st row vector
        /// <summary>
        /// M12
        /// </summary>
        public TFloat M12;
        /// <summary>
        /// M13
        /// </summary>
        public TFloat M13;
        /// <summary>
        /// M21
        /// </summary>
        public TFloat M21; // 2nd row vector
        /// <summary>
        /// M22
        /// </summary>
        public TFloat M22;
        /// <summary>
        /// M23
        /// </summary>
        public TFloat M23;
        /// <summary>
        /// M31
        /// </summary>
        public TFloat M31; // 3rd row vector
        /// <summary>
        /// M32
        /// </summary>
        public TFloat M32;
        /// <summary>
        /// M33
        /// </summary>
        public TFloat M33;

        internal static TMatrix InternalIdentity;

        /// <summary>
        /// Identity matrix.
        /// </summary>
        public static readonly TMatrix Identity;
        public static readonly TMatrix Zero;

        static TMatrix()
        {
            Zero = new TMatrix();

            Identity = new TMatrix();
            Identity.M11 = TFloat.One;
            Identity.M22 = TFloat.One;
            Identity.M33 = TFloat.One;

            InternalIdentity = Identity;
        }

        public TVector3 eulerAngles
        {
            get
            {
                TVector3 result = new TVector3();

                result.x = TMath.Atan2(M32, M33) * TFloat.Rad2Deg;
                result.y = TMath.Atan2(-M31, TMath.Sqrt(M32 * M32 + M33 * M33)) * TFloat.Rad2Deg;
                result.z = TMath.Atan2(M21, M11) * TFloat.Rad2Deg;

                return result * -1;
            }
        }

        public static TMatrix CreateFromYawPitchRoll(TFloat yaw, TFloat pitch, TFloat roll)
        {
            TQuaternion.CreateFromYawPitchRoll(yaw, pitch, roll, out TQuaternion quaternion);
            CreateFromQuaternion(ref quaternion, out TMatrix matrix);
            return matrix;
        }

        public static TMatrix CreateRotationX(TFloat radians)
        {
            TMatrix matrix;
            TFloat num2 = TFloat.Cos(radians);
            TFloat num = TFloat.Sin(radians);
            matrix.M11 = TFloat.One;
            matrix.M12 = TFloat.Zero;
            matrix.M13 = TFloat.Zero;
            matrix.M21 = TFloat.Zero;
            matrix.M22 = num2;
            matrix.M23 = num;
            matrix.M31 = TFloat.Zero;
            matrix.M32 = -num;
            matrix.M33 = num2;
            return matrix;
        }

        public static void CreateRotationX(TFloat radians, out TMatrix result)
        {
            TFloat num2 = TFloat.Cos(radians);
            TFloat num = TFloat.Sin(radians);
            result.M11 = TFloat.One;
            result.M12 = TFloat.Zero;
            result.M13 = TFloat.Zero;
            result.M21 = TFloat.Zero;
            result.M22 = num2;
            result.M23 = num;
            result.M31 = TFloat.Zero;
            result.M32 = -num;
            result.M33 = num2;
        }

        public static TMatrix CreateRotationY(TFloat radians)
        {
            TMatrix matrix;
            TFloat num2 = TFloat.Cos(radians);
            TFloat num = TFloat.Sin(radians);
            matrix.M11 = num2;
            matrix.M12 = TFloat.Zero;
            matrix.M13 = -num;
            matrix.M21 = TFloat.Zero;
            matrix.M22 = TFloat.One;
            matrix.M23 = TFloat.Zero;
            matrix.M31 = num;
            matrix.M32 = TFloat.Zero;
            matrix.M33 = num2;
            return matrix;
        }

        public static void CreateRotationY(TFloat radians, out TMatrix result)
        {
            TFloat num2 = TFloat.Cos(radians);
            TFloat num = TFloat.Sin(radians);
            result.M11 = num2;
            result.M12 = TFloat.Zero;
            result.M13 = -num;
            result.M21 = TFloat.Zero;
            result.M22 = TFloat.One;
            result.M23 = TFloat.Zero;
            result.M31 = num;
            result.M32 = TFloat.Zero;
            result.M33 = num2;
        }

        public static TMatrix CreateRotationZ(TFloat radians)
        {
            TMatrix matrix;
            TFloat num2 = TFloat.Cos(radians);
            TFloat num = TFloat.Sin(radians);
            matrix.M11 = num2;
            matrix.M12 = num;
            matrix.M13 = TFloat.Zero;
            matrix.M21 = -num;
            matrix.M22 = num2;
            matrix.M23 = TFloat.Zero;
            matrix.M31 = TFloat.Zero;
            matrix.M32 = TFloat.Zero;
            matrix.M33 = TFloat.One;
            return matrix;
        }


        public static void CreateRotationZ(TFloat radians, out TMatrix result)
        {
            TFloat num2 = TFloat.Cos(radians);
            TFloat num = TFloat.Sin(radians);
            result.M11 = num2;
            result.M12 = num;
            result.M13 = TFloat.Zero;
            result.M21 = -num;
            result.M22 = num2;
            result.M23 = TFloat.Zero;
            result.M31 = TFloat.Zero;
            result.M32 = TFloat.Zero;
            result.M33 = TFloat.One;
        }

        /// <summary>
        /// Initializes a new instance of the matrix structure.
        /// </summary>
        /// <param name="m11">m11</param>
        /// <param name="m12">m12</param>
        /// <param name="m13">m13</param>
        /// <param name="m21">m21</param>
        /// <param name="m22">m22</param>
        /// <param name="m23">m23</param>
        /// <param name="m31">m31</param>
        /// <param name="m32">m32</param>
        /// <param name="m33">m33</param>
        public TMatrix(TFloat m11, TFloat m12, TFloat m13, TFloat m21, TFloat m22, TFloat m23, TFloat m31, TFloat m32, TFloat m33)
        {
            M11 = m11;
            M12 = m12;
            M13 = m13;
            M21 = m21;
            M22 = m22;
            M23 = m23;
            M31 = m31;
            M32 = m32;
            M33 = m33;
        }

        /// <summary>
        /// Gets the determinant of the matrix.
        /// </summary>
        /// <returns>The determinant of the matrix.</returns>
        //public FP Determinant()
        //{
        //    return M11 * M22 * M33 -M11 * M23 * M32 -M12 * M21 * M33 +M12 * M23 * M31 + M13 * M21 * M32 - M13 * M22 * M31;
        //}

        /// <summary>
        /// Multiply two matrices. Notice: matrix multiplication is not commutative.
        /// </summary>
        /// <param name="matrix1">The first matrix.</param>
        /// <param name="matrix2">The second matrix.</param>
        /// <returns>The product of both matrices.</returns>
        public static TMatrix Multiply(TMatrix matrix1, TMatrix matrix2)
        {
            Multiply(ref matrix1, ref matrix2, out TMatrix result);
            return result;
        }

        /// <summary>
        /// Multiply two matrices. Notice: matrix multiplication is not commutative.
        /// </summary>
        /// <param name="matrix1">The first matrix.</param>
        /// <param name="matrix2">The second matrix.</param>
        /// <param name="result">The product of both matrices.</param>
        public static void Multiply(ref TMatrix matrix1, ref TMatrix matrix2, out TMatrix result)
        {
            TFloat num0 = ((matrix1.M11 * matrix2.M11) + (matrix1.M12 * matrix2.M21)) + (matrix1.M13 * matrix2.M31);
            TFloat num1 = ((matrix1.M11 * matrix2.M12) + (matrix1.M12 * matrix2.M22)) + (matrix1.M13 * matrix2.M32);
            TFloat num2 = ((matrix1.M11 * matrix2.M13) + (matrix1.M12 * matrix2.M23)) + (matrix1.M13 * matrix2.M33);
            TFloat num3 = ((matrix1.M21 * matrix2.M11) + (matrix1.M22 * matrix2.M21)) + (matrix1.M23 * matrix2.M31);
            TFloat num4 = ((matrix1.M21 * matrix2.M12) + (matrix1.M22 * matrix2.M22)) + (matrix1.M23 * matrix2.M32);
            TFloat num5 = ((matrix1.M21 * matrix2.M13) + (matrix1.M22 * matrix2.M23)) + (matrix1.M23 * matrix2.M33);
            TFloat num6 = ((matrix1.M31 * matrix2.M11) + (matrix1.M32 * matrix2.M21)) + (matrix1.M33 * matrix2.M31);
            TFloat num7 = ((matrix1.M31 * matrix2.M12) + (matrix1.M32 * matrix2.M22)) + (matrix1.M33 * matrix2.M32);
            TFloat num8 = ((matrix1.M31 * matrix2.M13) + (matrix1.M32 * matrix2.M23)) + (matrix1.M33 * matrix2.M33);

            result.M11 = num0;
            result.M12 = num1;
            result.M13 = num2;
            result.M21 = num3;
            result.M22 = num4;
            result.M23 = num5;
            result.M31 = num6;
            result.M32 = num7;
            result.M33 = num8;
        }

        /// <summary>
        /// Matrices are added.
        /// </summary>
        /// <param name="matrix1">The first matrix.</param>
        /// <param name="matrix2">The second matrix.</param>
        /// <returns>The sum of both matrices.</returns>
        public static TMatrix Add(TMatrix matrix1, TMatrix matrix2)
        {
            Add(ref matrix1, ref matrix2, out TMatrix result);
            return result;
        }

        /// <summary>
        /// Matrices are added.
        /// </summary>
        /// <param name="matrix1">The first matrix.</param>
        /// <param name="matrix2">The second matrix.</param>
        /// <param name="result">The sum of both matrices.</param>
        public static void Add(ref TMatrix matrix1, ref TMatrix matrix2, out TMatrix result)
        {
            result.M11 = matrix1.M11 + matrix2.M11;
            result.M12 = matrix1.M12 + matrix2.M12;
            result.M13 = matrix1.M13 + matrix2.M13;
            result.M21 = matrix1.M21 + matrix2.M21;
            result.M22 = matrix1.M22 + matrix2.M22;
            result.M23 = matrix1.M23 + matrix2.M23;
            result.M31 = matrix1.M31 + matrix2.M31;
            result.M32 = matrix1.M32 + matrix2.M32;
            result.M33 = matrix1.M33 + matrix2.M33;
        }

        /// <summary>
        /// Calculates the inverse of a give matrix.
        /// </summary>
        /// <param name="matrix">The matrix to invert.</param>
        /// <returns>The inverted JMatrix.</returns>
        public static TMatrix Inverse(TMatrix matrix)
        {
            Inverse(ref matrix, out TMatrix result);
            return result;
        }

        public TFloat Determinant()
        {
            return M11 * M22 * M33 + M12 * M23 * M31 + M13 * M21 * M32 -
                   M31 * M22 * M13 - M32 * M23 * M11 - M33 * M21 * M12;
        }

        public static void Invert(ref TMatrix matrix, out TMatrix result)
        {
            TFloat determinantInverse = 1 / matrix.Determinant();
            TFloat m11 = (matrix.M22 * matrix.M33 - matrix.M23 * matrix.M32) * determinantInverse;
            TFloat m12 = (matrix.M13 * matrix.M32 - matrix.M33 * matrix.M12) * determinantInverse;
            TFloat m13 = (matrix.M12 * matrix.M23 - matrix.M22 * matrix.M13) * determinantInverse;

            TFloat m21 = (matrix.M23 * matrix.M31 - matrix.M21 * matrix.M33) * determinantInverse;
            TFloat m22 = (matrix.M11 * matrix.M33 - matrix.M13 * matrix.M31) * determinantInverse;
            TFloat m23 = (matrix.M13 * matrix.M21 - matrix.M11 * matrix.M23) * determinantInverse;

            TFloat m31 = (matrix.M21 * matrix.M32 - matrix.M22 * matrix.M31) * determinantInverse;
            TFloat m32 = (matrix.M12 * matrix.M31 - matrix.M11 * matrix.M32) * determinantInverse;
            TFloat m33 = (matrix.M11 * matrix.M22 - matrix.M12 * matrix.M21) * determinantInverse;

            result.M11 = m11;
            result.M12 = m12;
            result.M13 = m13;

            result.M21 = m21;
            result.M22 = m22;
            result.M23 = m23;

            result.M31 = m31;
            result.M32 = m32;
            result.M33 = m33;
        }

        /// <summary>
        /// Calculates the inverse of a give matrix.
        /// </summary>
        /// <param name="matrix">The matrix to invert.</param>
        /// <param name="result">The inverted JMatrix.</param>
        public static void Inverse(ref TMatrix matrix, out TMatrix result)
        {
            TFloat det = 1024 * matrix.M11 * matrix.M22 * matrix.M33 -
                1024 * matrix.M11 * matrix.M23 * matrix.M32 -
                1024 * matrix.M12 * matrix.M21 * matrix.M33 +
                1024 * matrix.M12 * matrix.M23 * matrix.M31 +
                1024 * matrix.M13 * matrix.M21 * matrix.M32 -
                1024 * matrix.M13 * matrix.M22 * matrix.M31;

            TFloat num11 = 1024 * matrix.M22 * matrix.M33 - 1024 * matrix.M23 * matrix.M32;
            TFloat num12 = 1024 * matrix.M13 * matrix.M32 - 1024 * matrix.M12 * matrix.M33;
            TFloat num13 = 1024 * matrix.M12 * matrix.M23 - 1024 * matrix.M22 * matrix.M13;

            TFloat num21 = 1024 * matrix.M23 * matrix.M31 - 1024 * matrix.M33 * matrix.M21;
            TFloat num22 = 1024 * matrix.M11 * matrix.M33 - 1024 * matrix.M31 * matrix.M13;
            TFloat num23 = 1024 * matrix.M13 * matrix.M21 - 1024 * matrix.M23 * matrix.M11;

            TFloat num31 = 1024 * matrix.M21 * matrix.M32 - 1024 * matrix.M31 * matrix.M22;
            TFloat num32 = 1024 * matrix.M12 * matrix.M31 - 1024 * matrix.M32 * matrix.M11;
            TFloat num33 = 1024 * matrix.M11 * matrix.M22 - 1024 * matrix.M21 * matrix.M12;

            if (det == 0)
            {
                result.M11 = TFloat.PositiveInfinity;
                result.M12 = TFloat.PositiveInfinity;
                result.M13 = TFloat.PositiveInfinity;
                result.M21 = TFloat.PositiveInfinity;
                result.M22 = TFloat.PositiveInfinity;
                result.M23 = TFloat.PositiveInfinity;
                result.M31 = TFloat.PositiveInfinity;
                result.M32 = TFloat.PositiveInfinity;
                result.M33 = TFloat.PositiveInfinity;
            }
            else
            {
                result.M11 = num11 / det;
                result.M12 = num12 / det;
                result.M13 = num13 / det;
                result.M21 = num21 / det;
                result.M22 = num22 / det;
                result.M23 = num23 / det;
                result.M31 = num31 / det;
                result.M32 = num32 / det;
                result.M33 = num33 / det;
            }

        }

        /// <summary>
        /// Multiply a matrix by a scalefactor.
        /// </summary>
        /// <param name="matrix1">The matrix.</param>
        /// <param name="scaleFactor">The scale factor.</param>
        /// <returns>A JMatrix multiplied by the scale factor.</returns>
        public static TMatrix Multiply(TMatrix matrix1, TFloat scaleFactor)
        {
            Multiply(ref matrix1, scaleFactor, out TMatrix result);
            return result;
        }

        /// <summary>
        /// Multiply a matrix by a scalefactor.
        /// </summary>
        /// <param name="matrix1">The matrix.</param>
        /// <param name="scaleFactor">The scale factor.</param>
        /// <param name="result">A JMatrix multiplied by the scale factor.</param>
        public static void Multiply(ref TMatrix matrix1, TFloat scaleFactor, out TMatrix result)
        {
            TFloat num = scaleFactor;
            result.M11 = matrix1.M11 * num;
            result.M12 = matrix1.M12 * num;
            result.M13 = matrix1.M13 * num;
            result.M21 = matrix1.M21 * num;
            result.M22 = matrix1.M22 * num;
            result.M23 = matrix1.M23 * num;
            result.M31 = matrix1.M31 * num;
            result.M32 = matrix1.M32 * num;
            result.M33 = matrix1.M33 * num;
        }

        /// <summary>
        /// Creates a JMatrix representing an orientation from a quaternion.
        /// </summary>
        /// <param name="quaternion">The quaternion the matrix should be created from.</param>
        /// <returns>JMatrix representing an orientation.</returns>

        public static TMatrix CreateFromLookAt(TVector3 position, TVector3 target)
        {
            LookAt(target - position, TVector3.up, out TMatrix result);
            return result;
        }

        public static TMatrix LookAt(TVector3 forward, TVector3 upwards)
        {
            LookAt(forward, upwards, out TMatrix result);

            return result;
        }

        public static void LookAt(TVector3 forward, TVector3 upwards, out TMatrix result)
        {
            TVector3 zaxis = forward; zaxis.Normalize();
            TVector3 xaxis = TVector3.Cross(upwards, zaxis); xaxis.Normalize();
            TVector3 yaxis = TVector3.Cross(zaxis, xaxis);

            result.M11 = xaxis.x;
            result.M21 = yaxis.x;
            result.M31 = zaxis.x;
            result.M12 = xaxis.y;
            result.M22 = yaxis.y;
            result.M32 = zaxis.y;
            result.M13 = xaxis.z;
            result.M23 = yaxis.z;
            result.M33 = zaxis.z;
        }

        public static TMatrix CreateFromQuaternion(TQuaternion quaternion)
        {
            CreateFromQuaternion(ref quaternion, out TMatrix result);
            return result;
        }

        /// <summary>
        /// Creates a JMatrix representing an orientation from a quaternion.
        /// </summary>
        /// <param name="quaternion">The quaternion the matrix should be created from.</param>
        /// <param name="result">JMatrix representing an orientation.</param>
        public static void CreateFromQuaternion(ref TQuaternion quaternion, out TMatrix result)
        {
            TFloat num9 = quaternion.x * quaternion.x;
            TFloat num8 = quaternion.y * quaternion.y;
            TFloat num7 = quaternion.z * quaternion.z;
            TFloat num6 = quaternion.x * quaternion.y;
            TFloat num5 = quaternion.z * quaternion.w;
            TFloat num4 = quaternion.z * quaternion.x;
            TFloat num3 = quaternion.y * quaternion.w;
            TFloat num2 = quaternion.y * quaternion.z;
            TFloat num = quaternion.x * quaternion.w;
            result.M11 = TFloat.One - (2 * (num8 + num7));
            result.M12 = 2 * (num6 + num5);
            result.M13 = 2 * (num4 - num3);
            result.M21 = 2 * (num6 - num5);
            result.M22 = TFloat.One - (2 * (num7 + num9));
            result.M23 = 2 * (num2 + num);
            result.M31 = 2 * (num4 + num3);
            result.M32 = 2 * (num2 - num);
            result.M33 = TFloat.One - (2 * (num8 + num9));
        }

        /// <summary>
        /// Creates the transposed matrix.
        /// </summary>
        /// <param name="matrix">The matrix which should be transposed.</param>
        /// <returns>The transposed JMatrix.</returns>
        public static TMatrix Transpose(TMatrix matrix)
        {
            Transpose(ref matrix, out TMatrix result);
            return result;
        }

        /// <summary>
        /// Creates the transposed matrix.
        /// </summary>
        /// <param name="matrix">The matrix which should be transposed.</param>
        /// <param name="result">The transposed JMatrix.</param>
        public static void Transpose(ref TMatrix matrix, out TMatrix result)
        {
            result.M11 = matrix.M11;
            result.M12 = matrix.M21;
            result.M13 = matrix.M31;
            result.M21 = matrix.M12;
            result.M22 = matrix.M22;
            result.M23 = matrix.M32;
            result.M31 = matrix.M13;
            result.M32 = matrix.M23;
            result.M33 = matrix.M33;
        }

        /// <summary>
        /// Multiplies two matrices.
        /// </summary>
        /// <param name="value1">The first matrix.</param>
        /// <param name="value2">The second matrix.</param>
        /// <returns>The product of both values.</returns>
        public static TMatrix operator *(TMatrix value1, TMatrix value2)
        {
            Multiply(ref value1, ref value2, out TMatrix result);
            return result;
        }


        public TFloat Trace()
        {
            return M11 + M22 + M33;
        }

        /// <summary>
        /// Adds two matrices.
        /// </summary>
        /// <param name="value1">The first matrix.</param>
        /// <param name="value2">The second matrix.</param>
        /// <returns>The sum of both values.</returns>
        public static TMatrix operator +(TMatrix value1, TMatrix value2)
        {
            Add(ref value1, ref value2, out TMatrix result);
            return result;
        }

        /// <summary>
        /// Subtracts two matrices.
        /// </summary>
        /// <param name="value1">The first matrix.</param>
        /// <param name="value2">The second matrix.</param>
        /// <returns>The difference of both values.</returns>
        public static TMatrix operator -(TMatrix value1, TMatrix value2)
        {
            Multiply(ref value2, -TFloat.One, out value2);
            Add(ref value1, ref value2, out TMatrix result);
            return result;
        }

        public static bool operator ==(TMatrix value1, TMatrix value2)
        {
            return value1.M11 == value2.M11 &&
                value1.M12 == value2.M12 &&
                value1.M13 == value2.M13 &&
                value1.M21 == value2.M21 &&
                value1.M22 == value2.M22 &&
                value1.M23 == value2.M23 &&
                value1.M31 == value2.M31 &&
                value1.M32 == value2.M32 &&
                value1.M33 == value2.M33;
        }

        public static bool operator !=(TMatrix value1, TMatrix value2)
        {
            return value1.M11 != value2.M11 ||
                value1.M12 != value2.M12 ||
                value1.M13 != value2.M13 ||
                value1.M21 != value2.M21 ||
                value1.M22 != value2.M22 ||
                value1.M23 != value2.M23 ||
                value1.M31 != value2.M31 ||
                value1.M32 != value2.M32 ||
                value1.M33 != value2.M33;
        }

        public override readonly bool Equals(object obj)
        {
            if (obj is not TMatrix) return false;
            TMatrix other = (TMatrix)obj;

            return M11 == other.M11 &&
                M12 == other.M12 &&
                M13 == other.M13 &&
                M21 == other.M21 &&
                M22 == other.M22 &&
                M23 == other.M23 &&
                M31 == other.M31 &&
                M32 == other.M32 &&
                M33 == other.M33;
        }

        public override int GetHashCode()
        {
            return M11.GetHashCode() ^
                M12.GetHashCode() ^
                M13.GetHashCode() ^
                M21.GetHashCode() ^
                M22.GetHashCode() ^
                M23.GetHashCode() ^
                M31.GetHashCode() ^
                M32.GetHashCode() ^
                M33.GetHashCode();
        }

        /// <summary>
        /// Creates a matrix which rotates around the given axis by the given angle.
        /// </summary>
        /// <param name="axis">The axis.</param>
        /// <param name="angle">The angle.</param>
        /// <param name="result">The resulting rotation matrix</param>
        public static void CreateFromAxisAngle(ref TVector3 axis, TFloat angle, out TMatrix result)
        {
            TFloat x = axis.x;
            TFloat y = axis.y;
            TFloat z = axis.z;
            TFloat num2 = TFloat.Sin(angle);
            TFloat num = TFloat.Cos(angle);
            TFloat num11 = x * x;
            TFloat num10 = y * y;
            TFloat num9 = z * z;
            TFloat num8 = x * y;
            TFloat num7 = x * z;
            TFloat num6 = y * z;
            result.M11 = num11 + (num * (TFloat.One - num11));
            result.M12 = (num8 - (num * num8)) + (num2 * z);
            result.M13 = (num7 - (num * num7)) - (num2 * y);
            result.M21 = (num8 - (num * num8)) - (num2 * z);
            result.M22 = num10 + (num * (TFloat.One - num10));
            result.M23 = (num6 - (num * num6)) + (num2 * x);
            result.M31 = (num7 - (num * num7)) + (num2 * y);
            result.M32 = (num6 - (num * num6)) - (num2 * x);
            result.M33 = num9 + (num * (TFloat.One - num9));
        }

        /// <summary>
        /// Creates a matrix which rotates around the given axis by the given angle.
        /// </summary>
        /// <param name="axis">The axis.</param>
        /// <param name="angle">The angle.</param>
        /// <returns>The resulting rotation matrix</returns>
        public static TMatrix AngleAxis(TFloat angle, TVector3 axis)
        {
            TMatrix result; CreateFromAxisAngle(ref axis, angle, out result);
            return result;
        }


        public override string ToString()
        {
            return string.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|{8}", M11.RawValue, M12.RawValue, M13.RawValue, M21.RawValue, M22.RawValue, M23.RawValue, M31.RawValue, M32.RawValue, M33.RawValue);
        }

    }

}