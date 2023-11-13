using UnityEngine;
public abstract class SectoredFiredWeapon : Weapon
{
  [SerializeField] private float shootRadius;
  [Range(0, 360), SerializeField] private float shootAngle;

  [HideInInspector]public Vector3 spreadAngleA;
  [HideInInspector]public Vector3 spreadAngleB;

  protected float time = 1f;
  [SerializeField] protected float shootingSpeed = 0.3f;
  public float ShootRadius => shootRadius;
  public float ShootAngle => shootAngle;
  public Vector3 DirFromAngle(float angleInDegrees, bool angleIsGlobal)
  {
    if(!angleIsGlobal)
      angleInDegrees += _lounchPoint.eulerAngles.x;

    return new Vector3(Mathf.Cos(angleInDegrees * Mathf.Deg2Rad), Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0f);
  }
  public void SetSpread()
  {
    spreadAngleA = DirFromAngle(-shootAngle / 2, false);
    spreadAngleB = DirFromAngle(shootAngle / 2, false);
  }
  private void Awake()
  {
    SetSpread();
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
