using System;
using System.Runtime.CompilerServices;

namespace TrueSync
{
    [Serializable]
    public struct TVector3Int : IEquatable<TVector3Int>
    {
        private static readonly TVector3Int s_Zero = new TVector3Int(0, 0, 0);

        private static readonly TVector3Int s_One = new TVector3Int(1, 1, 1);

        private static readonly TVector3Int s_Up = new TVector3Int(0, 1, 0);

        private static readonly TVector3Int s_Down = new TVector3Int(0, -1, 0);

        private static readonly TVector3Int s_Left = new TVector3Int(-1, 0, 0);

        private static readonly TVector3Int s_Right = new TVector3Int(1, 0, 0);

        private static readonly TVector3Int s_Forward = new TVector3Int(0, 0, 1);

        private static readonly TVector3Int s_Back = new TVector3Int(0, 0, -1);
        public int x;
        public int y;
        public int z;
        public int this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                return index switch
                {
                    0 => x,
                    1 => y,
                    2 => z,
                    _ => throw new IndexOutOfRangeException(string.Format("Invalid Vector3Int index addressed: {0}!", index)),
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
                        throw new IndexOutOfRangeException(string.Format("Invalid Vector3Int index addressed: {0}!", index));
                }
            }
        }
        public TFloat magnitude
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                return TMath.Sqrt(x * x + y * y + z * z);
            }
        }
        public int sqrMagnitude
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                return x * x + y * y + z * z;
            }
        }
        public static TVector3Int zero
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                return s_Zero;
            }
        }
        public static TVector3Int one
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                return s_One;
            }
        }
        public static TVector3Int up
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                return s_Up;
            }
        }
        public static TVector3Int down
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                return s_Down;
            }
        }
        public static TVector3Int left
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                return s_Left;
            }
        }
        public static TVector3Int right
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                return s_Right;
            }
        }
        public static TVector3Int forward
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                return s_Forward;
            }
        }
        public static TVector3Int back
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                return s_Back;
            }
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public TVector3Int(int x, int y)
        {
            this.x = x;
            this.y = y;
            z = 0;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public TVector3Int(int x, int y, int z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
        public void Set(int x, int y, int z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TFloat Distance(TVector3Int a, TVector3Int b)
        {
            return (a - b).magnitude;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TVector3Int Min(TVector3Int lhs, TVector3Int rhs)
        {
            return new TVector3Int(Math.Min(lhs.x, rhs.x), Math.Min(lhs.y, rhs.y), Math.Min(lhs.z, rhs.z));
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TVector3Int Max(TVector3Int lhs, TVector3Int rhs)
        {
            return new TVector3Int(Math.Max(lhs.x, rhs.x), Math.Max(lhs.y, rhs.y), Math.Max(lhs.z, rhs.z));
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TVector3Int Scale(TVector3Int a, TVector3Int b)
        {
            return new TVector3Int(a.x * b.x, a.y * b.y, a.z * b.z);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Scale(TVector3Int scale)
        {
            x *= scale.x;
            y *= scale.y;
            z *= scale.z;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Clamp(TVector3Int min, TVector3Int max)
        {
            x = Math.Max(min.x, x);
            x = Math.Min(max.x, x);
            y = Math.Max(min.y, y);
            y = Math.Min(max.y, y);
            z = Math.Max(min.z, z);
            z = Math.Min(max.z, z);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator TVector3(TVector3Int v)
        {
            return new TVector3(v.x, v.y, v.z);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator TVector2Int(TVector3Int v)
        {
            return new TVector2Int(v.x, v.y);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TVector3Int FloorToInt(TVector3 v)
        {
            return new TVector3Int(TMath.FloorToInt(v.x), TMath.FloorToInt(v.y), TMath.FloorToInt(v.z));
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TVector3Int CeilToInt(TVector3 v)
        {
            return new TVector3Int(TMath.CeilToInt(v.x), TMath.CeilToInt(v.y), TMath.CeilToInt(v.z));
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TVector3Int RoundToInt(TVector3 v)
        {
            return new TVector3Int(TMath.RoundToInt(v.x), TMath.RoundToInt(v.y), TMath.RoundToInt(v.z));
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TVector3Int operator +(TVector3Int a, TVector3Int b)
        {
            return new TVector3Int(a.x + b.x, a.y + b.y, a.z + b.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TVector3Int operator -(TVector3Int a, TVector3Int b)
        {
            return new TVector3Int(a.x - b.x, a.y - b.y, a.z - b.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TVector3Int operator *(TVector3Int a, TVector3Int b)
        {
            return new TVector3Int(a.x * b.x, a.y * b.y, a.z * b.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TVector3Int operator -(TVector3Int a)
        {
            return new TVector3Int(-a.x, -a.y, -a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TVector3Int operator *(TVector3Int a, int b)
        {
            return new TVector3Int(a.x * b, a.y * b, a.z * b);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TVector3Int operator *(int a, TVector3Int b)
        {
            return new TVector3Int(a * b.x, a * b.y, a * b.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TVector3Int operator /(TVector3Int a, int b)
        {
            return new TVector3Int(a.x / b, a.y / b, a.z / b);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(TVector3Int lhs, TVector3Int rhs)
        {
            return lhs.x == rhs.x && lhs.y == rhs.y && lhs.z == rhs.z;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(TVector3Int lhs, TVector3Int rhs)
        {
            return !(lhs == rhs);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly override bool Equals(object other)
        {
            if (!(other is TVector3Int))
            {
                return false;
            }

            return Equals((TVector3Int)other);
        }
        public readonly bool Equals(TVector3Int other)
        {
            throw new NotImplementedException();
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode()
        {
            int hashCode = y.GetHashCode();
            int hashCode2 = z.GetHashCode();
            return x.GetHashCode() ^ (hashCode << 4) ^ (hashCode >> 28) ^ (hashCode2 >> 4) ^ (hashCode2 << 28);
        }
        public readonly override string ToString()
        {
            return string.Format($"({x}, {y}, {z})");
        }
    }
}
