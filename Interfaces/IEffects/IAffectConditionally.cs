using CharacterMainLib;
using System;

namespace InventoryCoreLib
{
    public interface IAffectConditionally<in T> : IAffect<T> where T : IAffectable
    {
        public void Apply();
        public void Remove();
    }
}
