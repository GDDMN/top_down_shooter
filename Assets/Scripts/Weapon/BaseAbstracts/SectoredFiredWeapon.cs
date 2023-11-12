using UnityEngine;
public abstract class SectoredFiredWeapon : Weapon
{
  [SerializeField] private float shootRadius;
  [Range(0, 360), SerializeField] private float shootAngle;

  public float ShootRadius => shootRadius;
  public float ShootAngle => shootAngle;
  public Vector3 DirFromAngle(float angleInDegrees, bool angleIsGlobal)
  {
    if(!angleIsGlobal)
    {
      angleInDegrees += _lounchPoint.eulerAngles.x;
    }

    return new Vector3(Mathf.Cos(angleInDegrees * Mathf.Deg2Rad), Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0f);
  }
  public override void Fire()
  {
    IsFiring = true;
  }

  public override void StopShooting()
  {
    IsFiring = false;
  }
}
