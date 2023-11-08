using UnityEngine;

public class ActorMovements : MonoBehaviour
{
  [SerializeField] private Rigidbody2D _rigidbody;

  [SerializeField] private float _speed;

  public void Move(Vector2 direction, Vector2 rotateDirection)
  {
    _rigidbody.velocity = direction * _speed;
    Rotation(rotateDirection);
  }

  public void Rotation(Vector2 mousePosition)
  {
    Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(mousePosition);
    Vector3 targetDirection = mouseWorldPos - transform.position;
    float angle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg;
    transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
  }
}
