using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHudWindow : Window
{
  [SerializeField] private PlayerController _observable;
  [SerializeField] private PlayerHudBase _baseWindow;
  public void SetObservable(PlayerController observable)
  {
    _observable = observable;
  }

  public void UpdateWeaponUI(Weapon weapon)
  {
    _baseWindow.SetAmmoUI(weapon);
  }
}
