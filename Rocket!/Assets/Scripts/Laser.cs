using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour {

    public LineRenderer laser;
    public float maxDistance;

    private RaycastHit hit;
    private Vector3 dir;

    void Update() {
        dir = transform.up;

        if (Physics.Raycast(transform.position, dir, out hit, maxDistance)) {
            if (hit.collider.tag == "Enemy") {
                SetUpLaser(hit.point);
                AsteroidController astCon = hit.collider.GetComponent<AsteroidController>();
                if (astCon != null) {
                    astCon.OnHit();
                }
            } else {
                SetUpLaser(transform.position + dir * maxDistance);
            }
        } else {
            SetUpLaser(transform.position + dir * maxDistance);
        }
    }

    void SetUpLaser(Vector3 pos2) {
        laser.SetPosition(0, transform.position);
        laser.SetPosition(1, pos2);
    }
}
