
using System.Collections.Generic;

namespace InventoryCoreLib
{
    public abstract class EquipableInstance : BaseItemInstance
    {
        private EquipableItem EquipableDefinition => (EquipableItem)Definition;

        public bool IsEquipped { get; protected set; } = false;
        public bool EffectsAreApplyed { get; protected set; } = false;

        public EquipableInstance(EquipableItem definition) 
            : base(definition)
        {
        }

        
    }
}
