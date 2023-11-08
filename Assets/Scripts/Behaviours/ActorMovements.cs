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
    Vector2 direction = (mousePosition - (Vector2)this.transform.position);
    transform.up = direction;
  }
}
