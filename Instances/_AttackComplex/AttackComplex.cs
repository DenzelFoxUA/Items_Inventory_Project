using CharacterMainLib;
using System.Collections.Generic;

namespace InventoryCoreLib
{
    public class AttackComplex<TEffect, TTarget>
         where TTarget : class, IAffectable
    where TEffect : class, IAffect<TTarget>
    {
        public uint Damage { get; protected init; }
        public double EffectiveRange { get; protected init; }
        public List<TEffect> Effects { get; protected init; }

        public AttackComplex(uint damage, double range, List<TEffect> effects)
        {
            Damage = damage;
            EffectiveRange = range;
            Effects = effects;
        }


        public void ApplyAttackToTarget(IAffectable? target)
        {
            if (target is null)
                return;

            if (target is TTarget charTarget && charTarget is IDemoCharacter character)
            {
                character.DamageVital("Health", Damage);

                foreach(var effect in Effects)
                {
                    if (effect is TEffect currEffect)
                    {
                        if (currEffect is IAffectTemporary<IAffectableActor> tempEff)
                        {
                            tempEff.SetTarget(character);
                            character.AddTemporaryEffect(tempEff);
                        }
                        else if(currEffect is IAffectImmediately<IAffectableActor> immediateEff)
                        {
                            immediateEff.SetTarget(character);
                            immediateEff.Apply();
                        }

                    }

                }
            }
        }
    }
}
