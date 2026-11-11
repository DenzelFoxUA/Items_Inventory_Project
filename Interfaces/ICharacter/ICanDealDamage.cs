
using CharacterMainLib;

namespace InventoryCoreLib
{
    public interface ICanDealDamage : IOwnedEquipable
    {
        public AttackComplex PrimaryAttack(IAffectable? target);
        public AttackComplex? SecondaryAttack(IAffectable? target);
    }
}
