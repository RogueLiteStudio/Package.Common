using System.Runtime.CompilerServices;

namespace TrueSync
{
    public struct TRay
    {
        private TVector3 m_Origin;
        private TVector3 m_Direction;

        public TVector3 origin
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                return m_Origin;
            }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                m_Origin = value;
            }
        }
        public TVector3 direction
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                return m_Direction;
            }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                m_Direction = value.normalized;
            }
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public TRay(TVector3 origin, TVector3 direction)
        {
            m_Origin = origin;
            m_Direction = direction.normalized;
        }
        public readonly TVector3 GetPoint(float distance)
        {
            return m_Origin + m_Direction * distance;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly string ToString()
        {
            return string.Format("Origin: {0}, Dir: {1}", m_Origin, m_Direction);
        }
    }
}
