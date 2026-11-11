using CharacterMainLib;
using InventoryCoreLib;
using System.Collections.Generic;

public class AttackComplex
{
    public uint Damage { get; init; }
    public double EffectiveRange { get; init; }

    public IEnumerable<IAffect> Effects { get; init; }

    public AttackComplex(
        uint damage,
        double range,
        IEnumerable<IAffect> effects)
    {
        Damage = damage;
        EffectiveRange = range;
        Effects = effects;
    }

    public void ApplyAttackToTarget(IAffectable? target)
    {
        if (target is not IAffectableActor actor)
            return;

        actor.DamageVital("Health", Damage);

        foreach (var effect in Effects)
        {
            switch (effect)
            {
                case IAffectTemporary<IAffectableActor> tempActor
                    when actor is IDemoActor collector:

                    tempActor.SetTarget(actor);
                    collector.AddTemporaryEffect(tempActor);

                    break;

                case IAffectImmediately<IAffectableActor> immediateActor
                    when actor is IDemoActor character:

                    immediateActor.SetTarget(actor);
                    immediateActor.Apply();

                    break;

                case IAffectTemporary<IAffectableCharacter> tempCharacter
                    when actor is IDemoCharacter character:

                    tempCharacter.SetTarget(character);
                    character.AddTemporaryEffect(tempCharacter);

                    break;

                case IAffectImmediately<IAffectableCharacter> immediateCharacter
                    when actor is IDemoCharacter character:

                    immediateCharacter.SetTarget(character);
                    immediateCharacter.Apply();

                    break;
            }
        }
    }
}