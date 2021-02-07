using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Bird : MonoBehaviour
{
    public enum BirdState { Idle, Thrown, HitSomething }
    public GameObject Parent;
    public Rigidbody2D RigidBody;
    public CircleCollider2D Collider;
    public UnityAction OnBirdDestroy = delegate { };
    public UnityAction<Bird> OnBirdShot = delegate { };

    private BirdState _state;
    private float _minVelocity = 0.05f;
    private bool _flagDestroy = false;
    public BirdState State {
        get {
            return _state;
        }
    }

    void Start()
    {
        RigidBody.bodyType = RigidbodyType2D.Kinematic;
        Collider.enabled = false;
        _state = BirdState.Idle;
    }


    private void OnDestroy() {
        if(_state == BirdState.Thrown || _state == BirdState.HitSomething) {
            OnBirdDestroy();
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        _state = BirdState.HitSomething;
    }

    private void FixedUpdate() {
        if (_state == BirdState.Idle
            && RigidBody.velocity.sqrMagnitude >= _minVelocity) {
            _state = BirdState.Thrown;
        }
        if ((_state == BirdState.Thrown || _state == BirdState.HitSomething) 
            && RigidBody.velocity.sqrMagnitude < _minVelocity
            && !_flagDestroy) {
            // destroy after 2s
            _flagDestroy = true;
            StartCoroutine(DestroyAfter(2));
        }
    }

    private IEnumerator DestroyAfter(float second) {
        yield return new WaitForSeconds(second);
        Destroy(gameObject);
    }

    public void MoveTo(Vector2 target, GameObject parent) {
        gameObject.transform.SetParent(parent.transform);
        gameObject.transform.position = target;
    }

    public void Shoot(Vector2 velocity, float dist, float speed) {
        Collider.enabled = true;
        RigidBody.bodyType = RigidbodyType2D.Dynamic;
        RigidBody.velocity = velocity * speed * dist;
        OnBirdShot(this);
    }

    public virtual void OnTap() {
        // Do nothing
    }
}
