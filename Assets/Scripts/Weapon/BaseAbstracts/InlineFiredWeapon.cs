public abstract class InlineFiredWeapon : Weapon
{
  private void Update()
  {
    if (IsFiring)
      Shooting();
  }
  public abstract void Shooting();

  public override void Fire()
  {
    IsFiring = true;
  }

  public override void StopShooting()
  {
    IsFiring = false;
  }
}

