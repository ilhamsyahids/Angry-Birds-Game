using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    public float Health = 50f;
    public UnityAction<GameObject> OnEnemyDestroy = delegate { };
    private bool _isHit = false;
    void Start()
    {
        if (_isHit) {
            OnEnemyDestroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
