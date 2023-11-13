using System.Collections;
using UnityEngine;
public class PistolProjectile : MonoBehaviour
{
  [SerializeField] private Rigidbody2D _rigidbody;
  [SerializeField] private float _speed;
  [SerializeField] private ParticleSystem _destroyParticle;

  private float _time = 0f;
  private readonly float _lifetimeSpeed = 1f; 
  public void Init(Transform initPoint)
  {
    _rigidbody.velocity = initPoint.up * _speed ;
    StartCoroutine(DyingTime());
  }

  public void Init(Transform initPoint, Vector3 direction, int indexOfLounchBullet)
  {
    Vector3 forwardDirection = new Vector3(direction.x, direction.y, 0f);
    _rigidbody.velocity = (initPoint.up + forwardDirection) * _speed;
    StartCoroutine(DyingTime());
  }

  private IEnumerator DyingTime()
  {
    while(_time <= 1f)
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
    Destroy(this.gameObject);
  }

  private void OnCollisionEnter2D(Collision2D collision)
  {
    Die();
  }
}