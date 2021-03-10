using UnityEngine;

public class Monster : MonoBehaviour, IPoolable
{
    public IObjectPool Origin { get; set; }
    
    public void PrepareToUse()
    {
    }

    public void ReturnToPool()
    {
        Origin.ReturnToPool(this);
    }
}


