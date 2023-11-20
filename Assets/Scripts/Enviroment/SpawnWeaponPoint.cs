using UnityEngine;
using System.Collections;

public class SpawnWeaponPoint : MonoBehaviour, IInteractable
{
  [SerializeField] private AmmoType _ammoType;
  [SerializeField] private float _timeToPickUp;
  [Header("Visaul")]
  [SerializeField] private SpriteRenderer _icon;
  [SerializeField] private Transform _image;
  [SerializeField] private Animator _animator;

  
  [SerializeField, Range(0f, 1f)]private float _time = 0;
  private bool _isActive = true;
  private void Start()
  {
    _icon.sprite = Configs.Instance.Ammos.GetAmmoByEnum(_ammoType).Data.Icon;
  }
  public void Interact(PlayerController player)
  {
    if (_isActive == false)
      return;

    player.PickUpWeapon(_ammoType);

    Deactivate();
    StartCoroutine(PickUpCooldown());
  }
  private IEnumerator PickUpCooldown()
  {
    while (_time < 1f)
    {
      _time += _timeToPickUp * Time.deltaTime;
      yield return null;
    }
    Activate();
  }

  private void Activate()
  {
    _isActive = true;
    _animator.SetTrigger("Release");
    _time = 0;
  }

  private void Deactivate()
  {
    _isActive = false;
    _animator.SetTrigger("PickedUp");
    _time = 0;
  }
  private void OnTriggerEnter2D(Collider2D collision)
  {
    var controller = collision.transform.GetComponent<PlayerController>();

    if (controller == null)
      return;

    Interact(controller);

  }
}
