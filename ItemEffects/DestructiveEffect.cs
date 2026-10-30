
namespace InventoryCoreLib
{
    public class DestructiveEffect : BaseEffect
    {

        public DestructiveEffect(
            uint id, 
            string name, 
            uint damage, 
            string describtion, 
            Force force, 
            bool isPassive)
        {
            Id = id;
            Name = name;
            Force = force;
            PowerValue = damage;
            Describtion = describtion;
            IsPassive = isPassive;
        }

        public override ForceEffect Apply()
        {
            return new ForceEffect
            {
                ApplyableForce = Force,
                Power = PowerValue
            };
        }
    }
}
