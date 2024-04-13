using System;
using System.Runtime.CompilerServices;

namespace TrueSync
{
    [Serializable]
    public struct TVector2Int : IEquatable<TVector2Int>
    {
        private static readonly TVector2Int s_Zero = new TVector2Int(0, 0);

        private static readonly TVector2Int s_One = new TVector2Int(1, 1);

        private static readonly TVector2Int s_Up = new TVector2Int(0, 1);

        private static readonly TVector2Int s_Down = new TVector2Int(0, -1);

        private static readonly TVector2Int s_Left = new TVector2Int(-1, 0);

        private static readonly TVector2Int s_Right = new TVector2Int(1, 0);
        public int x;

        public int y;
        public int this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                return index switch
                {
                    0 => x,
                    1 => y,
                    _ => throw new IndexOutOfRangeException($"Invalid Vector2Int index addressed: {index}!"),
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
                        throw new IndexOutOfRangeException($"Invalid Vector2Int index addressed: {index}!");
                }
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
        public int sqrMagnitude
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                return x * x + y * y;
            }
        }
        public static TVector2Int zero
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                return s_Zero;
            }
        }
        public static TVector2Int one
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                return s_One;
            }
        }
        public static TVector2Int up
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                return s_Up;
            }
        }
        public static TVector2Int down
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                return s_Down;
            }
        }
        public static TVector2Int left
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                return s_Left;
            }
        }
        public static TVector2Int right
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                return s_Right;
            }
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public TVector2Int(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Set(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TFloat Distance(TVector2Int a, TVector2Int b)
        {
            TFloat num = a.x - b.x;
            TFloat num2 = a.y - b.y;
            return TMath.Sqrt(num * num + num2 * num2);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TVector2Int Min(TVector2Int lhs, TVector2Int rhs)
        {
            return new TVector2Int(TMath.Min(lhs.x, rhs.x), TMath.Min(lhs.y, rhs.y));
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TVector2Int Max(TVector2Int lhs, TVector2Int rhs)
        {
            return new TVector2Int(TMath.Max(lhs.x, rhs.x), TMath.Max(lhs.y, rhs.y));
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TVector2Int Scale(TVector2Int a, TVector2Int b)
        {
            return new TVector2Int(a.x * b.x, a.y * b.y);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Scale(TVector2Int scale)
        {
            x *= scale.x;
            y *= scale.y;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Clamp(TVector2Int min, TVector2Int max)
        {
            x = Math.Max(min.x, x);
            x = Math.Min(max.x, x);
            y = Math.Max(min.y, y);
            y = Math.Min(max.y, y);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator TVector2(TVector2Int v)
        {
            return new TVector2(v.x, v.y);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator TVector3Int(TVector2Int v)
        {
            return new TVector3Int(v.x, v.y, 0);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TVector2Int FloorToInt(TVector2 v)
        {
            return new TVector2Int(TMath.FloorToInt(v.x), TMath.FloorToInt(v.y));
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TVector2Int CeilToInt(TVector2 v)
        {
            return new TVector2Int(TMath.CeilToInt(v.x), TMath.CeilToInt(v.y));
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TVector2Int RoundToInt(TVector2 v)
        {
            return new TVector2Int(TMath.RoundToInt(v.x), TMath.RoundToInt(v.y));
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TVector2Int operator -(TVector2Int v)
        {
            return new TVector2Int(-v.x, -v.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TVector2Int operator +(TVector2Int a, TVector2Int b)
        {
            return new TVector2Int(a.x + b.x, a.y + b.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TVector2Int operator -(TVector2Int a, TVector2Int b)
        {
            return new TVector2Int(a.x - b.x, a.y - b.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TVector2Int operator *(TVector2Int a, TVector2Int b)
        {
            return new TVector2Int(a.x * b.x, a.y * b.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TVector2Int operator *(int a, TVector2Int b)
        {
            return new TVector2Int(a * b.x, a * b.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TVector2Int operator *(TVector2Int a, int b)
        {
            return new TVector2Int(a.x * b, a.y * b);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TVector2Int operator /(TVector2Int a, int b)
        {
            return new TVector2Int(a.x / b, a.y / b);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(TVector2Int lhs, TVector2Int rhs)
        {
            return lhs.x == rhs.x && lhs.y == rhs.y;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(TVector2Int lhs, TVector2Int rhs)
        {
            return !(lhs == rhs);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly override bool Equals(object other)
        {
            if (!(other is TVector2Int))
            {
                return false;
            }

            return Equals((TVector2Int)other);
        }
        public readonly bool Equals(TVector2Int other)
        {
            return x == other.x && y == other.y;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly override int GetHashCode()
        {
            return x.GetHashCode() ^ (y.GetHashCode() << 2);
        }

        public readonly override string ToString()
        {
            return $"({x}, {y})";
        }
    }
}
