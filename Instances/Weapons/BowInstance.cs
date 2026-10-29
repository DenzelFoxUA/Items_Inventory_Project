
using System;

namespace InventoryCoreLib
{
    public class BowInstance : RangedInstance
    {
        private BowDefinition Bow => (BowDefinition)Definition;

        public BowInstance(BowDefinition bow) : base(bow)
        {

        }

        public override uint PrimaryAttack(double distanceToTarget)
        {
            if (distanceToTarget <= Bow.PrimaryAttack.AttackRange)
            {
                double conditionCoef = GetDurabilityCoefficient();

                uint damage = (uint)Math.Round(Bow.PrimaryAttack.MaxDamage * conditionCoef);

                return damage;
            }

            return 0;
        }

        public override uint? SecondaryAttack(double distanceToTarget)
        {
            if (Bow.SecondaryAttack is null)
                return null;

            if (distanceToTarget <= Bow.SecondaryAttack.AttackRange)
            {
                double conditionCoef = GetDurabilityCoefficient();
                uint damage = (uint)Math.Round(Bow.SecondaryAttack.MaxDamage * conditionCoef);
                return damage;
            }

            return 0;

        }

        public override bool Reload()
        {
            if (CurrentAmmoInstance is null)
                return false;

            if (CurrentAmmoInstance.CurrentStackCount > 0 && CurrentAmmoCount == 0)
            {

                CurrentAmmoInstance.Use();

                CurrentAmmoCount++;
                return true;
            }

            return false;
        }

        public override bool CanUseAmmo(IAmmoInstance ammo)
        {
            return ammo.AmmoDefinition.Ammo == AmmoType.Arrow;
        }

        public override bool SetAmmo(IAmmoInstance ammo)
        {
            if (!CanUseAmmo(ammo))
                return false;

            CurrentAmmoInstance = ammo;

            return true;
        }

    }
}
