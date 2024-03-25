using UnityEngine.UIElements;

namespace PropertyEditor
{
    public class RangeIntegerField : LongField
    {
        public long MaxVaue { get; set; } = int.MaxValue;
        public long MinVaue { get; set; } = int.MinValue;

        public RangeIntegerField():base()
        {
        }

        public RangeIntegerField(string label, int maxLength = -1)
            : base(label, maxLength)
        {
        }
        protected override long StringToValue(string str)
        {
            var v = base.StringToValue(str);
            if (v < MinVaue)
            {
                v = MinVaue;
                SetValueWithoutNotify(v);
            }
            if (v > MaxVaue)
            {
                v = MaxVaue;
                SetValueWithoutNotify(v);
            }
            return v;
        }

        protected override string ValueToString(long v)
        {
            if (v < MinVaue)
                v = MinVaue;
            if (v > MaxVaue)
                v = MaxVaue;
            return base.ValueToString(v);
        }
    }
}
