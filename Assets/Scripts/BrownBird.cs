using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrownBird : Bird
{
    public GameObject deathEffect;
    private int counter = 0;
    private int maxCounter = 10;

    private IEnumerator ExplodeAfter(float second) {
        Debug.Log(second);
        if (counter > maxCounter) Destroy(gameObject);
        else {
            yield return new WaitForSeconds(second);
            Collider.radius += Time.fixedDeltaTime * (2 + counter++);
            StartCoroutine(ExplodeAfter(second / 2.0f));
        }
    }

    public override void OnHit() {
        RigidBody.bodyType = RigidbodyType2D.Kinematic;
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        StartCoroutine(ExplodeAfter(0.01f));
    }
}
