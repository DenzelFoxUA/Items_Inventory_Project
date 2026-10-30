
using System.Collections.Generic;

namespace InventoryCoreLib
{
    public interface IAmmoInstance
    {
        public IAmmo AmmoDefinition { get; }
        public uint CurrentStackCount { get; }
        public bool Use();
    }
}
