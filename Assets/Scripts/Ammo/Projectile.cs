using System.Collections;
using UnityEngine;

public abstract class Projectile : MonoBehaviour
{
  [SerializeField] protected Rigidbody2D _rigidbody;
  [SerializeField] protected float _speed;
  [SerializeField] protected ParticleSystem _destroyParticle;
  [SerializeField] protected uint _damage;

  public uint Damage => _damage;

  protected float _time = 0f;
  protected readonly float _lifetimeSpeed = 1f;

  public abstract void Init(Transform initPoint);
  public abstract void Init(Transform initPoint, Vector3 direction);
  protected abstract IEnumerator DyingTime();
  protected abstract void Die();

  protected abstract void Hit(IHurtable hurtable);
}
