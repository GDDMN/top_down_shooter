using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunWeapon : SectoredFiredWeapon
{
  [SerializeField] private PistolProjectile _projectile;
  [SerializeField] private ParticleSystem _lounchParticle;

  private void LateUpdate()
  {
    Shooting();
  }
  public override void Shooting()
  {
    if (time < 1f)
    {
      time += shootingSpeed * Time.deltaTime;
      return;
    }

    if (!IsFiring)
      return;

    SetSpread();
    _lounchParticle.Play();

    float f = 0f;

    PistolProjectile[] allBullets = new PistolProjectile[5];

    for(int i=0; i < 5; i++, f += 0.5f)
    {
      var bullet = Instantiate(_projectile, _lounchPoint.position, _lounchPoint.rotation);
      Vector3 direction;
      direction = spreadAngleB + (spreadAngleA * f);

      bullet.Init(_lounchPoint, direction);
    }

    time = 0f;
  }
}
