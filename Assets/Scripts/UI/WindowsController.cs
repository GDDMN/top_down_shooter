using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class WindowsController : MonoBehaviour
{
  public event Action<Window> OnCreateWindow;

  [SerializeField] private GameObject _windowContainer = null;
  [SerializeField] private List<Window> _avaliableWindows = new List<Window>();

  private Dictionary<Type, Window> _windowsPool = new Dictionary<Type, Window>();
  
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
      window = UnityEngine.Object.Instantiate(_avaliableWindows.Find(w => w.GetType() == window_type));
      window.gameObject.transform.SetParent(_windowContainer.transform, false);
      window.gameObject.SetActive(false);
    }

    if(window == null)
    {
      Debug.LogError("Failed to create window");
      return null;
    }

    return window;

  }

}
