
namespace InventoryCoreLib
{
    public abstract class CharacterStat : IModifiableStat
    {
        public uint MaxValue { get; protected init; }
        public uint MinValue { get; protected init; } = 0;


        public CharacterStat(uint minValue, uint maxValue)
        {
            MinValue = minValue;
            MaxValue = maxValue;
        }

        public abstract void Increase(uint value);
        public abstract void Decrease(uint value);
    }
}
