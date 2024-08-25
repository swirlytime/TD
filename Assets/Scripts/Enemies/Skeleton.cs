using System.Diagnostics;

namespace Assets.Scripts.Enemies
{
    public class Skeleton : Enemy
    {
        public override void TakeDamage(float damage)
        {
            Debug.Write($"Skelly took {damage}");
            base.TakeDamage(damage*2);
        }
    }
}
