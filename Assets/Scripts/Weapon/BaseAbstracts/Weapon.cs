using System.Collections;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
  [SerializeField] protected Transform _lounchPoint;
  protected AmmoData _data;
  protected bool IsFiring = false;

  public Transform LounchPoint => _lounchPoint;
  public abstract void Fire();
  public abstract void StopShooting();
  public abstract void Shooting();
}

