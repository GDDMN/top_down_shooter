using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
  protected AmmoData _data;
  protected bool IsFiring = false;

  private void Update()
  {
    if (IsFiring)
      Shooting();
  }
  public abstract void Fire();

  public abstract void StopShooting();

  public abstract void Shooting();
}

