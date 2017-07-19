using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour {
    public int health= 3;

    public void TakeDamage(int dmg) {
        health -= dmg;

        if(health <= 0) {
            DestroyBuilding();
        }
    }

    public virtual void DestroyBuilding() {
        Destroy(transform.parent.gameObject);
    }
}
