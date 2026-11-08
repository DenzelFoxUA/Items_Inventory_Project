

using CharacterMainLib;

namespace InventoryCoreLib
{
    public interface IAffect<in T> where T: IAffectable
    {
        public void SetTarget(T? target);
    }
}
