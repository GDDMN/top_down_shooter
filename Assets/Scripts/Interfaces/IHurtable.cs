using UnityEngine;
public interface IHurtable
{
  public void HitProjectile(Projectile projectile);
  
  public void HitRay(int damage);
}
