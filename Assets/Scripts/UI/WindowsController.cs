using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WindowsController : MonoBehaviour
{
  public event Action<Window> OnCreateWindow;

  [SerializeField] private Transform _windowContainer = null;
  
  [Space]
  [Header("Canvas:")]
  [SerializeField] private Canvas _canvas = null;
  [SerializeField] private float _planeDistance = 1f;
  [SerializeField] private int _sortingOrder = 10;

  private Dictionary<Type, Window> _windowsPool = new Dictionary<Type, Window>();
  private readonly List<Window> _avaliableWindows = new List<Window>();

  public Canvas Canvas => _canvas;

  public void Init()
  {
    GetAvaliableWindows();
    SetCanvasSettings();
    
  }

  private void GetAvaliableWindows()
  {
    Window[] windows = Resources.LoadAll<Window>("UI/Windows/");
    _avaliableWindows.AddRange(windows);
  }

  private void SetCanvasSettings()
  {
    _canvas.planeDistance = _planeDistance;
    _canvas.sortingOrder = _sortingOrder;
  }
  public T Create<T>() where T : Window
  {
    return (T)Create(typeof(T));
  }

  public Window Create(Type window_type)
  {
    Window window;

    if (_windowsPool.ContainsKey(window_type))
      window = _windowsPool[window_type];
    else
    {
      window = Instantiate(_avaliableWindows.Find(w => w.GetType() == window_type));
      _windowsPool.Add(window_type, window);
      window.gameObject.transform.SetParent(_windowContainer, false);
    }

    if(window == null)
    {
      Debug.LogError("Failed to create window");
      return null;
    }

    return window;

  }

}
