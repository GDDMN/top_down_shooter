using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "allAmmos", menuName = "Configs/_allAmmos")]
public class AmmoConfigs : ScriptableObject
{
  [SerializeField] private List<AmmoConfig> _allAmmos = new List<AmmoConfig>();

  public AmmoConfig GetAmmoByEnum(AmmoType type)
  {
    return _allAmmos.Find(c => c.Data.Type == type);
  }
}