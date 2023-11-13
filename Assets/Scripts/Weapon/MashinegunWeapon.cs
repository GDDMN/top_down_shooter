using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MashinegunWeapon : SectoredFiredWeapon
{
  [SerializeField] private MashinegunProjectile _projectile;
  [SerializeField] private ParticleSystem _lounchParticle;
  [SerializeField] private float _overheatSpeed;
  [SerializeField] private float _coolingDownSpeed;


  [SerializeField, Range(0f, 1f)]private float _overheat = 0f;
  private void Update()
  {
    Shooting();
    Overheat();
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
    _overheat += _overheatSpeed * Time.deltaTime;

    float range = Random.Range(0f, 1.5f);
    Vector3 direction = spreadAngleB + (spreadAngleA * range);
    var bullet = Instantiate(_projectile, _lounchPoint.position, _lounchPoint.rotation);
    bullet.Init(_lounchPoint, direction);

    time = 0f;
  }

  private void Overheat()
  {
    if (_overheat > 1f)
      IsFiring = false;

    if(_overheat > 0.1f)
    {
      _overheat -= _coolingDownSpeed * Time.deltaTime;
    }
  }

}
