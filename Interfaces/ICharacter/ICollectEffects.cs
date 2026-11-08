
using CharacterMainLib;

namespace InventoryCoreLib
{
    public interface ICollectEffects
    {
        public void AddStaticEffect(IAffectImmediately<IAffectableCharacter>? effect);
        public void AddTemporaryEffect(IAffectImmediately<IAffectable>? effect);

        public void RemoveStaticEffect();
        public void RemoveTemporaryEffect();
    }
}
