
using CharacterMainLib;
using InventoryCoreLib;

namespace InventoryCoreLib
{
    public interface ICollectEffects : IDemoActor
    {
        void AddTemporaryEffect(IAffectTemporary<IAffectableActor> effect);
        public void AddTemporaryEffect(IAffectImmediately<IAffectable>? effect);

        public void RemoveStaticEffect();
        public void RemoveTemporaryEffect();
    }
}

public interface ITemporaryEffectReceiver : IAffectableActor
{
   
}