using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePhysics : MonoBehaviour
{
    public float Speed = -1;

    void Start() {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(Random.Range(-1.0f, 1.0f), Speed);
    }


    private void OnBecameInvisible() {
        Destroy(gameObject);
    }

    private void Update() {

    }
}
