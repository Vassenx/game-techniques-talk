using UnityEngine;

/// <summary>
/// Interface for poolable objects
/// </summary>
public interface IPoolable
{
    IObjectPool Origin { get; set; }

    void PrepareToUse();
    void ReturnToPool();
}