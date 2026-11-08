
using CharacterMainLib;

namespace InventoryCoreLib
{
    public interface IAffectTemporary<in T> : IAffectImmediately<T>, IAffect<T>
        where T : IAffectable
    {
        public void Remove();

        public void Update(float deltaTime);
        public bool IsEffectExpired();
        
    }
}
