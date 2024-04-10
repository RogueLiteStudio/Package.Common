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
    /// A Quaternion representing an orientation.
    /// </summary>
    [Serializable]
    public struct TQuaternion
    {

        /// <summary>The X component of the quaternion.</summary>
        public TFloat x;
        /// <summary>The Y component of the quaternion.</summary>
        public TFloat y;
        /// <summary>The Z component of the quaternion.</summary>
        public TFloat z;
        /// <summary>The W component of the quaternion.</summary>
        public TFloat w;

        public static readonly TQuaternion identity;

        static TQuaternion()
        {
            identity = new TQuaternion(0, 0, 0, 1);
        }

        /// <summary>
        /// Initializes a new instance of the JQuaternion structure.
        /// </summary>
        /// <param name="x">The X component of the quaternion.</param>
        /// <param name="y">The Y component of the quaternion.</param>
        /// <param name="z">The Z component of the quaternion.</param>
        /// <param name="w">The W component of the quaternion.</param>
        public TQuaternion(TFloat x, TFloat y, TFloat z, TFloat w)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = w;
        }

        public void Set(TFloat new_x, TFloat new_y, TFloat new_z, TFloat new_w)
        {
            x = new_x;
            y = new_y;
            z = new_z;
            w = new_w;
        }

        public void SetFromToRotation(TVector3 fromDirection, TVector3 toDirection)
        {
            TQuaternion targetRotation = FromToRotation(fromDirection, toDirection);
            Set(targetRotation.x, targetRotation.y, targetRotation.z, targetRotation.w);
        }

        public TVector3 eulerAngles
        {
            get
            {
                TVector3 result = new TVector3();

                TFloat ysqr = y * y;
                TFloat t0 = -2.0f * (ysqr + z * z) + 1.0f;
                TFloat t1 = +2.0f * (x * y - w * z);
                TFloat t2 = -2.0f * (x * z + w * y);
                TFloat t3 = +2.0f * (y * z - w * x);
                TFloat t4 = -2.0f * (x * x + ysqr) + 1.0f;

                t2 = t2 > 1.0f ? 1.0f : t2;
                t2 = t2 < -1.0f ? -1.0f : t2;

                result.x = TFloat.Atan2(t3, t4) * TFloat.Rad2Deg;
                result.y = TFloat.Asin(t2) * TFloat.Rad2Deg;
                result.z = TFloat.Atan2(t1, t0) * TFloat.Rad2Deg;

                return result * -1;
            }
        }

        public static TFloat Angle(TQuaternion a, TQuaternion b)
        {
            TQuaternion aInv = Inverse(a);
            TQuaternion f = b * aInv;

            TFloat angle = TFloat.Acos(f.w) * 2 * TFloat.Rad2Deg;

            if (angle > 180)
            {
                angle = 360 - angle;
            }

            return angle;
        }

        /// <summary>
        /// Quaternions are added.
        /// </summary>
        /// <param name="quaternion1">The first quaternion.</param>
        /// <param name="quaternion2">The second quaternion.</param>
        /// <returns>The sum of both quaternions.</returns>
        public static TQuaternion Add(TQuaternion quaternion1, TQuaternion quaternion2)
        {
            Add(ref quaternion1, ref quaternion2, out TQuaternion result);
            return result;
        }

        public static TQuaternion LookRotation(TVector3 forward)
        {
            return CreateFromMatrix(TMatrix.LookAt(forward, TVector3.up));
        }

        public static TQuaternion LookRotation(TVector3 forward, TVector3 upwards)
        {
            return CreateFromMatrix(TMatrix.LookAt(forward, upwards));
        }

        public static TQuaternion Slerp(TQuaternion from, TQuaternion to, TFloat t)
        {
            t = TMath.Clamp(t, 0, 1);

            TFloat dot = Dot(from, to);

            if (dot < 0.0f)
            {
                to = Multiply(to, -1);
                dot = -dot;
            }

            TFloat halfTheta = TFloat.Acos(dot);

            return Multiply(Multiply(from, TFloat.Sin((1 - t) * halfTheta)) + Multiply(to, TFloat.Sin(t * halfTheta)), 1 / TFloat.Sin(halfTheta));
        }

        public static TQuaternion RotateTowards(TQuaternion from, TQuaternion to, TFloat maxDegreesDelta)
        {
            TFloat dot = Dot(from, to);

            if (dot < 0.0f)
            {
                to = Multiply(to, -1);
                dot = -dot;
            }

            TFloat halfTheta = TFloat.Acos(dot);
            TFloat theta = halfTheta * 2;

            maxDegreesDelta *= TFloat.Deg2Rad;

            if (maxDegreesDelta >= theta)
            {
                return to;
            }

            maxDegreesDelta /= theta;

            return Multiply(Multiply(from, TFloat.Sin((1 - maxDegreesDelta) * halfTheta)) + Multiply(to, TFloat.Sin(maxDegreesDelta * halfTheta)), 1 / TFloat.Sin(halfTheta));
        }

        public static TQuaternion Euler(TFloat x, TFloat y, TFloat z)
        {
            x *= TFloat.Deg2Rad;
            y *= TFloat.Deg2Rad;
            z *= TFloat.Deg2Rad;

            CreateFromYawPitchRoll(y, x, z, out TQuaternion rotation);

            return rotation;
        }

        public static TQuaternion Euler(TVector3 eulerAngles)
        {
            return Euler(eulerAngles.x, eulerAngles.y, eulerAngles.z);
        }

        public static TQuaternion AngleAxis(TFloat angle, TVector3 axis)
        {
            axis *= TFloat.Deg2Rad;
            axis.Normalize();

            TFloat halfAngle = angle * TFloat.Deg2Rad * TFloat.Half;

            TQuaternion rotation;
            TFloat sin = TFloat.Sin(halfAngle);

            rotation.x = axis.x * sin;
            rotation.y = axis.y * sin;
            rotation.z = axis.z * sin;
            rotation.w = TFloat.Cos(halfAngle);

            return rotation;
        }

        public static void CreateFromYawPitchRoll(TFloat yaw, TFloat pitch, TFloat roll, out TQuaternion result)
        {
            TFloat num9 = roll * TFloat.Half;
            TFloat num6 = TFloat.Sin(num9);
            TFloat num5 = TFloat.Cos(num9);
            TFloat num8 = pitch * TFloat.Half;
            TFloat num4 = TFloat.Sin(num8);
            TFloat num3 = TFloat.Cos(num8);
            TFloat num7 = yaw * TFloat.Half;
            TFloat num2 = TFloat.Sin(num7);
            TFloat num = TFloat.Cos(num7);
            result.x = ((num * num4) * num5) + ((num2 * num3) * num6);
            result.y = ((num2 * num3) * num5) - ((num * num4) * num6);
            result.z = ((num * num3) * num6) - ((num2 * num4) * num5);
            result.w = ((num * num3) * num5) + ((num2 * num4) * num6);
        }

        /// <summary>
        /// Quaternions are added.
        /// </summary>
        /// <param name="quaternion1">The first quaternion.</param>
        /// <param name="quaternion2">The second quaternion.</param>
        /// <param name="result">The sum of both quaternions.</param>
        public static void Add(ref TQuaternion quaternion1, ref TQuaternion quaternion2, out TQuaternion result)
        {
            result.x = quaternion1.x + quaternion2.x;
            result.y = quaternion1.y + quaternion2.y;
            result.z = quaternion1.z + quaternion2.z;
            result.w = quaternion1.w + quaternion2.w;
        }

        public static TQuaternion Conjugate(TQuaternion value)
        {
            TQuaternion quaternion;
            quaternion.x = -value.x;
            quaternion.y = -value.y;
            quaternion.z = -value.z;
            quaternion.w = value.w;
            return quaternion;
        }

        public static TFloat Dot(TQuaternion a, TQuaternion b)
        {
            return a.w * b.w + a.x * b.x + a.y * b.y + a.z * b.z;
        }

        public static TQuaternion Inverse(TQuaternion rotation)
        {
            TFloat invNorm = TFloat.One / ((rotation.x * rotation.x) + (rotation.y * rotation.y) + (rotation.z * rotation.z) + (rotation.w * rotation.w));
            return Multiply(Conjugate(rotation), invNorm);
        }

        public static TQuaternion FromToRotation(TVector3 fromVector, TVector3 toVector)
        {
            TVector3 w = TVector3.Cross(fromVector, toVector);
            TQuaternion q = new TQuaternion(w.x, w.y, w.z, TVector3.Dot(fromVector, toVector));
            q.w += TFloat.Sqrt(fromVector.sqrMagnitude * toVector.sqrMagnitude);
            q.Normalize();

            return q;
        }

        public static TQuaternion Lerp(TQuaternion a, TQuaternion b, TFloat t)
        {
            t = TMath.Clamp(t, TFloat.Zero, TFloat.One);

            return LerpUnclamped(a, b, t);
        }

        public static TQuaternion LerpUnclamped(TQuaternion a, TQuaternion b, TFloat t)
        {
            TQuaternion result = Multiply(a, 1 - t) + Multiply(b, t);
            result.Normalize();

            return result;
        }

        /// <summary>
        /// Quaternions are subtracted.
        /// </summary>
        /// <param name="quaternion1">The first quaternion.</param>
        /// <param name="quaternion2">The second quaternion.</param>
        /// <returns>The difference of both quaternions.</returns>
        public static TQuaternion Subtract(TQuaternion quaternion1, TQuaternion quaternion2)
        {
            Subtract(ref quaternion1, ref quaternion2, out TQuaternion result);
            return result;
        }

        /// <summary>
        /// Quaternions are subtracted.
        /// </summary>
        /// <param name="quaternion1">The first quaternion.</param>
        /// <param name="quaternion2">The second quaternion.</param>
        /// <param name="result">The difference of both quaternions.</param>
        public static void Subtract(ref TQuaternion quaternion1, ref TQuaternion quaternion2, out TQuaternion result)
        {
            result.x = quaternion1.x - quaternion2.x;
            result.y = quaternion1.y - quaternion2.y;
            result.z = quaternion1.z - quaternion2.z;
            result.w = quaternion1.w - quaternion2.w;
        }

        /// <summary>
        /// Multiply two quaternions.
        /// </summary>
        /// <param name="quaternion1">The first quaternion.</param>
        /// <param name="quaternion2">The second quaternion.</param>
        /// <returns>The product of both quaternions.</returns>
        public static TQuaternion Multiply(TQuaternion quaternion1, TQuaternion quaternion2)
        {
            Multiply(ref quaternion1, ref quaternion2, out TQuaternion result);
            return result;
        }

        /// <summary>
        /// Multiply two quaternions.
        /// </summary>
        /// <param name="quaternion1">The first quaternion.</param>
        /// <param name="quaternion2">The second quaternion.</param>
        /// <param name="result">The product of both quaternions.</param>
        public static void Multiply(ref TQuaternion quaternion1, ref TQuaternion quaternion2, out TQuaternion result)
        {
            TFloat x = quaternion1.x;
            TFloat y = quaternion1.y;
            TFloat z = quaternion1.z;
            TFloat w = quaternion1.w;
            TFloat num4 = quaternion2.x;
            TFloat num3 = quaternion2.y;
            TFloat num2 = quaternion2.z;
            TFloat num = quaternion2.w;
            TFloat num12 = (y * num2) - (z * num3);
            TFloat num11 = (z * num4) - (x * num2);
            TFloat num10 = (x * num3) - (y * num4);
            TFloat num9 = ((x * num4) + (y * num3)) + (z * num2);
            result.x = ((x * num) + (num4 * w)) + num12;
            result.y = ((y * num) + (num3 * w)) + num11;
            result.z = ((z * num) + (num2 * w)) + num10;
            result.w = (w * num) - num9;
        }

        /// <summary>
        /// Scale a quaternion
        /// </summary>
        /// <param name="quaternion1">The quaternion to scale.</param>
        /// <param name="scaleFactor">Scale factor.</param>
        /// <returns>The scaled quaternion.</returns>
        public static TQuaternion Multiply(TQuaternion quaternion1, TFloat scaleFactor)
        {
            Multiply(ref quaternion1, scaleFactor, out TQuaternion result);
            return result;
        }

        /// <summary>
        /// Scale a quaternion
        /// </summary>
        /// <param name="quaternion1">The quaternion to scale.</param>
        /// <param name="scaleFactor">Scale factor.</param>
        /// <param name="result">The scaled quaternion.</param>
        public static void Multiply(ref TQuaternion quaternion1, TFloat scaleFactor, out TQuaternion result)
        {
            result.x = quaternion1.x * scaleFactor;
            result.y = quaternion1.y * scaleFactor;
            result.z = quaternion1.z * scaleFactor;
            result.w = quaternion1.w * scaleFactor;
        }

        /// <summary>
        /// Sets the length of the quaternion to one.
        /// </summary>
        public void Normalize()
        {
            TFloat num2 = (x * x) + (y * y) + (z * z) + (w * w);
            TFloat num = 1 / (TFloat.Sqrt(num2));
            x *= num;
            y *= num;
            z *= num;
            w *= num;
        }

        /// <summary>
        /// Creates a quaternion from a matrix.
        /// </summary>
        /// <param name="matrix">A matrix representing an orientation.</param>
        /// <returns>JQuaternion representing an orientation.</returns>
        public static TQuaternion CreateFromMatrix(TMatrix matrix)
        {
            CreateFromMatrix(ref matrix, out TQuaternion result);
            return result;
        }

        /// <summary>
        /// Creates a quaternion from a matrix.
        /// </summary>
        /// <param name="matrix">A matrix representing an orientation.</param>
        /// <param name="result">JQuaternion representing an orientation.</param>
        public static void CreateFromMatrix(ref TMatrix matrix, out TQuaternion result)
        {
            TFloat num8 = (matrix.M11 + matrix.M22) + matrix.M33;
            if (num8 > TFloat.Zero)
            {
                TFloat num = TFloat.Sqrt((num8 + TFloat.One));
                result.w = num * TFloat.Half;
                num = TFloat.Half / num;
                result.x = (matrix.M23 - matrix.M32) * num;
                result.y = (matrix.M31 - matrix.M13) * num;
                result.z = (matrix.M12 - matrix.M21) * num;
            }
            else if ((matrix.M11 >= matrix.M22) && (matrix.M11 >= matrix.M33))
            {
                TFloat num7 = TFloat.Sqrt((((TFloat.One + matrix.M11) - matrix.M22) - matrix.M33));
                TFloat num4 = TFloat.Half / num7;
                result.x = TFloat.Half * num7;
                result.y = (matrix.M12 + matrix.M21) * num4;
                result.z = (matrix.M13 + matrix.M31) * num4;
                result.w = (matrix.M23 - matrix.M32) * num4;
            }
            else if (matrix.M22 > matrix.M33)
            {
                TFloat num6 = TFloat.Sqrt((((TFloat.One + matrix.M22) - matrix.M11) - matrix.M33));
                TFloat num3 = TFloat.Half / num6;
                result.x = (matrix.M21 + matrix.M12) * num3;
                result.y = TFloat.Half * num6;
                result.z = (matrix.M32 + matrix.M23) * num3;
                result.w = (matrix.M31 - matrix.M13) * num3;
            }
            else
            {
                TFloat num5 = TFloat.Sqrt((((TFloat.One + matrix.M33) - matrix.M11) - matrix.M22));
                TFloat num2 = TFloat.Half / num5;
                result.x = (matrix.M31 + matrix.M13) * num2;
                result.y = (matrix.M32 + matrix.M23) * num2;
                result.z = TFloat.Half * num5;
                result.w = (matrix.M12 - matrix.M21) * num2;
            }
        }

        /// <summary>
        /// Multiply two quaternions.
        /// </summary>
        /// <param name="value1">The first quaternion.</param>
        /// <param name="value2">The second quaternion.</param>
        /// <returns>The product of both quaternions.</returns>
        public static TQuaternion operator *(TQuaternion value1, TQuaternion value2)
        {
            Multiply(ref value1, ref value2, out TQuaternion result);
            return result;
        }

        /// <summary>
        /// Add two quaternions.
        /// </summary>
        /// <param name="value1">The first quaternion.</param>
        /// <param name="value2">The second quaternion.</param>
        /// <returns>The sum of both quaternions.</returns>
        public static TQuaternion operator +(TQuaternion value1, TQuaternion value2)
        {
            Add(ref value1, ref value2, out TQuaternion result);
            return result;
        }

        /// <summary>
        /// Subtract two quaternions.
        /// </summary>
        /// <param name="value1">The first quaternion.</param>
        /// <param name="value2">The second quaternion.</param>
        /// <returns>The difference of both quaternions.</returns>
        public static TQuaternion operator -(TQuaternion value1, TQuaternion value2)
        {
            Subtract(ref value1, ref value2, out TQuaternion result);
            return result;
        }

        /**
         *  @brief Rotates a {@link TSVector} by the {@link TSQuanternion}.
         **/
        public static TVector3 operator *(TQuaternion quat, TVector3 vec)
        {
            TFloat num = quat.x * 2f;
            TFloat num2 = quat.y * 2f;
            TFloat num3 = quat.z * 2f;
            TFloat num4 = quat.x * num;
            TFloat num5 = quat.y * num2;
            TFloat num6 = quat.z * num3;
            TFloat num7 = quat.x * num2;
            TFloat num8 = quat.x * num3;
            TFloat num9 = quat.y * num3;
            TFloat num10 = quat.w * num;
            TFloat num11 = quat.w * num2;
            TFloat num12 = quat.w * num3;

            TVector3 result;
            result.x = (1f - (num5 + num6)) * vec.x + (num7 - num12) * vec.y + (num8 + num11) * vec.z;
            result.y = (num7 + num12) * vec.x + (1f - (num4 + num6)) * vec.y + (num9 - num10) * vec.z;
            result.z = (num8 - num11) * vec.x + (num9 + num10) * vec.y + (1f - (num4 + num5)) * vec.z;

            return result;
        }

        public override string ToString()
        {
            return string.Format("({0:f1}, {1:f1}, {2:f1}, {3:f1})", x.AsFloat(), y.AsFloat(), z.AsFloat(), w.AsFloat());
        }

    }
}
