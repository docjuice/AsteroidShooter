using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileForward : MonoBehaviour {

    public float speed = 10f;
    [Range(1f, 5f)] public float explodeRadius = 3f;
    public int explodeDamage = 150;
    public GameObject explosionPrefab;

    private Rigidbody rb;

    void Start() {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.up * speed;
    }

    void OnTriggerEnter(Collider other) {
        if (other.tag != "Enemy") {
            return;
        }
        Destroy(Instantiate(explosionPrefab, transform.position, transform.rotation), 1f);

        Collider[] colliders = Physics.OverlapSphere(transform.position, explodeRadius);
        foreach (Collider col in colliders) {
            if (col.tag == "Enemy") {
                float dist = Vector3.Distance(transform.position, col.transform.position);
                float dmg = (float)explodeDamage / dist;
                col.GetComponent<AsteroidController>().OnHit((int)dmg);
            }
        }
        Destroy(gameObject);
    }
}
