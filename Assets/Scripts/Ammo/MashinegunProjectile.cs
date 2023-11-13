using System.Collections;
using UnityEngine;

public class MashinegunProjectile : MonoBehaviour
{
  [SerializeField] private Rigidbody2D _rigidbody;
  [SerializeField] private float _speed;
  [SerializeField] private ParticleSystem _destroyParticle;

  private float _time = 0f;
  private readonly float _lifetimeSpeed = 2f;
  Vector2 _direction = new Vector2();
  public void Init(Transform initPoint, Vector3 direction)
  {
    _direction = (initPoint.up + direction) * _speed;
    _rigidbody.velocity = _direction;
    StartCoroutine(DyingTime());
  }

  private IEnumerator DyingTime()
  {
    while (_time <= 1f)
    {
      _time += _lifetimeSpeed * Time.deltaTime;
      yield return null;
    }

    Die();
  }

  private void Die()
  {
    var destroyPartivle = Instantiate(_destroyParticle, transform.position, Quaternion.identity);
    destroyPartivle.Play();
    Destroy(destroyPartivle.gameObject, 0.5f);
    Destroy(this.gameObject);
  }

  private void OnCollisionEnter2D(Collision2D collision)
  {
    var destroyPartivle = Instantiate(_destroyParticle, transform.position, Quaternion.identity);
    destroyPartivle.Play();

    Vector2 direction = Vector2.Reflect(_direction, collision.contacts[0].normal).normalized;
    _rigidbody.velocity = direction * _speed;
  }
}
