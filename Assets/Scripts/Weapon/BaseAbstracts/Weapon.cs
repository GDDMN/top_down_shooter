using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
  protected AmmoData _data;
  protected bool IsFiring = false;
  public abstract void Fire();

  public abstract void StopShooting();
}

