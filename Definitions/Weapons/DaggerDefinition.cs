

using System.Collections.Generic;

namespace InventoryCoreLib
{
    public class DaggerDefinition : BaseWeapon
    {
        public DaggerDefinition(uint id, 
            string name, 
            string describtion, 
            double weight_kg,
            uint price,
            uint maxDurability,
            uint levelReq,
            uint attackDamage,
            string iconPath,
            string miniaturePath,
            List<IEffect>? effects = null) : base(effects)
        {
            Id = id;
            Name = name;
            Descriprion = describtion;
            Weight = weight_kg;
            Price = price;
            IsStackable = false;
            MaxStackSize = 1;
            MaxDurability = maxDurability;
            EqupmentCategory = WearableItemCategory.OneHanded;
            LevelRequired = levelReq;

            PrimaryAttack = new AttackDefinition 
            { 
                AttackRange = WeaponDistanceConstants.DAGGER_PHYSICAL_ATTACK_DIST, 
                MaxDamage = attackDamage 
            };

            SecondaryAttack = null;

            Icon = iconPath;
            Miniature2D = miniaturePath;

        }
    }
}