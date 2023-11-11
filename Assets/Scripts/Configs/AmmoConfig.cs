using UnityEngine;

[CreateAssetMenu(fileName = "AmmoConfig", menuName ="Configs/Ammo")]
public class AmmoConfig : ScriptableObject
{
  [SerializeField] private AmmoData _data;
  public AmmoData Data => _data;
  public void Init()
  {
  
  }
}
