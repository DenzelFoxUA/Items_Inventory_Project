
using System.Collections.Generic;

namespace InventoryCoreLib
{
    public class StaffDefinition : RangedWeapon
    {
        public StaffDefinition(uint id,
            string name,
            string describtion,
            double weight_kg,
            uint price,
            uint maxDurability,
            uint levelReq,
            uint physicalAttackDmg,
            uint magicAttackDmg,
            uint numOfProjectiles,
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
            EqupmentCategory = WearableItemCategory.TwoHanded;
            LevelRequired = levelReq;

            PrimaryAttack = new AttackDefinition
            {
                AttackRange = WeaponDistanceConstants.STAFF_PHYSICAL_ATTACK_DIST,
                MaxDamage = physicalAttackDmg
            };

            SecondaryAttack = new AttackDefinition
            {
                AttackRange = WeaponDistanceConstants.STAFF_MAGIC_ATTACK_DIST,
                MaxDamage = magicAttackDmg
            };

            ProjectilesCapacity = numOfProjectiles;

            Icon = iconPath;
            Miniature2D = miniaturePath;

        }
    }
}
