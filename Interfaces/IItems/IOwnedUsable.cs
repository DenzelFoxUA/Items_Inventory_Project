using System.Collections.Generic;
using CharacterMainLib;

namespace InventoryCoreLib
{
    public interface IOwnedUsable : IUsable
    {
        public IDemoCharacter? MyOwner { get; }
        public IAffectable? MyTarget { get; }

        public void SetMyOwner(IDemoCharacter? owner);
        public void SetMyTarget(IAffectable? target);

        public IReadOnlyList<IAffect>? GetEffects();
 
    }
}
