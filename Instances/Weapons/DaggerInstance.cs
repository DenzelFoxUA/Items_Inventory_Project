
using CharacterMainLib;
using System.Collections.Generic;

namespace InventoryCoreLib
{
    public class DaggerInstance : WeaponInstance<IAffectImmediately<IAffectableActor>>
    {
        public DaggerDefinition Dagger => (DaggerDefinition)Definition;

        public DaggerInstance(DaggerDefinition daggerItem) : base(daggerItem)
        {

        }

        public override void SetItemTarget(IAffectableActor? target)
        {
            throw new System.NotImplementedException();
        }

        public override void Use()
        {
            throw new System.NotImplementedException();
        }

        public override void Equip()
        {
            throw new System.NotImplementedException();
        }

        public override void Unequip()
        {
            throw new System.NotImplementedException();
        }

        public override void SetTargetFunction()
        {
            throw new System.NotImplementedException();
        }
    }
}
