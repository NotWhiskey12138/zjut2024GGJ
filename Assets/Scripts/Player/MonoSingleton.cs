using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class MonoSingleton<T> : MonoBehaviour where T : MonoSingleton<T>
{
    protected static T _instance;

    /// <summary>
    /// 是否实例化
    /// </summary>
    public static bool initialized;

    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<T>();
                if (FindObjectsOfType<T>().Length > 1)
                {
                    return _instance;
                }
                if (_instance == null)
                {
                    string name = typeof(T).Name;
                    GameObject obj = GameObject.Find(name);
                    if (obj == null)
                    {
                        obj = new GameObject(name);
                    }
                    _instance = obj.AddComponent<T>();
                    DontDestroyOnLoad(obj);
                }
            }
            initialized = true;
            return _instance;
        }
    }

    protected virtual void Awake()
    {
        if (initialized)
        {
            Destroy(gameObject);
        }
    }

    protected virtual void OnDestroy()
    {
        _instance = null;
        initialized = false;
    }
}