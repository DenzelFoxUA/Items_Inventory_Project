

using System.Collections.Generic;
using System.Xml.Linq;

namespace InventoryCoreLib
{
    public class BowDefinition: RangedWeapon
    {
        public BowDefinition(uint id,
            string name,
            string describtion,
            string equipCategory,
            double weight_kg,
            uint price,
            uint maxDurability,
            uint levelReq,
            uint physicalAttackDmg,
            string iconPath,
            string miniaturePath)
        {
            Id = id;
            Name = name;
            Descriprion = describtion;
            Weight = weight_kg;
            Price = price;
            IsStackable = false;
            MaxStackSize = 1;
            MaxDurability = maxDurability;
            EqupmentCategory = equipCategory;
            LevelRequired = levelReq;
            ProjectilesCapacity = 1;

            IsTwoHanded = false;

            //attack set
            PrimaryAttack = new AttackDefinition
            {
                AttackRange = WeaponDistanceConstants.BOW_ATTACK_DIST,
                MaxDamage = physicalAttackDmg
            };

            SecondaryAttack = null;

            ProjectilesCapacity = 1;

            Icon = iconPath;
            Miniature2D = miniaturePath;

        }
    }
}
