using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperWeapon : InlineFiredWeapon
{
  [SerializeField] private LineRenderer _lineRenderer;
  [SerializeField] private Transform _lounchPoint;

  [SerializeField] private ParticleSystem _lounchParticle;
  [SerializeField] private ParticleSystem _hitExplosion;
  private float shootRnge = 100f;

  private void Start()
  {
    time = 0f;
  }
  public void LateUpdate()
  {
    Shooting();
  }
  public override void Shooting()
  {
    if (!IsFiring)
      return;

    _lounchParticle.Play();
    if (time < 1f)
    {
      time += shootingSpeed * Time.deltaTime;
      return;
    }

    StopShooting();
  }

  public override void StopShooting()
  {
    if (!IsFiring)
      return;

    _lounchParticle.Stop();
    time = 0f;
    IsFiring = false;

    RaycastHit2D hit = Physics2D.Raycast(_lounchPoint.position, _lounchPoint.up);
    var hitExplosion = Instantiate(_hitExplosion, hit.point, Quaternion.identity);
    Destroy(hitExplosion, 2f);

    Debug.Log(hit.transform.name);
    _lineRenderer.SetPosition(0, _lounchPoint.position);
    _lineRenderer.SetPosition(1, hit.point);
    StartCoroutine(LaserLifetime());
  }

  private IEnumerator LaserLifetime()
  {
    
    _lineRenderer.enabled = true;
    yield return new WaitForSeconds(0.1f);
    _lineRenderer.enabled = false;
  }
}
