using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryCoreLib
{
    public class AmuletDefinition : EquipableItem
    {
        public AmuletDefinition(uint id,
            string name,
            string describ,
            uint maxDefence,
            uint price,
            double weight,
            uint durability,
            string icoRef,
            string miniature2DRef)
        {

            Id = id;
            Name = name;
            Descriprion = describ;
            Price = price;
            Weight = weight;

            Icon = icoRef;
            Miniature2D = miniature2DRef;

            EqupmentCategory = "Amulet";
            IsStackable = false;

        }
    }
}
