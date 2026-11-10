

using CharacterMainLib;

namespace InventoryCoreLib
{
    public interface IAffect
    { 
        //logic marker
    }


    public interface IAffect<in T> : IAffect 
        where T: IAffectable
    {
        public void SetTarget(T? target);
    }
}
