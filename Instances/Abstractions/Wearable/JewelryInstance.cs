

using CharacterMainLib;

namespace InventoryCoreLib
{
    public abstract class JewelryInstance<Effect, Target> : EquipableInstance<Effect, Target>
        where Effect : class, IAffectConditionally<Target>
        where Target : class, IAffectableCharacter
    {

        public JewelryInstance(in EquipableItem jewelry,
            params Effect[] effects) : base(jewelry, effects)
        {
        }

        public override void Update(){}

    }
}
