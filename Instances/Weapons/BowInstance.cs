

using System;
using System.Transactions;

namespace InventoryCoreLib
{
    public class BowInstance : WeaponInstance, IRanged
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


        public void Reload()
        {
            throw new System.NotImplementedException();
        }

        public void ApplyAmmunition()
        {
            throw new System.NotImplementedException();
        }

        public bool CanUseAmmo(IAmmo ammo)
        {
            throw new System.NotImplementedException();
        }

        public bool SetAmmo(IAmmo ammo)
        {
            throw new System.NotImplementedException();
        }

        public void ClearAmmo()
        {
            throw new System.NotImplementedException();
        }


    }
}
