using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour, IInteractable
{
  [SerializeField] private AmmoType _ammoType;

  public void Interact(PlayerController player)
  {
    player.PickUpWeapon(_ammoType);
  }

  private void OnCollisionEnter2D(Collision2D collision)
  {
    Interact(collision.transform.GetComponent<PlayerController>());
  }
}
