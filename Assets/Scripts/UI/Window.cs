using UnityEngine;
using System;
public class Window : MonoBehaviour
{
  public event Action<Window> OnClose;
  public event Action<Window> OnHide;
  public event Action<Window> OnAfterClose;
  public event Action<Window> OnShow;
}