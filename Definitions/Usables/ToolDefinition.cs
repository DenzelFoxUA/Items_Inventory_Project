
using System;

namespace InventoryCoreLib
{
    public class ToolDefinition : UsableItemDefinition
    {
        public uint MaxNumberOfUses { get; protected init; }

        public ToolDefinition(
             uint id,
             string name,
             string describtion,
             double weight_kg,
             uint price,
             BaseEffect? effect,
             uint numOfUses,
             string iconRef,
             string miniature2DRef)
        {
            Id = id;
            Name = name;
            Descriprion = describtion;
            Weight = weight_kg;
            Price = price;

            if (effect is null)
            {
                throw new ArgumentNullException("Effect is null");
            }

            if (effect.Effect == ApplyableEffect.Repair ||
                effect.Effect == ApplyableEffect.Unlock)
            {
                ItemEffect = effect;
            }
            else
            {
                throw new ArgumentException("Wrong effect category");
            }

            MaxNumberOfUses = numOfUses;

            Icon = iconRef;
            Miniature2D = miniature2DRef;
        }
    }
}
