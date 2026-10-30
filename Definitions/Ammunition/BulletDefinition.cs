
using System.Collections.Generic;

namespace InventoryCoreLib
{
    public class BulletDefinition : EquipableItem, IAmmo
    {
        public BulletDefinition(
            uint id,
            string name,
            string describtion,
            double weigh_kg,
            uint price,
            string iconRef,
            string miniatureRef,
            IEffect? effect = null) :
                base(effect is null ? null : new List<IEffect> { effect })
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

        public AmmoType Ammo => AmmoType.Bullet;
        public uint MaxStackCount => MaxStackSize;
        public IReadOnlyList<IEffect> GetEffects() => Effects;
    }
}
