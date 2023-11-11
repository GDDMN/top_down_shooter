public abstract class SectoredFiredWeapon : Weapon
{
  public override void Fire()
  {
    IsFiring = true;
  }

  public override void StopShooting()
  {
    IsFiring = false;
  }
}