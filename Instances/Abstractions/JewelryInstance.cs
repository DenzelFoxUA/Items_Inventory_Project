

using CharacterMainLib;

namespace InventoryCoreLib
{
    public abstract class JewelryInstance<T> : EquipableInstance<T>
        where T : IAffectConditionally<IAffectableCharacter>
    {
        public BaseArmor Armor => (BaseArmor)Definition;

        public uint CurrentDefence { get; protected set; }

        public JewelryInstance(in EquipableItem jewelry,
            params T[] effects) : base(jewelry, effects)
        {
        }

    }
}
