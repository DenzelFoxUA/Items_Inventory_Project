

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
            EqupmentCategory = WearableItemCategory.OneHanded;
            LevelRequired = levelReq;

            this.PrimaryAttack.AttackRange(1.0);
            PrimaryAttack.MaxDamage = attackDamage;
            SecondaryAttack.AttackRange = 1.0;

            Icon = iconPath;
            Miniature2D = miniaturePath;


        }
    }
}