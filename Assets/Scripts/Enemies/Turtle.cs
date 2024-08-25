namespace Assets.Scripts.Enemies
{
    public class Turtle : Enemy
    {
        public override void TakeDamage(float damage)
        {
            base.TakeDamage(damage/2);
        }
    }
}
