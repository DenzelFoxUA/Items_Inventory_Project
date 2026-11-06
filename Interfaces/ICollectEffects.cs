
using CharacterMainLib;

namespace InventoryCoreLib
{
    public interface ICollectEffects
    {
        public void AddStaticEffect(IAffect<IAffectableCharacter>? effect);
        public void AddTemporaryEffect(IAffect<IAffectable>? effect);

        public void RemoveStaticEffect();
        public void RemoveTemporaryEffect();
    }
}
