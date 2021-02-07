using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    public float Health = 50f;
    public UnityAction<GameObject> OnEnemyDestroy = delegate { };
    private bool _isHit = false;
    void OnDestroy()
    {
        if (_isHit) {
            OnEnemyDestroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.GetComponent<Rigidbody2D>() == null) return;

        if (other.gameObject.tag == "Bird") {
            _isHit = true;
            Destroy(gameObject);
        } else if (other.gameObject.tag == "Obstacle") {
            float damage = other.gameObject.GetComponent<Rigidbody2D>().velocity.magnitude * 10;
            Health -= damage;

            if (damage <= 0) {
                _isHit = true;
                Destroy(gameObject);
            }
        }
    }
}
