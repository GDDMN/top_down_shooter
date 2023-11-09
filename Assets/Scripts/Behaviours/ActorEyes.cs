using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorEyes : MonoBehaviour
{
  [SerializeField] private Transform _leftEyes;
  [SerializeField] private Transform _rightEyes;

  public void ActivateLeftEyes()
  {
    _leftEyes.gameObject.SetActive(true);
    _rightEyes.gameObject.SetActive(false);
  }

  public void ActivateRightEyes()
  {
    _leftEyes.gameObject.SetActive(false);
    _rightEyes.gameObject.SetActive(true);
  }
}
