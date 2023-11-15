using System.Collections;
using UnityEngine;

public class MashinegunProjectile : Projectile
{
  private Vector2 _direction = new Vector2();
  private int _rikoshets = 0;
  public override void Init(Transform initPoint)
  {
    throw new System.NotImplementedException();
  }
  public override void Init(Transform initPoint, Vector3 direction)
  {
    _direction = (initPoint.up + direction) * _speed;
    _rigidbody.velocity = _direction;
    StartCoroutine(DyingTime());
  }

  protected override IEnumerator DyingTime()
  {
    while (_time <= 1f)
    {
      _time += _lifetimeSpeed * Time.deltaTime;
      yield return null;
    }

    Die();
  }

  protected override void Die()
  {
    var destroyPartivle = Instantiate(_destroyParticle, transform.position, Quaternion.identity);
    destroyPartivle.Play();
    Destroy(destroyPartivle.gameObject, 0.5f);
    Destroy(this.gameObject);
  }
  private void OnCollisionEnter2D(Collision2D collision)
  {
    var hurtable = collision.gameObject.GetComponent<IHurtable>();
    
    if (collision.gameObject.layer == 16)
    {
      Rikoshet(collision);
      return;
    }

    if (hurtable == null)
      return;

    if(collision.gameObject.layer == 11)
      Hit(hurtable);    
  }

  protected override void Hit(IHurtable hurtable)
  {
    hurtable.HitProjectile(this); 
    Die();
  }

  private void Rikoshet(Collision2D collision)
  {
    _rikoshets++;
    
    if(_rikoshets >= 2)
      Die();
    
    var destroyPartivle = Instantiate(_destroyParticle, transform.position, Quaternion.identity);
    destroyPartivle.Play();

    Vector2 direction = Vector2.Reflect(_direction, collision.contacts[0].normal).normalized;
    _rigidbody.velocity = direction * _speed;
  }
}
