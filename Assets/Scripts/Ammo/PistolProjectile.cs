using System.Collections;
using UnityEngine;
public class PistolProjectile : MonoBehaviour
{
  [SerializeField] private Rigidbody2D _rigidbody;
  [SerializeField] private float _speed;
  [SerializeField] private ParticleSystem _destroyParticle;

  private float _time = 0f;
  private readonly float _lifetimeSpeed = 3f; 
  public void Init(Transform initPoint)
  {
    _rigidbody.velocity = initPoint.up * (_speed * Time.deltaTime);
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
    _destroyParticle.Play();
    Destroy(this.gameObject);
  }

  private void OnCollisionEnter2D(Collision2D collision)
  {
    Die();
  }
}
