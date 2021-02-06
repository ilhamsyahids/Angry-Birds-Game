using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlingShooter : MonoBehaviour
{
    public CircleCollider2D Collider;
    private Vector2 _startPos;

    [SerializeField]
    private float _radius = 0.75f;
    [SerializeField]
    private float _throwSpeed = 30f;
    void Start()
    {
        _startPos = transform.position;
    }

    private void OnMouseUp() {
        Collider.enabled = false;
        Vector2 velocity = _startPos - (Vector2) transform.position;
        float distance = Vector2.Distance(_startPos, transform.position);

        // revert SlingShooter position
        gameObject.transform.position = _startPos;
    }

    private void OnMouseDrag() {
        // change mouse position to world position
        Vector2 p = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // change rubber slingShooter in the constrain
        Vector2 dir = p - _startPos;
        if (dir.sqrMagnitude > _radius) {
            dir = dir.normalized * _radius;
        }
        transform.position = _startPos + dir;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
