using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(SectoredFiredWeapon))]
public class SectoredFireEditor : Editor 
{
  private void OnSceneGUI()
  {
    SectoredFiredWeapon sfw = (SectoredFiredWeapon)target;
    Handles.color = Color.white;
    Handles.DrawWireArc(sfw.LounchPoint.position, Vector3.forward, Vector3.up, 360, sfw.ShootRadius);
    Vector3 viewAngleA = sfw.DirFromAngle(-sfw.ShootAngle / 2, false);
    Vector3 viewAngleB = sfw.DirFromAngle(sfw.ShootAngle / 2, false);

    Handles.DrawLine(sfw.LounchPoint.position, sfw.LounchPoint.position + viewAngleA * sfw.ShootRadius);
    Handles.DrawLine(sfw.LounchPoint.position, sfw.LounchPoint.position + viewAngleB * sfw.ShootRadius);
  }
}
