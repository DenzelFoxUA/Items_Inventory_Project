namespace InventoryCoreLib
{
    public abstract class BaseItem
    {
        public uint Id { get; init; } = 0;
        public string Name { get; init; } = "";
        public string Descriprion { get; init; } = "";
        public double Weight { get; init; } = 0.0d;
        public uint Price { get; init; } = 0;

        //stack
        public bool IsStackable { get; init; } = false;
        public uint MaxStackSize { get; init; } = 1;

        //resource ref
        public string Icon { get; init; } = "";
        public string Miniature2D { get; init; } = "";

    }
}
