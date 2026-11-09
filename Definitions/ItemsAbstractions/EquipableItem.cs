using System;
using System.Collections.Generic;

namespace InventoryCoreLib
{
    //public enum WearableItemCategory
    //{
    //    BodyArmor = 0,
    //    Head = 1,
    //    Boots = 2,
    //    Gloves,
    //    OneHanded,
    //    LeftHandOnly,
    //    RightHandOnly,
    //    TwoHanded,
    //    Amulet,
    //    Ring = 9
    //}

    public abstract class EquipableItem : BaseItem
    {

        public string EqupmentCategory { get; protected init; } = "";
        
        public uint LevelRequired { get; protected init; } = 0;

        public override bool Equals(BaseItem? obj)
        {
            if (obj is null)
                return false;

            if (obj is not EquipableItem other)
                return false;

            return base.Equals(obj) && 
                EqupmentCategory == other.EqupmentCategory && 
                LevelRequired == other.LevelRequired;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), EqupmentCategory, LevelRequired);
        }

        public override string ToString()
        {
            return base.ToString() +
                $"LevelReq: {LevelRequired}\n" +
                $"Category: {EqupmentCategory}";
        }
    }
}
