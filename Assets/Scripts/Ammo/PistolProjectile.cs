using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolProjectile : MonoBehaviour
{
  [SerializeField] private Rigidbody2D _rigidbody;
  [SerializeField] private float _speed;
  public void Init(Transform initPoint)
  {
    _rigidbody.velocity = initPoint.up * (_speed * Time.deltaTime);
  }
}
