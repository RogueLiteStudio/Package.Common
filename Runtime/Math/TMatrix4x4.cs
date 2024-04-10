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

    [System.Serializable]
    public struct TMatrix4x4
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
        /// M14
        /// </summary>
        public TFloat M14;
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
        /// M24
        /// </summary>
        public TFloat M24;
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
        /// <summary>
        /// M34
        /// </summary>
        public TFloat M34;
        /// <summary>
        /// M41
        /// </summary>
        public TFloat M41; // 4rd row vector
        /// <summary>
        /// M42
        /// </summary>
        public TFloat M42;
        /// <summary>
        /// M43
        /// </summary>
        public TFloat M43;
        /// <summary>
        /// M44
        /// </summary>
        public TFloat M44;

        internal static TMatrix4x4 InternalIdentity;

        /// <summary>
        /// Identity matrix.
        /// </summary>
        public static readonly TMatrix4x4 Identity;
        public static readonly TMatrix4x4 Zero;

        static TMatrix4x4()
        {
            Zero = new TMatrix4x4();

            Identity = new TMatrix4x4();
            Identity.M11 = TFloat.One;
            Identity.M22 = TFloat.One;
            Identity.M33 = TFloat.One;
            Identity.M44 = TFloat.One;

            InternalIdentity = Identity;
        }
        /// <summary>
        /// Initializes a new instance of the matrix structure.
        /// </summary>
        /// <param name="m11">m11</param>
        /// <param name="m12">m12</param>
        /// <param name="m13">m13</param>
        /// <param name="m14">m14</param>
        /// <param name="m21">m21</param>
        /// <param name="m22">m22</param>
        /// <param name="m23">m23</param>
        /// <param name="m24">m24</param>
        /// <param name="m31">m31</param>
        /// <param name="m32">m32</param>
        /// <param name="m33">m33</param>
        /// <param name="m34">m34</param>
        /// <param name="m41">m41</param>
        /// <param name="m42">m42</param>
        /// <param name="m43">m43</param>
        /// <param name="m44">m44</param>
        public TMatrix4x4(TFloat m11, TFloat m12, TFloat m13, TFloat m14,
            TFloat m21, TFloat m22, TFloat m23, TFloat m24,
            TFloat m31, TFloat m32, TFloat m33, TFloat m34,
            TFloat m41, TFloat m42, TFloat m43, TFloat m44)
        {
            M11 = m11;
            M12 = m12;
            M13 = m13;
            M14 = m14;
            M21 = m21;
            M22 = m22;
            M23 = m23;
            M24 = m24;
            M31 = m31;
            M32 = m32;
            M33 = m33;
            M34 = m34;
            M41 = m41;
            M42 = m42;
            M43 = m43;
            M44 = m44;
        }

        /// <summary>
        /// Multiply two matrices. Notice: matrix multiplication is not commutative.
        /// </summary>
        /// <param name="matrix1">The first matrix.</param>
        /// <param name="matrix2">The second matrix.</param>
        /// <returns>The product of both matrices.</returns>
        public static TMatrix4x4 Multiply(TMatrix4x4 matrix1, TMatrix4x4 matrix2)
        {
            Multiply(ref matrix1, ref matrix2, out TMatrix4x4 result);
            return result;
        }

        /// <summary>
        /// Multiply two matrices. Notice: matrix multiplication is not commutative.
        /// </summary>
        /// <param name="matrix1">The first matrix.</param>
        /// <param name="matrix2">The second matrix.</param>
        /// <param name="result">The product of both matrices.</param>
        public static void Multiply(ref TMatrix4x4 matrix1, ref TMatrix4x4 matrix2, out TMatrix4x4 result)
        {
            // First row
            result.M11 = matrix1.M11 * matrix2.M11 + matrix1.M12 * matrix2.M21 + matrix1.M13 * matrix2.M31 + matrix1.M14 * matrix2.M41;
            result.M12 = matrix1.M11 * matrix2.M12 + matrix1.M12 * matrix2.M22 + matrix1.M13 * matrix2.M32 + matrix1.M14 * matrix2.M42;
            result.M13 = matrix1.M11 * matrix2.M13 + matrix1.M12 * matrix2.M23 + matrix1.M13 * matrix2.M33 + matrix1.M14 * matrix2.M43;
            result.M14 = matrix1.M11 * matrix2.M14 + matrix1.M12 * matrix2.M24 + matrix1.M13 * matrix2.M34 + matrix1.M14 * matrix2.M44;

            // Second row
            result.M21 = matrix1.M21 * matrix2.M11 + matrix1.M22 * matrix2.M21 + matrix1.M23 * matrix2.M31 + matrix1.M24 * matrix2.M41;
            result.M22 = matrix1.M21 * matrix2.M12 + matrix1.M22 * matrix2.M22 + matrix1.M23 * matrix2.M32 + matrix1.M24 * matrix2.M42;
            result.M23 = matrix1.M21 * matrix2.M13 + matrix1.M22 * matrix2.M23 + matrix1.M23 * matrix2.M33 + matrix1.M24 * matrix2.M43;
            result.M24 = matrix1.M21 * matrix2.M14 + matrix1.M22 * matrix2.M24 + matrix1.M23 * matrix2.M34 + matrix1.M24 * matrix2.M44;

            // Third row
            result.M31 = matrix1.M31 * matrix2.M11 + matrix1.M32 * matrix2.M21 + matrix1.M33 * matrix2.M31 + matrix1.M34 * matrix2.M41;
            result.M32 = matrix1.M31 * matrix2.M12 + matrix1.M32 * matrix2.M22 + matrix1.M33 * matrix2.M32 + matrix1.M34 * matrix2.M42;
            result.M33 = matrix1.M31 * matrix2.M13 + matrix1.M32 * matrix2.M23 + matrix1.M33 * matrix2.M33 + matrix1.M34 * matrix2.M43;
            result.M34 = matrix1.M31 * matrix2.M14 + matrix1.M32 * matrix2.M24 + matrix1.M33 * matrix2.M34 + matrix1.M34 * matrix2.M44;

            // Fourth row
            result.M41 = matrix1.M41 * matrix2.M11 + matrix1.M42 * matrix2.M21 + matrix1.M43 * matrix2.M31 + matrix1.M44 * matrix2.M41;
            result.M42 = matrix1.M41 * matrix2.M12 + matrix1.M42 * matrix2.M22 + matrix1.M43 * matrix2.M32 + matrix1.M44 * matrix2.M42;
            result.M43 = matrix1.M41 * matrix2.M13 + matrix1.M42 * matrix2.M23 + matrix1.M43 * matrix2.M33 + matrix1.M44 * matrix2.M43;
            result.M44 = matrix1.M41 * matrix2.M14 + matrix1.M42 * matrix2.M24 + matrix1.M43 * matrix2.M34 + matrix1.M44 * matrix2.M44;
        }

        /// <summary>
        /// Matrices are added.
        /// </summary>
        /// <param name="matrix1">The first matrix.</param>
        /// <param name="matrix2">The second matrix.</param>
        /// <returns>The sum of both matrices.</returns>
        public static TMatrix4x4 Add(TMatrix4x4 matrix1, TMatrix4x4 matrix2)
        {
            Add(ref matrix1, ref matrix2, out TMatrix4x4 result);
            return result;
        }

        /// <summary>
        /// Matrices are added.
        /// </summary>
        /// <param name="matrix1">The first matrix.</param>
        /// <param name="matrix2">The second matrix.</param>
        /// <param name="result">The sum of both matrices.</param>
        public static void Add(ref TMatrix4x4 matrix1, ref TMatrix4x4 matrix2, out TMatrix4x4 result)
        {
            result.M11 = matrix1.M11 + matrix2.M11;
            result.M12 = matrix1.M12 + matrix2.M12;
            result.M13 = matrix1.M13 + matrix2.M13;
            result.M14 = matrix1.M14 + matrix2.M14;

            result.M21 = matrix1.M21 + matrix2.M21;
            result.M22 = matrix1.M22 + matrix2.M22;
            result.M23 = matrix1.M23 + matrix2.M23;
            result.M24 = matrix1.M24 + matrix2.M24;

            result.M31 = matrix1.M31 + matrix2.M31;
            result.M32 = matrix1.M32 + matrix2.M32;
            result.M33 = matrix1.M33 + matrix2.M33;
            result.M34 = matrix1.M34 + matrix2.M34;

            result.M41 = matrix1.M41 + matrix2.M41;
            result.M42 = matrix1.M42 + matrix2.M42;
            result.M43 = matrix1.M43 + matrix2.M43;
            result.M44 = matrix1.M44 + matrix2.M44;
        }

        /// <summary>
        /// Calculates the inverse of a give matrix.
        /// </summary>
        /// <param name="matrix">The matrix to invert.</param>
        /// <returns>The inverted JMatrix.</returns>
        public static TMatrix4x4 Inverse(TMatrix4x4 matrix)
        {
            Inverse(ref matrix, out TMatrix4x4 result);
            return result;
        }

        public TFloat determinant
        {
            get
            {
                // | a b c d |     | f g h |     | e g h |     | e f h |     | e f g |
                // | e f g h | = a | j k l | - b | i k l | + c | i j l | - d | i j k |
                // | i j k l |     | n o p |     | m o p |     | m n p |     | m n o |
                // | m n o p |
                //
                //   | f g h |
                // a | j k l | = a ( f ( kp - lo ) - g ( jp - ln ) + h ( jo - kn ) )
                //   | n o p |
                //
                //   | e g h |     
                // b | i k l | = b ( e ( kp - lo ) - g ( ip - lm ) + h ( io - km ) )
                //   | m o p |     
                //
                //   | e f h |
                // c | i j l | = c ( e ( jp - ln ) - f ( ip - lm ) + h ( in - jm ) )
                //   | m n p |
                //
                //   | e f g |
                // d | i j k | = d ( e ( jo - kn ) - f ( io - km ) + g ( in - jm ) )
                //   | m n o |
                //
                // Cost of operation
                // 17 adds and 28 muls.
                //
                // add: 6 + 8 + 3 = 17
                // mul: 12 + 16 = 28

                TFloat a = M11, b = M12, c = M13, d = M14;
                TFloat e = M21, f = M22, g = M23, h = M24;
                TFloat i = M31, j = M32, k = M33, l = M34;
                TFloat m = M41, n = M42, o = M43, p = M44;

                TFloat kp_lo = k * p - l * o;
                TFloat jp_ln = j * p - l * n;
                TFloat jo_kn = j * o - k * n;
                TFloat ip_lm = i * p - l * m;
                TFloat io_km = i * o - k * m;
                TFloat in_jm = i * n - j * m;

                return a * (f * kp_lo - g * jp_ln + h * jo_kn) -
                       b * (e * kp_lo - g * ip_lm + h * io_km) +
                       c * (e * jp_ln - f * ip_lm + h * in_jm) -
                       d * (e * jo_kn - f * io_km + g * in_jm);
            }
        }

        /// <summary>
        /// Calculates the inverse of a give matrix.
        /// </summary>
        /// <param name="matrix">The matrix to invert.</param>
        /// <param name="result">The inverted JMatrix.</param>
        public static void Inverse(ref TMatrix4x4 matrix, out TMatrix4x4 result)
        {
            //                                       -1
            // If you have matrix M, inverse Matrix M   can compute
            //
            //     -1       1      
            //    M   = --------- A
            //            det(M)
            //
            // A is adjugate (adjoint) of M, where,
            //
            //      T
            // A = C
            //
            // C is Cofactor matrix of M, where,
            //           i + j
            // C   = (-1)      * det(M  )
            //  ij                    ij
            //
            //     [ a b c d ]
            // M = [ e f g h ]
            //     [ i j k l ]
            //     [ m n o p ]
            //
            // First Row
            //           2 | f g h |
            // C   = (-1)  | j k l | = + ( f ( kp - lo ) - g ( jp - ln ) + h ( jo - kn ) )
            //  11         | n o p |
            //
            //           3 | e g h |
            // C   = (-1)  | i k l | = - ( e ( kp - lo ) - g ( ip - lm ) + h ( io - km ) )
            //  12         | m o p |
            //
            //           4 | e f h |
            // C   = (-1)  | i j l | = + ( e ( jp - ln ) - f ( ip - lm ) + h ( in - jm ) )
            //  13         | m n p |
            //
            //           5 | e f g |
            // C   = (-1)  | i j k | = - ( e ( jo - kn ) - f ( io - km ) + g ( in - jm ) )
            //  14         | m n o |
            //
            // Second Row
            //           3 | b c d |
            // C   = (-1)  | j k l | = - ( b ( kp - lo ) - c ( jp - ln ) + d ( jo - kn ) )
            //  21         | n o p |
            //
            //           4 | a c d |
            // C   = (-1)  | i k l | = + ( a ( kp - lo ) - c ( ip - lm ) + d ( io - km ) )
            //  22         | m o p |
            //
            //           5 | a b d |
            // C   = (-1)  | i j l | = - ( a ( jp - ln ) - b ( ip - lm ) + d ( in - jm ) )
            //  23         | m n p |
            //
            //           6 | a b c |
            // C   = (-1)  | i j k | = + ( a ( jo - kn ) - b ( io - km ) + c ( in - jm ) )
            //  24         | m n o |
            //
            // Third Row
            //           4 | b c d |
            // C   = (-1)  | f g h | = + ( b ( gp - ho ) - c ( fp - hn ) + d ( fo - gn ) )
            //  31         | n o p |
            //
            //           5 | a c d |
            // C   = (-1)  | e g h | = - ( a ( gp - ho ) - c ( ep - hm ) + d ( eo - gm ) )
            //  32         | m o p |
            //
            //           6 | a b d |
            // C   = (-1)  | e f h | = + ( a ( fp - hn ) - b ( ep - hm ) + d ( en - fm ) )
            //  33         | m n p |
            //
            //           7 | a b c |
            // C   = (-1)  | e f g | = - ( a ( fo - gn ) - b ( eo - gm ) + c ( en - fm ) )
            //  34         | m n o |
            //
            // Fourth Row
            //           5 | b c d |
            // C   = (-1)  | f g h | = - ( b ( gl - hk ) - c ( fl - hj ) + d ( fk - gj ) )
            //  41         | j k l |
            //
            //           6 | a c d |
            // C   = (-1)  | e g h | = + ( a ( gl - hk ) - c ( el - hi ) + d ( ek - gi ) )
            //  42         | i k l |
            //
            //           7 | a b d |
            // C   = (-1)  | e f h | = - ( a ( fl - hj ) - b ( el - hi ) + d ( ej - fi ) )
            //  43         | i j l |
            //
            //           8 | a b c |
            // C   = (-1)  | e f g | = + ( a ( fk - gj ) - b ( ek - gi ) + c ( ej - fi ) )
            //  44         | i j k |
            //
            // Cost of operation
            // 53 adds, 104 muls, and 1 div.
            TFloat a = matrix.M11, b = matrix.M12, c = matrix.M13, d = matrix.M14;
            TFloat e = matrix.M21, f = matrix.M22, g = matrix.M23, h = matrix.M24;
            TFloat i = matrix.M31, j = matrix.M32, k = matrix.M33, l = matrix.M34;
            TFloat m = matrix.M41, n = matrix.M42, o = matrix.M43, p = matrix.M44;

            TFloat kp_lo = k * p - l * o;
            TFloat jp_ln = j * p - l * n;
            TFloat jo_kn = j * o - k * n;
            TFloat ip_lm = i * p - l * m;
            TFloat io_km = i * o - k * m;
            TFloat in_jm = i * n - j * m;

            TFloat a11 = (f * kp_lo - g * jp_ln + h * jo_kn);
            TFloat a12 = -(e * kp_lo - g * ip_lm + h * io_km);
            TFloat a13 = (e * jp_ln - f * ip_lm + h * in_jm);
            TFloat a14 = -(e * jo_kn - f * io_km + g * in_jm);

            TFloat det = a * a11 + b * a12 + c * a13 + d * a14;

            if (det == TFloat.Zero)
            {
                result.M11 = TFloat.PositiveInfinity;
                result.M12 = TFloat.PositiveInfinity;
                result.M13 = TFloat.PositiveInfinity;
                result.M14 = TFloat.PositiveInfinity;
                result.M21 = TFloat.PositiveInfinity;
                result.M22 = TFloat.PositiveInfinity;
                result.M23 = TFloat.PositiveInfinity;
                result.M24 = TFloat.PositiveInfinity;
                result.M31 = TFloat.PositiveInfinity;
                result.M32 = TFloat.PositiveInfinity;
                result.M33 = TFloat.PositiveInfinity;
                result.M34 = TFloat.PositiveInfinity;
                result.M41 = TFloat.PositiveInfinity;
                result.M42 = TFloat.PositiveInfinity;
                result.M43 = TFloat.PositiveInfinity;
                result.M44 = TFloat.PositiveInfinity;

            }
            else
            {
                TFloat invDet = TFloat.One / det;

                result.M11 = a11 * invDet;
                result.M21 = a12 * invDet;
                result.M31 = a13 * invDet;
                result.M41 = a14 * invDet;

                result.M12 = -(b * kp_lo - c * jp_ln + d * jo_kn) * invDet;
                result.M22 = (a * kp_lo - c * ip_lm + d * io_km) * invDet;
                result.M32 = -(a * jp_ln - b * ip_lm + d * in_jm) * invDet;
                result.M42 = (a * jo_kn - b * io_km + c * in_jm) * invDet;

                TFloat gp_ho = g * p - h * o;
                TFloat fp_hn = f * p - h * n;
                TFloat fo_gn = f * o - g * n;
                TFloat ep_hm = e * p - h * m;
                TFloat eo_gm = e * o - g * m;
                TFloat en_fm = e * n - f * m;

                result.M13 = (b * gp_ho - c * fp_hn + d * fo_gn) * invDet;
                result.M23 = -(a * gp_ho - c * ep_hm + d * eo_gm) * invDet;
                result.M33 = (a * fp_hn - b * ep_hm + d * en_fm) * invDet;
                result.M43 = -(a * fo_gn - b * eo_gm + c * en_fm) * invDet;

                TFloat gl_hk = g * l - h * k;
                TFloat fl_hj = f * l - h * j;
                TFloat fk_gj = f * k - g * j;
                TFloat el_hi = e * l - h * i;
                TFloat ek_gi = e * k - g * i;
                TFloat ej_fi = e * j - f * i;

                result.M14 = -(b * gl_hk - c * fl_hj + d * fk_gj) * invDet;
                result.M24 = (a * gl_hk - c * el_hi + d * ek_gi) * invDet;
                result.M34 = -(a * fl_hj - b * el_hi + d * ej_fi) * invDet;
                result.M44 = (a * fk_gj - b * ek_gi + c * ej_fi) * invDet;
            }
        }

        /// <summary>
        /// Multiply a matrix by a scalefactor.
        /// </summary>
        /// <param name="matrix1">The matrix.</param>
        /// <param name="scaleFactor">The scale factor.</param>
        /// <returns>A JMatrix multiplied by the scale factor.</returns>
        public static TMatrix4x4 Multiply(TMatrix4x4 matrix1, TFloat scaleFactor)
        {
            Multiply(ref matrix1, scaleFactor, out TMatrix4x4 result);
            return result;
        }

        /// <summary>
        /// Multiply a matrix by a scalefactor.
        /// </summary>
        /// <param name="matrix1">The matrix.</param>
        /// <param name="scaleFactor">The scale factor.</param>
        /// <param name="result">A JMatrix multiplied by the scale factor.</param>
        public static void Multiply(ref TMatrix4x4 matrix1, TFloat scaleFactor, out TMatrix4x4 result)
        {
            TFloat num = scaleFactor;
            result.M11 = matrix1.M11 * num;
            result.M12 = matrix1.M12 * num;
            result.M13 = matrix1.M13 * num;
            result.M14 = matrix1.M14 * num;

            result.M21 = matrix1.M21 * num;
            result.M22 = matrix1.M22 * num;
            result.M23 = matrix1.M23 * num;
            result.M24 = matrix1.M24 * num;

            result.M31 = matrix1.M31 * num;
            result.M32 = matrix1.M32 * num;
            result.M33 = matrix1.M33 * num;
            result.M34 = matrix1.M34 * num;

            result.M41 = matrix1.M41 * num;
            result.M42 = matrix1.M42 * num;
            result.M43 = matrix1.M43 * num;
            result.M44 = matrix1.M44 * num;
        }


        public static TMatrix4x4 Rotate(TQuaternion quaternion)
        {
            Rotate(ref quaternion, out TMatrix4x4 result);
            return result;
        }

        /// <summary>
        /// Creates a JMatrix representing an orientation from a quaternion.
        /// </summary>
        /// <param name="quaternion">The quaternion the matrix should be created from.</param>
        /// <param name="result">JMatrix representing an orientation.</param>
        public static void Rotate(ref TQuaternion quaternion, out TMatrix4x4 result)
        {
            // Precalculate coordinate products
            TFloat x = quaternion.x * 2;
            TFloat y = quaternion.y * 2;
            TFloat z = quaternion.z * 2;
            TFloat xx = quaternion.x * x;
            TFloat yy = quaternion.y * y;
            TFloat zz = quaternion.z * z;
            TFloat xy = quaternion.x * y;
            TFloat xz = quaternion.x * z;
            TFloat yz = quaternion.y * z;
            TFloat wx = quaternion.w * x;
            TFloat wy = quaternion.w * y;
            TFloat wz = quaternion.w * z;

            // Calculate 3x3 matrix from orthonormal basis
            result.M11 = TFloat.One - (yy + zz);
            result.M21 = xy + wz;
            result.M31 = xz - wy;
            result.M41 = TFloat.Zero;
            result.M12 = xy - wz;
            result.M22 = TFloat.One - (xx + zz);
            result.M32 = yz + wx;
            result.M42 = TFloat.Zero;
            result.M13 = xz + wy;
            result.M23 = yz - wx;
            result.M33 = TFloat.One - (xx + yy);
            result.M43 = TFloat.Zero;
            result.M14 = TFloat.Zero;
            result.M24 = TFloat.Zero;
            result.M34 = TFloat.Zero;
            result.M44 = TFloat.One;
        }

        /// <summary>
        /// Creates the transposed matrix.
        /// </summary>
        /// <param name="matrix">The matrix which should be transposed.</param>
        /// <returns>The transposed JMatrix.</returns>
        public static TMatrix4x4 Transpose(TMatrix4x4 matrix)
        {
            Transpose(ref matrix, out TMatrix4x4 result);
            return result;
        }

        /// <summary>
        /// Creates the transposed matrix.
        /// </summary>
        /// <param name="matrix">The matrix which should be transposed.</param>
        /// <param name="result">The transposed JMatrix.</param>
        public static void Transpose(ref TMatrix4x4 matrix, out TMatrix4x4 result)
        {
            result.M11 = matrix.M11;
            result.M12 = matrix.M21;
            result.M13 = matrix.M31;
            result.M14 = matrix.M41;
            result.M21 = matrix.M12;
            result.M22 = matrix.M22;
            result.M23 = matrix.M32;
            result.M24 = matrix.M42;
            result.M31 = matrix.M13;
            result.M32 = matrix.M23;
            result.M33 = matrix.M33;
            result.M34 = matrix.M43;
            result.M41 = matrix.M14;
            result.M42 = matrix.M24;
            result.M43 = matrix.M34;
            result.M44 = matrix.M44;
        }


        /// <summary>
        /// Multiplies two matrices.
        /// </summary>
        /// <param name="value1">The first matrix.</param>
        /// <param name="value2">The second matrix.</param>
        /// <returns>The product of both values.</returns>
        public static TMatrix4x4 operator *(TMatrix4x4 value1, TMatrix4x4 value2)
        {
            Multiply(ref value1, ref value2, out TMatrix4x4 result);
            return result;
        }


        public TFloat Trace()
        {
            return M11 + M22 + M33 + M44;
        }

        /// <summary>
        /// Adds two matrices.
        /// </summary>
        /// <param name="value1">The first matrix.</param>
        /// <param name="value2">The second matrix.</param>
        /// <returns>The sum of both values.</returns>
        public static TMatrix4x4 operator +(TMatrix4x4 value1, TMatrix4x4 value2)
        {
            Add(ref value1, ref value2, out TMatrix4x4 result);
            return result;
        }

        /// <summary>
        /// Returns a new matrix with the negated elements of the given matrix.
        /// </summary>
        /// <param name="value">The source matrix.</param>
        /// <returns>The negated matrix.</returns>
        public static TMatrix4x4 operator -(TMatrix4x4 value)
        {
            TMatrix4x4 result;

            result.M11 = -value.M11;
            result.M12 = -value.M12;
            result.M13 = -value.M13;
            result.M14 = -value.M14;
            result.M21 = -value.M21;
            result.M22 = -value.M22;
            result.M23 = -value.M23;
            result.M24 = -value.M24;
            result.M31 = -value.M31;
            result.M32 = -value.M32;
            result.M33 = -value.M33;
            result.M34 = -value.M34;
            result.M41 = -value.M41;
            result.M42 = -value.M42;
            result.M43 = -value.M43;
            result.M44 = -value.M44;

            return result;
        }

        /// <summary>
        /// Subtracts two matrices.
        /// </summary>
        /// <param name="value1">The first matrix.</param>
        /// <param name="value2">The second matrix.</param>
        /// <returns>The difference of both values.</returns>
        public static TMatrix4x4 operator -(TMatrix4x4 value1, TMatrix4x4 value2)
        {
            Multiply(ref value2, -TFloat.One, out value2);
            Add(ref value1, ref value2, out TMatrix4x4 result);
            return result;
        }

        public static bool operator ==(TMatrix4x4 value1, TMatrix4x4 value2)
        {
            return value1.M11 == value2.M11 &&
                value1.M12 == value2.M12 &&
                value1.M13 == value2.M13 &&
                value1.M14 == value2.M14 &&
                value1.M21 == value2.M21 &&
                value1.M22 == value2.M22 &&
                value1.M23 == value2.M23 &&
                value1.M24 == value2.M24 &&
                value1.M31 == value2.M31 &&
                value1.M32 == value2.M32 &&
                value1.M33 == value2.M33 &&
                value1.M34 == value2.M34 &&
                value1.M41 == value2.M41 &&
                value1.M42 == value2.M42 &&
                value1.M43 == value2.M43 &&
                value1.M44 == value2.M44;
        }

        public static bool operator !=(TMatrix4x4 value1, TMatrix4x4 value2)
        {
            return value1.M11 != value2.M11 ||
                value1.M12 != value2.M12 ||
                value1.M13 != value2.M13 ||
                value1.M14 != value2.M14 ||
                value1.M21 != value2.M21 ||
                value1.M22 != value2.M22 ||
                value1.M23 != value2.M23 ||
                value1.M24 != value2.M24 ||
                value1.M31 != value2.M31 ||
                value1.M32 != value2.M32 ||
                value1.M33 != value2.M33 ||
                value1.M34 != value2.M34 ||
                value1.M41 != value2.M41 ||
                value1.M42 != value2.M42 ||
                value1.M43 != value2.M43 ||
                value1.M44 != value2.M44;
        }

        public override bool Equals(object obj)
        {
            if (obj is not TMatrix4x4) return false;
            TMatrix4x4 other = (TMatrix4x4)obj;

            return M11 == other.M11 &&
                M12 == other.M12 &&
                M13 == other.M13 &&
                M14 == other.M14 &&
                M21 == other.M21 &&
                M22 == other.M22 &&
                M23 == other.M23 &&
                M24 == other.M24 &&
                M31 == other.M31 &&
                M32 == other.M32 &&
                M33 == other.M33 &&
                M34 == other.M44 &&
                M41 == other.M41 &&
                M42 == other.M42 &&
                M43 == other.M43 &&
                M44 == other.M44 ;
        }

        public override int GetHashCode()
        {
            return M11.GetHashCode() ^
                M12.GetHashCode() ^
                M13.GetHashCode() ^
                M14.GetHashCode() ^
                M21.GetHashCode() ^
                M22.GetHashCode() ^
                M23.GetHashCode() ^
                M24.GetHashCode() ^
                M31.GetHashCode() ^
                M32.GetHashCode() ^
                M33.GetHashCode() ^
                M34.GetHashCode() ^
                M41.GetHashCode() ^
                M42.GetHashCode() ^
                M43.GetHashCode() ^
                M44.GetHashCode();
        }

        /// <summary>
        /// Creates a translation matrix.
        /// </summary>
        /// <param name="xPosition">The amount to translate on the X-axis.</param>
        /// <param name="yPosition">The amount to translate on the Y-axis.</param>
        /// <param name="zPosition">The amount to translate on the Z-axis.</param>
        /// <returns>The translation matrix.</returns>
        public static TMatrix4x4 Translate(TFloat xPosition, TFloat yPosition, TFloat zPosition)
        {
            TMatrix4x4 result;

            result.M11 = TFloat.One;  result.M12 = TFloat.Zero; result.M13 = TFloat.Zero; result.M14 = xPosition;
            result.M21 = TFloat.Zero; result.M22 = TFloat.One;  result.M23 = TFloat.Zero; result.M24 = yPosition;
            result.M31 = TFloat.Zero; result.M32 = TFloat.Zero; result.M33 = TFloat.One;  result.M34 = zPosition;
            result.M41 = TFloat.Zero; result.M42 = TFloat.Zero; result.M43 = TFloat.Zero; result.M44 = TFloat.One;

            return result;
        }

        public static TMatrix4x4 Translate(TVector3 translation)
        {
            return Translate(translation.x, translation.y, translation.z);
        }

        /// <summary>
        /// Creates a scaling matrix.
        /// </summary>
        /// <param name="xScale">Value to scale by on the X-axis.</param>
        /// <param name="yScale">Value to scale by on the Y-axis.</param>
        /// <param name="zScale">Value to scale by on the Z-axis.</param>
        /// <returns>The scaling matrix.</returns>
        public static TMatrix4x4 Scale(TFloat xScale, TFloat yScale, TFloat zScale)
        {
            TMatrix4x4 result;

            result.M11 = xScale;  result.M12 = TFloat.Zero; result.M13 = TFloat.Zero; result.M14 = TFloat.Zero;
            result.M21 = TFloat.Zero; result.M22 = yScale;  result.M23 = TFloat.Zero; result.M24 = TFloat.Zero;
            result.M31 = TFloat.Zero; result.M32 = TFloat.Zero; result.M33 = zScale;  result.M34 = TFloat.Zero;
            result.M41 = TFloat.Zero; result.M42 = TFloat.Zero; result.M43 = TFloat.Zero; result.M44 = TFloat.One;

            return result;
        }

        /// <summary>
        /// Creates a scaling matrix with a center point.
        /// </summary>
        /// <param name="xScale">Value to scale by on the X-axis.</param>
        /// <param name="yScale">Value to scale by on the Y-axis.</param>
        /// <param name="zScale">Value to scale by on the Z-axis.</param>
        /// <param name="centerPoint">The center point.</param>
        /// <returns>The scaling matrix.</returns>
        public static TMatrix4x4 Scale(TFloat xScale, TFloat yScale, TFloat zScale, TVector3 centerPoint)
        {
            TMatrix4x4 result;

            TFloat tx = centerPoint.x * (TFloat.One - xScale);
            TFloat ty = centerPoint.y * (TFloat.One - yScale);
            TFloat tz = centerPoint.z * (TFloat.One - zScale);

            result.M11 = xScale;  result.M12 = TFloat.Zero; result.M13 = TFloat.Zero; result.M14 = TFloat.Zero;
            result.M21 = TFloat.Zero; result.M22 = yScale;  result.M23 = TFloat.Zero; result.M24 = TFloat.Zero;
            result.M31 = TFloat.Zero; result.M32 = TFloat.Zero; result.M33 = zScale;  result.M34 = TFloat.Zero;
            result.M41 = tx;      result.M42 = ty;      result.M43 = tz;      result.M44 = TFloat.One;

            return result;
        }

        /// <summary>
        /// Creates a scaling matrix.
        /// </summary>
        /// <param name="scales">The vector containing the amount to scale by on each axis.</param>
        /// <returns>The scaling matrix.</returns>
        public static TMatrix4x4 Scale(TVector3 scales)
        {
            return Scale(scales.x, scales.y, scales.z);
        }

        /// <summary>
        /// Creates a scaling matrix with a center point.
        /// </summary>
        /// <param name="scales">The vector containing the amount to scale by on each axis.</param>
        /// <param name="centerPoint">The center point.</param>
        /// <returns>The scaling matrix.</returns>
        public static TMatrix4x4 Scale(TVector3 scales, TVector3 centerPoint)
        {
            return Scale(scales.x, scales.y, scales.z, centerPoint);
        }

        /// <summary>
        /// Creates a uniform scaling matrix that scales equally on each axis.
        /// </summary>
        /// <param name="scale">The uniform scaling factor.</param>
        /// <returns>The scaling matrix.</returns>
        public static TMatrix4x4 Scale(TFloat scale)
        {
            return Scale(scale, scale, scale);
        }

        /// <summary>
        /// Creates a uniform scaling matrix that scales equally on each axis with a center point.
        /// </summary>
        /// <param name="scale">The uniform scaling factor.</param>
        /// <param name="centerPoint">The center point.</param>
        /// <returns>The scaling matrix.</returns>
        public static TMatrix4x4 Scale(TFloat scale, TVector3 centerPoint)
        {
            return Scale(scale, scale, scale, centerPoint);
        }

        /// <summary>
        /// Creates a matrix for rotating points around the X-axis.
        /// </summary>
        /// <param name="radians">The amount, in radians, by which to rotate around the X-axis.</param>
        /// <returns>The rotation matrix.</returns>
        public static TMatrix4x4 RotateX(TFloat radians)
        {
            TMatrix4x4 result;

            TFloat c = TMath.Cos(radians);
            TFloat s = TMath.Sin(radians);

            // [  1  0  0  0 ]
            // [  0  c  s  0 ]
            // [  0 -s  c  0 ]
            // [  0  0  0  1 ]
            result.M11 = TFloat.One;
            result.M12 = TFloat.Zero;
            result.M13 = TFloat.Zero;
            result.M14 = TFloat.Zero;
            result.M21 = TFloat.Zero;
            result.M22 = c;
            result.M23 = s;
            result.M24 = TFloat.Zero;
            result.M31 = TFloat.Zero;
            result.M32 = -s;
            result.M33 = c;
            result.M34 = TFloat.Zero;
            result.M41 = TFloat.Zero;
            result.M42 = TFloat.Zero;
            result.M43 = TFloat.Zero;
            result.M44 = TFloat.One;

            return result;
        }

        /// <summary>
        /// Creates a matrix for rotating points around the X-axis, from a center point.
        /// </summary>
        /// <param name="radians">The amount, in radians, by which to rotate around the X-axis.</param>
        /// <param name="centerPoint">The center point.</param>
        /// <returns>The rotation matrix.</returns>
        public static TMatrix4x4 RotateX(TFloat radians, TVector3 centerPoint)
        {
            TMatrix4x4 result;

            TFloat c = TMath.Cos(radians);
            TFloat s = TMath.Sin(radians);

            TFloat y = centerPoint.y * (TFloat.One - c) + centerPoint.z * s;
            TFloat z = centerPoint.z * (TFloat.One - c) - centerPoint.y * s;

            // [  1  0  0  0 ]
            // [  0  c  s  0 ]
            // [  0 -s  c  0 ]
            // [  0  y  z  1 ]
            result.M11 = TFloat.One;
            result.M12 = TFloat.Zero;
            result.M13 = TFloat.Zero;
            result.M14 = TFloat.Zero;
            result.M21 = TFloat.Zero;
            result.M22 = c;
            result.M23 = s;
            result.M24 = TFloat.Zero;
            result.M31 = TFloat.Zero;
            result.M32 = -s;
            result.M33 = c;
            result.M34 = TFloat.Zero;
            result.M41 = TFloat.Zero;
            result.M42 = y;
            result.M43 = z;
            result.M44 = TFloat.One;

            return result;
        }

        /// <summary>
        /// Creates a matrix for rotating points around the Y-axis.
        /// </summary>
        /// <param name="radians">The amount, in radians, by which to rotate around the Y-axis.</param>
        /// <returns>The rotation matrix.</returns>
        public static TMatrix4x4 RotateY(TFloat radians)
        {
            TMatrix4x4 result;

            TFloat c = TMath.Cos(radians);
            TFloat s = TMath.Sin(radians);

            // [  c  0 -s  0 ]
            // [  0  1  0  0 ]
            // [  s  0  c  0 ]
            // [  0  0  0  1 ]
            result.M11 = c;
            result.M12 = TFloat.Zero;
            result.M13 = -s;
            result.M14 = TFloat.Zero;
            result.M21 = TFloat.Zero;
            result.M22 = TFloat.One;
            result.M23 = TFloat.Zero;
            result.M24 = TFloat.Zero;
            result.M31 = s;
            result.M32 = TFloat.Zero;
            result.M33 = c;
            result.M34 = TFloat.Zero;
            result.M41 = TFloat.Zero;
            result.M42 = TFloat.Zero;
            result.M43 = TFloat.Zero;
            result.M44 = TFloat.One;

            return result;
        }

        /// <summary>
        /// Creates a matrix for rotating points around the Y-axis, from a center point.
        /// </summary>
        /// <param name="radians">The amount, in radians, by which to rotate around the Y-axis.</param>
        /// <param name="centerPoint">The center point.</param>
        /// <returns>The rotation matrix.</returns>
        public static TMatrix4x4 RotateY(TFloat radians, TVector3 centerPoint)
        {
            TMatrix4x4 result;

            TFloat c = TMath.Cos(radians);
            TFloat s = TMath.Sin(radians);

            TFloat x = centerPoint.x * (TFloat.One - c) - centerPoint.z * s;
            TFloat z = centerPoint.x * (TFloat.One - c) + centerPoint.x * s;

            // [  c  0 -s  0 ]
            // [  0  1  0  0 ]
            // [  s  0  c  0 ]
            // [  x  0  z  1 ]
            result.M11 = c;
            result.M12 = TFloat.Zero;
            result.M13 = -s;
            result.M14 = TFloat.Zero;
            result.M21 = TFloat.Zero;
            result.M22 = TFloat.One;
            result.M23 = TFloat.Zero;
            result.M24 = TFloat.Zero;
            result.M31 = s;
            result.M32 = TFloat.Zero;
            result.M33 = c;
            result.M34 = TFloat.Zero;
            result.M41 = x;
            result.M42 = TFloat.Zero;
            result.M43 = z;
            result.M44 = TFloat.One;

            return result;
        }

        /// <summary>
        /// Creates a matrix for rotating points around the Z-axis.
        /// </summary>
        /// <param name="radians">The amount, in radians, by which to rotate around the Z-axis.</param>
        /// <returns>The rotation matrix.</returns>
        public static TMatrix4x4 RotateZ(TFloat radians)
        {
            TMatrix4x4 result;

            TFloat c = TMath.Cos(radians);
            TFloat s = TMath.Sin(radians);

            // [  c  s  0  0 ]
            // [ -s  c  0  0 ]
            // [  0  0  1  0 ]
            // [  0  0  0  1 ]
            result.M11 = c;
            result.M12 = s;
            result.M13 = TFloat.Zero;
            result.M14 = TFloat.Zero;
            result.M21 = -s;
            result.M22 = c;
            result.M23 = TFloat.Zero;
            result.M24 = TFloat.Zero;
            result.M31 = TFloat.Zero;
            result.M32 = TFloat.Zero;
            result.M33 = TFloat.One;
            result.M34 = TFloat.Zero;
            result.M41 = TFloat.Zero;
            result.M42 = TFloat.Zero;
            result.M43 = TFloat.Zero;
            result.M44 = TFloat.One;

            return result;
        }

        /// <summary>
        /// Creates a matrix for rotating points around the Z-axis, from a center point.
        /// </summary>
        /// <param name="radians">The amount, in radians, by which to rotate around the Z-axis.</param>
        /// <param name="centerPoint">The center point.</param>
        /// <returns>The rotation matrix.</returns>
        public static TMatrix4x4 RotateZ(TFloat radians, TVector3 centerPoint)
        {
            TMatrix4x4 result;

            TFloat c = TMath.Cos(radians);
            TFloat s = TMath.Sin(radians);

            TFloat x = centerPoint.x * (1 - c) + centerPoint.y * s;
            TFloat y = centerPoint.y * (1 - c) - centerPoint.x * s;

            // [  c  s  0  0 ]
            // [ -s  c  0  0 ]
            // [  0  0  1  0 ]
            // [  x  y  0  1 ]
            result.M11 = c;
            result.M12 = s;
            result.M13 = TFloat.Zero;
            result.M14 = TFloat.Zero;
            result.M21 = -s;
            result.M22 = c;
            result.M23 = TFloat.Zero;
            result.M24 = TFloat.Zero;
            result.M31 = TFloat.Zero;
            result.M32 = TFloat.Zero;
            result.M33 = TFloat.One;
            result.M34 = TFloat.Zero;
            result.M41 = TFloat.Zero;
            result.M42 = TFloat.Zero;
            result.M43 = TFloat.Zero;
            result.M44 = TFloat.One;

            return result;
        }

        /// <summary>
        /// Creates a matrix which rotates around the given axis by the given angle.
        /// </summary>
        /// <param name="axis">The axis.</param>
        /// <param name="angle">The angle.</param>
        /// <param name="result">The resulting rotation matrix</param>
        public static void AxisAngle(ref TVector3 axis, TFloat angle, out TMatrix4x4 result)
        {
            // a: angle
            // x, y, z: unit vector for axis.
            //
            // Rotation matrix M can compute by using below equation.
            //
            //        T               T
            //  M = uu + (cos a)( I-uu ) + (sin a)S
            //
            // Where:
            //
            //  u = ( x, y, z )
            //
            //      [  0 -z  y ]
            //  S = [  z  0 -x ]
            //      [ -y  x  0 ]
            //
            //      [ 1 0 0 ]
            //  I = [ 0 1 0 ]
            //      [ 0 0 1 ]
            //
            //
            //     [  xx+cosa*(1-xx)   yx-cosa*yx-sina*z zx-cosa*xz+sina*y ]
            // M = [ xy-cosa*yx+sina*z    yy+cosa(1-yy)  yz-cosa*yz-sina*x ]
            //     [ zx-cosa*zx-sina*y zy-cosa*zy+sina*x   zz+cosa*(1-zz)  ]
            //
            TFloat x = axis.x, y = axis.y, z = axis.z;
            TFloat sa = TMath.Sin(angle), ca = TMath.Cos(angle);
            TFloat xx = x * x, yy = y * y, zz = z * z;
            TFloat xy = x * y, xz = x * z, yz = y * z;

            result.M11 = xx + ca * (TFloat.One - xx);
            result.M12 = xy - ca * xy + sa * z;
            result.M13 = xz - ca * xz - sa * y;
            result.M14 = TFloat.Zero;
            result.M21 = xy - ca * xy - sa * z;
            result.M22 = yy + ca * (TFloat.One - yy);
            result.M23 = yz - ca * yz + sa * x;
            result.M24 = TFloat.Zero;
            result.M31 = xz - ca * xz + sa * y;
            result.M32 = yz - ca * yz - sa * x;
            result.M33 = zz + ca * (TFloat.One - zz);
            result.M34 = TFloat.Zero;
            result.M41 = TFloat.Zero;
            result.M42 = TFloat.Zero;
            result.M43 = TFloat.Zero;
            result.M44 = TFloat.One;
        }

        /// <summary>
        /// Creates a matrix which rotates around the given axis by the given angle.
        /// </summary>
        /// <param name="axis">The axis.</param>
        /// <param name="angle">The angle.</param>
        /// <returns>The resulting rotation matrix</returns>
        public static TMatrix4x4 AngleAxis(TFloat angle, TVector3 axis)
        {
            AxisAngle(ref axis, angle, out TMatrix4x4 result);
            return result;
        }

        public override string ToString()
        {
            return string.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|{8}|{9}|{10}|{11}|{12}|{13}|{14}|{15}", 
                M11.RawValue, M12.RawValue, M13.RawValue, M14.RawValue,
                M21.RawValue, M22.RawValue, M23.RawValue, M24.RawValue,
                M31.RawValue, M32.RawValue, M33.RawValue, M34.RawValue,
                M41.RawValue, M42.RawValue, M43.RawValue, M44.RawValue);
        }

        public static void TRS(TVector3 translation, TQuaternion rotation, TVector3 scale, out TMatrix4x4 matrix)
        {
            matrix = Translate(translation) * Rotate(rotation) * Scale(scale);
        }

        public static TMatrix4x4 TRS(TVector3 translation, TQuaternion rotation, TVector3 scale)
        {
            TMatrix4x4 result;
            TRS(translation, rotation, scale, out result);
            return result;
        }

        //public static TSMatrix4x4 TransformToMatrix(ref TSTransform transform)
        //{
        //    TSMatrix4x4 result;
        //    TRS(transform.localPosition, transform.localRotation, transform.localScale, out result);
        //    return result;
        //}

    }

}