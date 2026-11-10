
using CharacterMainLib;
using System;

namespace InventoryCoreLib
{
    public abstract class ArmorInstance<Effect, Target>: DurableInstance<Effect,Target>
        where Effect : class, IAffectConditionally<Target>
        where Target : class, IAffectableCharacter
    {
        

        public uint CurrentDefence { get; protected set; }

        public ArmorInstance(in BaseArmor armor, 
            params Effect[] effects) : base(armor,effects)
        {
        }

    }
}
