using CharacterMainLib;
using InventoryCoreLib;
using System.Collections.Generic;

public class EffectsManager<T> where T : class, IAffectable
{
    private readonly T _target;

    private readonly List<IAffectTemporary<T>> _temporaryEffects = [];

    public EffectsManager(T target)
    {
        _target = target;
    }

    public void AddToStatic(IAffectConditionally<T>? effect)
    {
        if (effect is null)
            return;

        effect.SetTarget(_target);
        effect.Apply();
    }

    public void RemoveStatic(IAffectConditionally<T>? effect)
    {
        if (effect is null)
            return;

        effect.SetTarget(_target);
        effect.Remove();
    }

    public void AddToTemporary(IAffectTemporary<T>? effect)
    {
        if (effect is null)
            return;

        effect.SetTarget(_target);
        _temporaryEffects.Add(effect);
    }

    public void Update(float deltaTime)
    {

        for (int i = _temporaryEffects.Count - 1; i >= 0; i--)
        {
            var effect = _temporaryEffects[i];

            effect.Update(deltaTime);

            if (effect.IsEffectExpired())
                _temporaryEffects.RemoveAt(i);
        }
    }
}