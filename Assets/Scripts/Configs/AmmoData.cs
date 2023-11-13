using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public struct AmmoData
{
  public int Damage;
  public int Dispersion;
  public int ShootSpeed;
  public AmmoType Type;
  public Weapon WeaponPrefab;
  public Sprite Icon;
}