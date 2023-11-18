using UnityEngine;

public class Configs : Singleton<Configs>
{
  public AmmoConfigs Ammos;

  private void Start()
  {
    UI.Init();
  }
}
