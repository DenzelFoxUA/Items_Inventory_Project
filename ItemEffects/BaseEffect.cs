namespace InventoryCoreLib
{


    public abstract class BaseEffect : IEffect
    {
        public uint Id { get; init; }

        public string Name { get; init; } = "";

        public Force Force { get; init; } = Force.NotSet;

        public uint PowerValue { get; init; } = 0;

        public string Describtion { get; init; } = "";

        public bool IsPassive { get; init; }

        public abstract ForceEffect Apply();
    }
}
