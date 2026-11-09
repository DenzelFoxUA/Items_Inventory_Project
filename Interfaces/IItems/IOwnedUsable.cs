using System.Collections.Generic;
using CharacterMainLib;

namespace InventoryCoreLib
{
    public interface IOwnedUsable : IUsable
    {
        public IDemoCharacter? MyOwner { get; }
        public IAffectableActor? MyTarget { get; }

        public void SetMyOwner(IDemoCharacter? owner);
        public void SetMyTarget(IAffectableActor? target);

        public object? GetEffects();
    }
}
