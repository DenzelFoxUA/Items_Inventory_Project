
namespace InventoryCoreLib
{
    public class VitalStat : CharacterStat
    {
        private uint bareMinimum;

        public uint CurrentMax { get; protected set; }
        public uint CurrentValue { get; protected set; }


        public VitalStat(uint statingMaxValue, uint peakValue) : base(0, peakValue)
        {
            bareMinimum = statingMaxValue;
            CurrentMax = statingMaxValue;
            CurrentValue = CurrentMax;
        }

        public override string ToString()
        {
            return $"{CurrentValue}/{CurrentMax}";
        }

        //methods

        public override void Increase(uint value)
        {
            if (CurrentValue >= CurrentMax || value >= CurrentMax - CurrentValue)
            {
                CurrentValue = CurrentMax;
            }
            else
            {
                CurrentValue += value;
            }
        }

        public override void Decrease(uint value)
        {
            if (CurrentValue <= MinValue || value >= CurrentValue - MinValue)
            {
                CurrentValue = MinValue;
            }
            else
            {
                CurrentValue -= value;
            }
        }

        public void IncreaseMax(uint valueIncrement)
        {
            if (CurrentMax >= MaxValue || valueIncrement >= MaxValue - CurrentMax)
            {
                CurrentMax = MaxValue;
            }
            else
            {
                CurrentMax += valueIncrement;
            }
        }

        public void DecreaseMax(uint valueDecrement)
        {
            if (CurrentMax <= bareMinimum || valueDecrement >= CurrentMax - bareMinimum)
            {
                CurrentMax = bareMinimum;
            }
            else
            {
                CurrentMax -= valueDecrement;
            }
        }

    }
}
