using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI
{
  public static Canvas Canvas => _windowController.Canvas; 

  private static WindowsController _windowController;

  public static void Init()
  {
    LoadController();
  }

  private static void LoadController()
  {
    if (_windowController == null)
    {
      _windowController = Resources.Load<WindowsController>("UI/WindowsController");
      _windowController = UnityEngine.GameObject.Instantiate(_windowController); 
      UnityEngine.Object.DontDestroyOnLoad(_windowController);
    }

    _windowController.Init();
  }

  public static T CreateWindow<T>() where T : Window
  {
    return _windowController.Create<T>();
  }
}
