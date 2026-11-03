
using System.Collections.Generic;

namespace InventoryCoreLib
{
    public class BoltDefinition : EquipableItem, IAmmo
    {
        public BoltDefinition(
        uint id,
        string name,
        string describtion,
        double weigh_kg,
        uint price,
        string iconRef,
        string miniatureRef,
        BaseEffect? effect = null) :
        base(effect is null ? null : new List<BaseEffect> { effect })
        {

            Id = id;
            Name = name;
            Descriprion = describtion;
            Weight = weigh_kg;
            Price = price;

            //stack
            IsStackable = true;
            MaxStackSize = AmmoStackConstants.AMMO_STACK_MAX_COUNT;

            //equip
            EqupmentCategory = WearableItemCategory.RightHandOnly;
            LevelRequired = 1;
            //res
            Icon = iconRef;
            Miniature2D = miniatureRef;

        }

        public AmmoType Ammo => AmmoType.Bolt;
        public uint MaxStackCount => MaxStackSize;
        public IReadOnlyList<BaseEffect> GetEffects() => Effects;
    }
}
