using System.Collections.Generic;
using UnityEngine;

// TODO: SAM alt-D is go to declaration


// Object pool code from: https://www.patrykgalach.com/2019/04/01/how-to-implement-object-pooling-in-unity/ (edited)

/// <summary>
/// Basic object pool implementation
/// </summary>
public class GenericObjectPool<T> : MonoBehaviour, IObjectPool
    where T : MonoBehaviour, IPoolable //C# Generics with constraints
{
    // Reference to prefab
    [SerializeField] private T prefab;

    // References to reusable instances
    private Stack<T> objectPool = new Stack<T>();

    /// <summary>
    /// Returns instance of prefab.
    /// </summary>
    /// <returns>Instance of prefab.</returns>
    public T GetPrefabInstance()
    {
        T instance;
        if (objectPool.Count > 0)
        {
            // get & remove object from pool
            instance = objectPool.Pop();

            var objTransform = instance.transform;
            
            // remove parent
            objTransform.SetParent(null);

            // reset position
            objTransform.localPosition = Vector3.zero;
            objTransform.localScale = Vector3.one;
            objTransform.localEulerAngles = Vector3.one;

            // activate object
            instance.gameObject.SetActive(true);
        }
        // otherwise create new instance of prefab
        else
        {
            instance = Instantiate(prefab);
        }

        instance.Origin = this; //object knows which pool to go back to
        instance.PrepareToUse();

        return instance;
    }

    /// <summary>
    /// Returns instance to the pool.
    /// </summary>
    /// <param name="instance">Prefab instance.</param>
    public void ReturnToPool(T instance)
    {
        instance.gameObject.SetActive(false);

        var objTransform = instance.transform;
        
        // set parent as this object
        objTransform.SetParent(transform);

        // reset position
        objTransform.localPosition = Vector3.zero;
        objTransform.localScale = Vector3.one;
        objTransform.localEulerAngles = Vector3.one;

        // add to pool
        objectPool.Push(instance);
    }

    /// <summary>
    /// Returns instance to the pool.
    /// Additional check is this is correct type.
    /// </summary>
    /// <param name="instance">Instance.</param>
    public void ReturnToPool(object instance)
    {
        // if instance is of our generic type we can return it to our pool
        if (instance is T)
        {
            ReturnToPool(instance as T);
        }
        else
        {
            Debug.LogError("Warning! Wrong object type for object pooling: " + instance + " pool: " + this.name);
        }
    }
}