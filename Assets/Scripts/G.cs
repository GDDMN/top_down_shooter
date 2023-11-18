using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class G : Singleton<G>
{

  private readonly string _initSceneName = "game";
  private void Start()
  {
    Screen.sleepTimeout = SleepTimeout.NeverSleep;
    StartCoroutine(SafeInit());
  }

  private IEnumerator SafeInit()
  {
    yield return new WaitUntil(() => SceneManager.GetActiveScene().name == _initSceneName);
    yield return StartCoroutine(Init());
  }

  private IEnumerator Init()
  {
    UI.Init();
    UI.CreateWindow<PlayerHudWindow>();
    yield return null;
  }
}
