
using CharacterMainLib;
using System;

namespace InventoryCoreLib
{
    public abstract class ArmorInstance<T>: DurableInstance<T>
        where T : IAffectConditionally<IAffectableCharacter>
    {
        

        public uint CurrentDefence { get; protected set; }

        public ArmorInstance(in BaseArmor armor, 
            params T[] effects) : base(armor,effects)
        {
        }

        #region [ Equip ]
        #endregion
    }
}
