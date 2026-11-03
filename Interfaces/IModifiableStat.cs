
namespace InventoryCoreLib
{
    public interface IModifiableStat : IAffectable
    {
        public void Increase(uint value);
        public void Decrease(uint value);
    }

}
