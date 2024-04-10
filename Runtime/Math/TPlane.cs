using System.Runtime.CompilerServices;

namespace TrueSync
{
    public struct TPlane
    {
        private TVector3 m_Normal;
        private TFloat m_Distance;

        public TVector3 normal
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                return m_Normal;
            }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                m_Normal = value;
            }
        }
        public TFloat distance
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                return m_Distance;
            }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                m_Distance = value;
            }
        }
        public TPlane flipped
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                return new TPlane(-m_Normal, - m_Distance);
            }
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public TPlane(TVector3 inNormal, TVector3 inPoint)
        {
            m_Normal = TVector3.Normalize(inNormal);
            m_Distance = - TVector3.Dot(m_Normal, inPoint);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public TPlane(TVector3 inNormal, TFloat d)
        {
            m_Normal = TVector3.Normalize(inNormal);
            m_Distance = d;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public TPlane(TVector3 a, TVector3 b, TVector3 c)
        {
            m_Normal = TVector3.Normalize(TVector3.Cross(b - a, c - a));
            m_Distance = - TVector3.Dot(m_Normal, a);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SetNormalAndPosition(TVector3 inNormal, TVector3 inPoint)
        {
            m_Normal = TVector3.Normalize(inNormal);
            m_Distance = - TVector3.Dot(m_Normal, inPoint);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Set3Points(TVector3 a, TVector3 b, TVector3 c)
        {
            m_Normal = TVector3.Normalize(TVector3.Cross(b - a, c - a));
            m_Distance = - TVector3.Dot(m_Normal, a);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Flip()
        {
            m_Normal = -m_Normal;
            m_Distance = - m_Distance;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Translate(TVector3 translation)
        {
            m_Distance += TVector3.Dot(m_Normal, translation);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TPlane Translate(TPlane plane, TVector3 translation)
        {
            return new TPlane(plane.m_Normal, plane.m_Distance += TVector3.Dot(plane.m_Normal, translation));
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public TVector3 ClosestPointOnPlane(TVector3 point)
        {
            TFloat num = TVector3.Dot(m_Normal, point) + m_Distance;
            return point - m_Normal * num;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public TFloat GetDistanceToPoint(TVector3 point)
        {
            return TVector3.Dot(m_Normal, point) + m_Distance;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool GetSide(TVector3 point)
        {
            return TVector3.Dot(m_Normal, point) + m_Distance > TFloat.Zero;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool SameSide(TVector3 inPt0, TVector3 inPt1)
        {
            TFloat distanceToPoint = GetDistanceToPoint(inPt0);
            TFloat distanceToPoint2 = GetDistanceToPoint(inPt1);
            return (distanceToPoint > 0f && distanceToPoint2 > 0f) || (distanceToPoint <= 0f && distanceToPoint2 <= 0f);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Raycast(TRay ray, out TFloat enter)
        {
            TFloat num = TVector3.Dot(ray.direction, m_Normal);
            TFloat num2 = 0f - TVector3.Dot(ray.origin, m_Normal) - m_Distance;
            if (num == TFloat.Zero)
            {
                enter = 0f;
                return false;
            }

            enter = num2 / num;
            return enter > 0f;
        }

        public override string ToString()
        {
            return string.Format("(normal:{0}, distance:{1})", m_Normal, m_Distance);
        }
    }
}
