
using CharacterMainLib;
namespace InventoryCoreLib
{
    public interface IRechargeble : IAffectable
    {
        public void Recharge(uint amount);
    }
}
