
namespace InventoryCoreLib
{
    public abstract class UsableItemItsance : BaseItemInstance, IUsable
    {
        public UsableItemItsance(BaseItem item) : base(item)
        { }

        public abstract uint Use();
    }
}
