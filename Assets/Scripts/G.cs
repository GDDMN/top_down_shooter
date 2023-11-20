using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class G : Singleton<G>
{
  [SerializeField] private Configs _configs;

  private readonly string _initSceneName = "game";

  public Configs Configs => _configs;
  private void Awake()
  {
    Screen.sleepTimeout = SleepTimeout.NeverSleep;
    UI.Init();
    StartCoroutine(SafeInit());
  }

  private IEnumerator SafeInit()
  {
    yield return new WaitUntil(() => SceneManager.GetActiveScene().name == _initSceneName);
    yield return StartCoroutine(Init());
  }

  private IEnumerator Init()
  {
    yield return null;
  }
}
