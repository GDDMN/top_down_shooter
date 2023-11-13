using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ShotgunWeapon))]
public class SectoredFireEditor : Editor 
{
  private void OnSceneGUI()
  {
    ShotgunWeapon sfw = (ShotgunWeapon)target;
    Handles.color = Color.white;
    Handles.DrawWireArc(sfw.LounchPoint.position, Vector3.forward, Vector3.up, 360, sfw.ShootRadius);
    sfw.SetSpread();

    Handles.DrawLine(sfw.LounchPoint.position, sfw.LounchPoint.position + sfw.spreadAngleA * sfw.ShootRadius);
    Handles.DrawLine(sfw.LounchPoint.position, sfw.LounchPoint.position + sfw.spreadAngleB * sfw.ShootRadius);
  }
}
