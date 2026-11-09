using System;

namespace InventoryCoreLib
{
    public abstract class BaseItem
    {
        public uint Id { get; protected init; } = 0;
        public string Name { get; protected init; } = "";
        public string Descriprion { get; protected init; } = "";
        public double Weight { get; protected init; } = 0.0d;
        public uint Price { get; protected init; } = 0;

        //stack
        public bool IsStackable { get; protected init; } = false;
        public uint MaxStackSize { get; protected init; } = 1;

        //resource ref
        public string Icon { get; protected init; } = "";
        public string Miniature2D { get; protected init; } = "";

        #region Equals

        public override string ToString()
        {
            return $"Name: {Name}\n" +
                $"Description: {Descriprion}\n" +
                $"Weight: {Weight}\n" +
                $"Price: {Price}";
        }

        public virtual bool Equals(BaseItem? other)
        {
            if (ReferenceEquals(other, null))
                return false;

            if (ReferenceEquals(this, other))
                return true;

            //для нащадків це потрібно, щоб порівнювати один тип а не всі нащадки
            if (other is null || GetType() != other.GetType())
                return false;

            return this.Id.Equals(other.Id) &&
                this.Name.Equals(other.Name) &&
                this.Descriprion.Equals(other.Descriprion) &&
                this.Weight.Equals(other.Weight) &&
                this.Price.Equals(other.Price);
        }

        public override bool Equals(object? obj) => Equals(obj as BaseItem);

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Name, Descriprion, Weight, Price);
        }

        public static bool operator==(BaseItem one, BaseItem other)
        {
            if (ReferenceEquals(one, other))
                return true;

            if (one is null || other is null)
                return false;

            return one.Equals(other);
        }

        public static bool operator!= (BaseItem one, BaseItem other)
        {
            return !(one == other);
        }

        #endregion
    }
}
