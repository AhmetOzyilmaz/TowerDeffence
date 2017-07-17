using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour {

    Building target;

    public float speed= 1.0f;
    public int damage = 1;

    private void Update() {
        if( target ) {
            MoveTowardsTarget();
        }
        else {
            FindTarget();
        }
    }

    void FindTarget() {
        target = null;

        Building[] buildings = FindObjectsOfType<Building>();

        float closestDist = Mathf.Infinity;
        Building closest= null;
        foreach ( Building b in buildings ) {
            float dist = Vector3.Distance(transform.position, b.transform.position);
            if( dist < closestDist ) {
                closest = b;
                closestDist = dist;
            } 
        }

        target = closest;
    }

    void MoveTowardsTarget() {
        if (!target)
            return;

        float y = transform.position.y;
        Vector3 nextposition = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
        nextposition.y = y;
        transform.position = nextposition;

        Vector3 distCheckPos = transform.position;
        distCheckPos.y = target.transform.position.y;
        if ( Vector3.Distance(distCheckPos, target.transform.position) < 0.01f ) {
            ExplodeOnTarget();
        }
    }

    void ExplodeOnTarget() {
        if (!target)
            return;

        target.TakeDamage(damage);

        Destroy(gameObject);
    }

}
