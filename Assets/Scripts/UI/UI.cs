using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class UI
{
  private static WindowsController _windowController;

  //public static Canvas Canvas => 
  public static void Init()
  {

  }

  private static void LoadController()
  {
    
  }

  public static T CreateWindow<T>() where T : Window
  {
    return _windowController.Create<T>();
  }
}
