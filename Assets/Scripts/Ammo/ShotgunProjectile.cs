using System.Collections;
using UnityEngine;

public class ShotgunProjectile : MonoBehaviour
{
  [SerializeField] private Rigidbody2D _rigidbody;
  [SerializeField] private float _speed;
  [SerializeField] private ParticleSystem _destroyParticle;

  private float _time = 0f;
  private readonly float _lifetimeSpeed = 1f;

  public void Init(Transform initPoint, Vector3 direction)
  {
    _rigidbody.velocity = (initPoint.up + direction) * _speed;
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
    Die();
  }
}
