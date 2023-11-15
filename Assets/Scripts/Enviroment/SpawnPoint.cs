using UnityEngine;

public class SpawnPoint : MonoBehaviour, IInteractable
{
  [SerializeField] private AmmoType _ammoType;
  [SerializeField] private SpriteRenderer _icon;

  private void OnDrawGizmos()
  {
    _icon.sprite = G.Instance.Configs.Ammos.GetAmmoByEnum(_ammoType).Data.Icon;
  }
  private void Start()
  {
    _icon.sprite = G.Instance.Configs.Ammos.GetAmmoByEnum(_ammoType).Data.Icon;
  }
  public void Interact(PlayerController player)
  {
    player.PickUpWeapon(_ammoType);
  }
  private void OnTriggerEnter2D(Collider2D collision)
  {
    var controller = collision.transform.GetComponent<PlayerController>();

    if (controller == null)
      return;

    Interact(controller);

  }
}
