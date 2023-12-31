using UnityEngine;

public class ActorMovements : MonoBehaviour
{
  [SerializeField] private Rigidbody2D _rigidbody;
  [SerializeField] private ActorEyes _actorEyes;

  [SerializeField] private float _speed;

  public void Move(Vector2 direction, Vector2 rotateDirection, Transform rotateObject, Weapon weapon)
  {
    _rigidbody.velocity = direction * _speed;
    Rotation(rotateDirection, rotateObject, weapon);
  }

  public void Rotation(Vector2 mousePosition, Transform rotateObject, Weapon weapon)
  {
    Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(mousePosition);
    Vector3 targetDirection = mouseWorldPos - transform.position;
    float angle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg;
    rotateObject.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));

    if (targetDirection.x > 0)
    {
      _actorEyes.ActivateRightEyes();
      weapon.ActivateRightSprite();
    }
    else
    {
      _actorEyes.ActivateLeftEyes();
      weapon.ActivateLeftSprite();
    }
  }
}
