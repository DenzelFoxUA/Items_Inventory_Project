
using CharacterMainLib;

namespace InventoryCoreLib
{
    public interface IAttack
    {
        public void PrimaryAttack(ref IAffectable? target, double distanceToTarget);
        public void SecondaryAttack(ref IAffectable? target, double distanceToTarget);
    }
}
