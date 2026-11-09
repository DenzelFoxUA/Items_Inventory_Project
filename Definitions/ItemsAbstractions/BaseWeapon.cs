
using System;

namespace InventoryCoreLib
{
    public abstract class BaseWeapon: DurableItem
    {
        public AttackDefinition? PrimaryAttack { get; protected init; } = null;
        public AttackDefinition? SecondaryAttack { get; protected init; } = null;
        public bool IsTwoHanded { get; protected init; }

        public override bool Equals(BaseItem? obj)
        {

            if (obj is null)
                return false;

            if (obj is not BaseWeapon other)
                return false;

            return base.Equals(obj) 
                && PrimaryAttack == other.PrimaryAttack
                && SecondaryAttack == other.SecondaryAttack
                && IsTwoHanded == other.IsTwoHanded;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), PrimaryAttack, SecondaryAttack, IsTwoHanded);
        }
    }
}
