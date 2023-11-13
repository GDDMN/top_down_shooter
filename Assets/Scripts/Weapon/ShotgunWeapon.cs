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

    _lounchParticle.Play();
    for(int i=2; i < 6; i++)
    {
      var bullet = Instantiate(_projectile, _lounchPoint.position, _lounchPoint.rotation);
      Vector3 direction = spreadAngleB - (spreadAngleA / (i - 1));
      bullet.Init(_lounchPoint, direction, i);
    }

    time = 0f;
  }
}
