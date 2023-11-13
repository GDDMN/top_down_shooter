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

    PistolProjectile[] allBullets = new PistolProjectile[5];
    Vector3[] bulletDirections = new Vector3[5];

    float f = 0f;
    for(int i=0; i < 5; i++, f += 0.5f)
    {
      var bullet = Instantiate(_projectile, _lounchPoint.position, _lounchPoint.rotation);
      Vector3 direction = spreadAngleB + (spreadAngleA * f);

      allBullets[i] = bullet;
      bulletDirections[i] = direction;
    }

    for(int i=0;i<5;i++)
    {
      allBullets[i].Init(_lounchPoint, bulletDirections[i]);
    }

    time = 0f;
  }
}
