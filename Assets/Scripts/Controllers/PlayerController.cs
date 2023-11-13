using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
  private InputController _inputController;

  [SerializeField] private ActorMovements _actorMovements;
  [SerializeField] private Weapon _weapon;
  [SerializeField] private Transform _rotateBody;

  private void Awake()
  {
    _inputController = new InputController();
  }

  private void OnEnable()
  {
    _inputController.Enable();

    _inputController.Player.Shoot.started += context => Fire();
    _inputController.Player.Shoot.canceled += context => StopShooting();
  }

  private void OnDisable()
  {
    _inputController.Player.Shoot.started -= context => Fire();
    _inputController.Player.Shoot.canceled -= context => StopShooting();

    _inputController.Disable();
  }

  private void Update()
  {
    Vector2 direction = _inputController.Player.Move.ReadValue<Vector2>();
    Move(direction);
  }

  private void Move(Vector2 direction)
  {
    Vector2 rotateDirection = _inputController.Player.Rotation.ReadValue<Vector2>();
    _actorMovements.Move(direction, rotateDirection, _rotateBody, _weapon);
  }

  private void Fire()
  {
    if (_weapon == null)
      return;

    _weapon.Fire();
  }

  private void StopShooting()
  {
    if (_weapon == null)
      return;

    _weapon.StopShooting();
  }

  public void PickUpWeapon(AmmoType type)
  {
    Destroy(_weapon.gameObject);
    _weapon = Instantiate(G.Instance.Configs.Ammos.GetAmmoByEnum(type).Data.WeaponPrefab, _rotateBody.transform);
    _weapon.transform.SetParent(_rotateBody);
  }
}
