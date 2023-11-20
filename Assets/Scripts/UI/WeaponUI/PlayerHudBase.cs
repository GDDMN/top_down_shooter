using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHudBase : MonoBehaviour
{
  [SerializeField] private Image _imageAmmo;
  public void SetAmmoUI(Weapon weapon)
  {
    _imageAmmo.sprite = weapon.Data.Icon;
  }
}
