
using System;

namespace InventoryCoreLib
{
    public class BowInstance : RangedInstance
    {
        private BowDefinition Bow => (BowDefinition)Definition;

        private IAmmoInstance ArrowInstance => CurrentAmmoInstance!;

        public BowInstance(BowDefinition bow) : base(bow)
        { }

        public override uint PrimaryAttack(double distanceToTarget)
        {
            if (distanceToTarget > Bow.PrimaryAttack.AttackRange)
                return 0;

            if (CurrentAmmoCount == 0 && !Reload())
                return 0;

            double conditionCoef = GetDurabilityCoefficient();
            uint damage = (uint)Math.Round(Bow.PrimaryAttack.MaxDamage * conditionCoef);

            foreach(var effect in Bow.Effects)
            {
                if (effect.IsDestructive)
                    damage += effect.Apply();
            }

            var effectsList = ArrowInstance.AmmoDefinition.GetEffects();

            foreach(var eff in effectsList)
            {
                damage += eff.Apply();
            }

            CurrentAmmoCount--;

            return damage;
            
        }

        public override bool Reload()
        {
            if (CurrentAmmoInstance is null)
                return false;

            if (CurrentAmmoInstance.CurrentStackCount > 0 && CurrentAmmoCount == 0)
            {
                if(!CurrentAmmoInstance.Use())
                    return false;

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
