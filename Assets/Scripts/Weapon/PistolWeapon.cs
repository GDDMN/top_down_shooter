using UnityEngine;
public class PistolWeapon : InlineFiredWeapon
{
  [SerializeField] private PistolProjectile _projectile;
  [SerializeField] private Transform _lounchPoint;
  [SerializeField] private ParticleSystem _lounchParticle;

  private void LateUpdate()
  {
    Shooting();
  }
  public override void Shooting()
  {
    if(time < 1f)
    {
      time += shootingSpeed * Time.deltaTime;
      return;
    }

    if (!IsFiring)
      return;

    _lounchParticle.Play();
    var projectile = Instantiate(_projectile, _lounchPoint.position, _lounchPoint.rotation);
    projectile.Init(_lounchPoint);
    time = 0f;
  }
}
