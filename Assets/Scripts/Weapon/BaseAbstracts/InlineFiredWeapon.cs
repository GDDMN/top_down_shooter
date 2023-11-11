using UnityEngine;

public abstract class InlineFiredWeapon : Weapon
{
  protected float time = 1f;
  [SerializeField] protected float shootingSpeed = 0.3f;
  public override void Fire()
  {
    IsFiring = true;
    time = 1f;
  }

  public override void StopShooting()
  {
    IsFiring = false;
  }
}

