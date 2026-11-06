
using CharacterMainLib;
using System;

namespace InventoryCoreLib
{
    public interface IAffectTemporary<in T> : IAffect<T> 
        where T: IAffectable
    {

        public void Update(float deltaTime);

        public bool IsEffectExpired();
    }
}
