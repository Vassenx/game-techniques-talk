using System;
using UnityEngine;

public class Monster : MonoBehaviour, IPoolable
{
    private Rigidbody2D _rb;
    private Vector3 _velocity = new Vector3(1.5f, 0, 0);
    
    public IObjectPool Origin { get; set; }
    
    public void PrepareToUse()
    {
    }

    public void ReturnToPool()
    {
        Origin.ReturnToPool(this);
    }

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.gravityScale = 0f;
    }

    private void Update()
    {
        _rb.velocity = _velocity;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("DespawnTrigger"))
        {
            BattleManager.monsterDestroy(this);
            ReturnToPool();
        }
    }
}


