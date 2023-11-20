using System.Collections;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
  [SerializeField] protected Transform _lounchPoint;
  [SerializeField] protected SpriteRenderer right;
  [SerializeField] protected SpriteRenderer left;

  protected AmmoData _data;
  protected bool IsFiring = false;

  public AmmoData Data => _data;
  public Transform LounchPoint => _lounchPoint;
  public abstract void Fire();
  public abstract void StopShooting();
  public abstract void Shooting();

  public void Init(AmmoData data)
  {
    _data = data;
  }
  public void ActivateRightSprite()
  {
    right.enabled = true;
    left.enabled = false;
  }
  public void ActivateLeftSprite()
  {
    right.enabled = false;
    left.enabled = true;
  }
}

