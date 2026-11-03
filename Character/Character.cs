
using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace InventoryCoreLib
{
    public static class DefaultModel
    {
        public static FrozenDictionary<string, VitalsBaseValues> Vitals { get; } =
            new Dictionary<string, VitalsBaseValues>
            {
                { "Health",new VitalsBaseValues(100,500) },
                { "Mana", new VitalsBaseValues(100,400) },
                { "Stamina", new VitalsBaseValues(100,400) }

            }.ToFrozenDictionary();

        public static ImmutableArray<string> Attributes { get; } =
            [   
                "Dexterity",
                "Strength",
                "Willpower",
                "Endurance",
                "Luck",
                "Intelligence"
            ];

    }

    /// <summary>
    /// Represents a generic inventory container.
    /// </summary>
    /// <typeparam name="T">
    /// The type of items stored in the inventory.
    /// Must be a reference type.
    /// </typeparam>
    /// <typeparam name="P">
    /// The type used to identify an item's position.
    /// Can be an index, coordinates, or another position type.
    /// </typeparam>
    public interface IInventory<T, P> : IEnumerable<T>
        where T : class
    {
        public bool AddItem(T item, P pos);
        public bool AddItem(T item);

        public T? RemoveItem(P pos);
        public T? RemoveItem(T item);

        public void SwapItems(P one, P two);
        public void SwapItems(T one, T two);
    }

    public struct VitalsBaseValues
    {
        public uint StartMax { get; init; }
        public uint Peak { get; init; }

        public VitalsBaseValues(uint startMax, uint peak)
        {
            StartMax = startMax;
            Peak = peak;
        }

    }

    public abstract class CharacterDefinition
    {
        public string Name { get; protected init; } = "";
        public uint MinLevel { get; } = 1;
        public uint MaxLevel { get; protected init; } = 99;
    }

    /// <typeparam name="T">
    /// The type of items stored in the inventory.
    /// Must be a reference type.
    /// </typeparam>
    /// <typeparam name="P">
    /// The type used to identify an item's position.
    /// Can be an index, coordinates, or another position type.
    /// </typeparam>
    public abstract class Character<T, P> : CharacterDefinition, IAffectable
        where T: class
    {

        public FrozenDictionary<string, VitalStat> VitalStats { get; protected set; }
        public FrozenDictionary<string, AttributeStat> AttributeStats { get; protected set; }

        public uint CurrentLevel { get; protected set; }

        //inventory
        public IInventory<T, P> Inventory { get; protected init; } 
        //

        public Character(string name, 
            uint maxLevel, 
            uint minAttributeValue,
            uint attributesMaxValue,
            in IReadOnlyDictionary<string,VitalsBaseValues> vitals,
            in IEnumerable<string> attributes,
            IInventory<T, P> inventoryClass)
        {
            Name = name;
            MaxLevel = maxLevel;
            CurrentLevel = 1;

            Dictionary<string, VitalStat> vitalStats = new();
            Dictionary<string, AttributeStat> attributeStats = new();

            foreach (var vital in vitals)
            {
                vitalStats.Add(vital.Key, new VitalStat(vital.Value.StartMax, vital.Value.Peak));
            }

            foreach(var attribute in attributes)
            {
                attributeStats.Add(attribute, new AttributeStat(minAttributeValue, attributesMaxValue));
            }

            VitalStats = vitalStats.ToFrozenDictionary();
            AttributeStats = attributeStats.ToFrozenDictionary();

            Inventory = inventoryClass;
        }

        public abstract void UseItem(T item);
        public abstract void UseItem(P itemPos);

        public override string ToString()
        {
            string attributeStats = "";
            string vitals = "";

            foreach (var stat in VitalStats)
            {
                vitals += stat.Key;
                vitals += ": ";
                vitals += stat.ToString();
                vitals += "\n";
            }

            foreach (var stat in AttributeStats)
            {
                attributeStats += $"{stat.Key, -20}{stat.Value.CurrentValue}\n";
            }

            return $"Name: {Name}\n" +
                $"Level: {CurrentLevel}\n" +
                $"Attributes: \n" +
                $"\n" + attributeStats +
                $"Vital Stats: \n" +
                $"{vitals}\n";
        }
    }
}
