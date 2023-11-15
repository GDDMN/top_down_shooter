using UnityEngine;

public class ActorHurt : MonoBehaviour, IHurtable
{
  [SerializeField] private int _hp = 4;

  public void HitProjectile(Projectile projectile)
  {
    VisualImpact();
    GetDamage((int)projectile.Damage);

    if (_hp <= 0)
      Die();
  }

  public void HitRay(int damage)
  {
    VisualImpact();
    GetDamage(damage);

    if (_hp <= 0)
      Die();
  }
  private void VisualImpact()
  {

  }

  private void GetDamage(int damage)
  {
    _hp -= damage;
  }
  private void Die()
  {
    Destroy(this.gameObject);
  }
}
