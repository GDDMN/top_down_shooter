﻿using System.Collections;
using UnityEngine;

public class ShotgunProjectile : Projectile
{
  public override void Init(Transform initPoint)
  {
    throw new System.NotImplementedException();
  }
  public override void Init(Transform initPoint, Vector3 direction)
  {
    _rigidbody.velocity = (initPoint.up + direction) * _speed;
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
      Die();

    if (hurtable == null)
      return;

    Hit(hurtable);
  }
  protected override void Hit(IHurtable hurtable)
  {
    hurtable.HitProjectile(this);
    Die();
  }
}
