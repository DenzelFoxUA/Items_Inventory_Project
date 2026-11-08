using CharacterMainLib;

namespace InventoryCoreLib
{
    public interface IAffectImmediately<in T> : IAffect<T> where T : IAffectable
    {
        public void Apply();

    }
}
