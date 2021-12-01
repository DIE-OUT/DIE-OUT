using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class BaseManager : MonoBehaviour {

    private void Awake() {
        Manager.Register(this);
        OnAwake();
    }

    private void OnDestroy() {
        Manager.Unregister(this);
    }

    protected virtual void OnAwake() { }
    
}

public abstract class StaticBaseManager : BaseManager { }

public abstract class StaticBaseManager<T> : StaticBaseManager where T : StaticBaseManager<T> { }

public class ModuleAlreadyRegisteredException : Exception {
    public ModuleAlreadyRegisteredException(string message) : base(message) { }
}

public class ModuleNotFoundException : Exception { }

public static class Manager {
    
    private static List<BaseManager> _modules = new List<BaseManager>();
    
    
    public static void Register(BaseManager baseManager) {
        if (ModuleRegistered(baseManager.GetType()))
            throw new ModuleAlreadyRegisteredException($"{baseManager.GetType().Name} is already registered");
        _modules.Add(baseManager);
    }

    public static void Unregister(BaseManager baseManager) {
        if (!ModuleRegistered(baseManager.GetType()))
            throw new ModuleNotFoundException();
        _modules.Remove(baseManager);
    }

    private static bool ModuleRegistered(Type t) {
        return _modules.Any(m => m.GetType() == t);
    }

    public static bool ModuleRegistered<T>() {
        return ModuleRegistered(typeof(T));
    }

    public static T Get<T>() where T : BaseManager {
        if(!ModuleRegistered(typeof(T))) {
            if (typeof(T).IsSubclassOf(typeof(StaticBaseManager))) {
                GameObject go = new GameObject(typeof(T).Name);
                //go.transform.parent = _instance.gameObject.transform;
                return (T)go.AddComponent(typeof(T));
            }
            throw new ModuleNotFoundException();
        }
        return _modules.Single(m => m.GetType() == typeof(T)) as T;
    }
    
}
