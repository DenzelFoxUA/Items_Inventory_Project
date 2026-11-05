
//using System.Collections.Generic;

//namespace InventoryCoreLib
//{
//    public class ArrowInstance : EquipableInstance//, IAmmoInstance
//    {

//        public ArrowDefinition AmmoDefinition => (ArrowDefinition)Definition;


//        public ArrowInstance(ArrowDefinition arrow) : base(arrow)
//        {
            
//        }

//        //temp code
//        public void AddToStack(uint numOfArrows)
//        {
//            if (AmmoDefinition.MaxStackCount <= CurrentStackCount + numOfArrows)
//                CurrentStackCount = AmmoDefinition.MaxStackCount;
//            else
//                CurrentStackCount += numOfArrows;
//        }

//        public override void SetItemTarget<T>(T? target) where T : default
//        {
//            throw new System.NotImplementedException();
//        }



//        public override uint RemoveFromStack(uint count)
//        {
//            throw new System.NotImplementedException();
//        }

//        public override object? Use()
//        {
//            if (CurrentStackCount == 0)
//                return false;

//            CurrentStackCount--;
//            return true;
//        }

//        public override uint AddToStack(uint count)
//        {
//            throw new System.NotImplementedException();
//        }
//    }
//}
