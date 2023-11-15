using UnityEngine;

public class ActorHurt : MonoBehaviour, IHurtable
{
  [SerializeField] private int _hp = 4;
  [Header("Visual")]

  [SerializeField] private ParticleSystem _hitFX;
  [SerializeField] private ParticleSystem _deathFX;

  public void HitProjectile(Projectile projectile)
  {
    GetDamage((int)projectile.Damage);

    if (_hp <= 0)
      Die();

    VisualHitImpact();
  }
  public void HitRay(int damage)
  {
    if (damage < 1)
      return;

    GetDamage(damage);

    if (_hp <= 0)
      Die();

    VisualHitImpact();
  }

  private void Die()
  {
    VisualDieImpact();
    Destroy(this.gameObject);
  }
  private void VisualHitImpact()
  {
    var hitFx = Instantiate(_hitFX, transform.position, Quaternion.identity);
    hitFx.Play();
    Destroy(hitFx.gameObject, 0.5f);
  }

  private void VisualDieImpact()
  {
    var dieFx = Instantiate(_deathFX, transform.position, Quaternion.identity);
    dieFx.Play();
    Destroy(dieFx.gameObject, 2f);
  }
  private void GetDamage(int damage)
  {
    _hp -= damage;
  }
}
