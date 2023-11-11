using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolWeapon : InlineFiredWeapon
{
  [SerializeField] private PistolProjectile _projectile;
  [SerializeField] private Transform _lounchPoint;
  public override void Shooting()
  {
    if(time < 1f)
    {
      time += shootingSpeed * Time.deltaTime;
      return;
    }

    time = 0f;
    var projectile = Instantiate(_projectile, _lounchPoint.position, _lounchPoint.rotation);
    projectile.Init(_lounchPoint);
  }
}
