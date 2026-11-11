using CharacterMainLib;

namespace InventoryCoreLib
{
    public interface IDemoActor<TEffect, TTarget> : IAffectableActor
        where TTarget : class, IAffectable
        where TEffect : IAffectTemporary<TTarget>
    {
        public void AddTemporaryEffect(TEffect? effect);
    }
}
