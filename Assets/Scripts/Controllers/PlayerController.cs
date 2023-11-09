using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
  private InputController _inputController;

  [SerializeField] private ActorMovements _actorMovements;
  [SerializeField] private Transform _rotateBody;

  private void Awake()
  {
    _inputController = new InputController();
  }

  private void OnEnable()
  {
    _inputController.Enable();
  }

  private void OnDisable()
  {
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
    _actorMovements.Move(direction, rotateDirection, _rotateBody);
  }
}
