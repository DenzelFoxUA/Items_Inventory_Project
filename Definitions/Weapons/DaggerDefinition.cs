

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
            string placementCategory,
            bool isIndestructible,
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
            
            LevelRequired = levelReq;
            MaxDurability = maxDurability;
            IsIndestructible = isIndestructible;
            IsTwoHanded = false;
            EqupmentCategory = "Weapon";

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