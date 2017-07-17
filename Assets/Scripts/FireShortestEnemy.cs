using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireShortestEnemy : MonoBehaviour {

    private Transform target;

    [Header("Attributes")]

    public float range = 30f;

    public float fireRate = 2f;

    private float fireCountdown = 0f;

    [Header("Unity Setup Fields")]
        
    public string enemyTag = "Friend";

    public Transform partToRotate;

    public float turnSpeed = 10f;

    public GameObject bulletPrefab;

    public Transform firePoint;


	// Use this for initialization
	void Start () {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
	}

    void UpdateTarget() {

        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach(GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance) {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }

        }
        if (nearestEnemy != null && shortestDistance <= range) {

            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }

    }
    // Update is called once per frame
    void Update () {
        if (target == null)
            return;

        //Vector3 dir = target.position - transform.position;
        //Quaternion lookRotation = Quaternion.LookRotation(dir);
        //Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
       // partToRotate.rotation = Quaternion.Euler(rotation.x, rotation.y, rotation.z);
        if (fireCountdown <= 0f) {
            Shoot();
            fireCountdown = 1f / fireRate;
        }
        fireCountdown -= Time.deltaTime;

    }
    void Shoot() {

        Debug.Log("SHOOT");
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();//bullet class name

        if (bullet != null) {
            bullet.Seek(target);
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
