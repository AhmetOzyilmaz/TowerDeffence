using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ClosestBuilding : MonoBehaviour {
    public GameObject startposition;
	private float checkRadius = 1.0f;
	public LayerMask checkLayers = 10;//friend layer
    public static Vector3 target_position = new Vector3(0, 0, 0);
    public static Vector3 enhancing = new Vector3(0, 0, 0);
    public bool flag = false;

    public float spawnRate = 1.0f;
    float timeLeftToSpawn;

    void Start()
	{
        this.transform.position = startposition.transform.position;

        /* timeLeftToSpawn -= Time.deltaTime;
         if (timeLeftToSpawn < 0)
         {

             //0 item en yakın obje

             //closest_item();
             timeLeftToSpawn = spawnRate;

         }*/
    }
    private void LateUpdate()
    {
        timeLeftToSpawn -= Time.deltaTime;

        if (timeLeftToSpawn < 0)
        {
            enhancing = AccordingToSlope();
            transform.Translate(enhancing.x * (Time.deltaTime / 10), 0f, enhancing.z * (Time.deltaTime / 10));

            timeLeftToSpawn = spawnRate;
        }

        //    Debug.Log(target_position.x + "  " + target_position.y + " " + target_position.z + " *\n");
    }
    public Vector3 AccordingToSlope() {
        Vector3 result = new Vector3(0,0,0);
        if(flag == false)
        {
            target_position = closest_item();

        }


        float slope_x = target_position.x = this.transform.position.x;
        float slope_z = target_position.z = this.transform.position.z;
        float slope = slope_z / slope_x;

        Debug.Log("SLOPE -> " + slope);
        Debug.Log("SLOPE.Z -> " + slope_z);
        Debug.Log("SLOPE.X -> " + slope_x);

        if (slope_x > 0 && slope_z > 0)
        {
            Debug.Log("COMEEE1");
            result.x = -1;
            result.z = -1 * slope;
        }
        else if (slope_x > 0 && slope_z < 0)
        {
            Debug.Log("COMEEE2");
            result.x = -1;
            result.z = -1 * slope;
        }
        else if (slope_x < 0 && slope_z > 0)
        {
            Debug.Log("COMEEE3");
            result.x = 10;
            result.z = 10 * slope;
        }
        else if (slope_x < 0 && slope_z < 0)
        {
            Debug.Log("COMEEE4");
            result.x = -1;
            result.z = slope;
        }


            Debug.Log(target_position.x + "  " + target_position.y + " " + target_position.z + " *");


        return result;
    }
    public Vector3 closest_item() {
        Collider[] colliders = Physics.OverlapSphere(transform.position, checkRadius, checkLayers);
        Vector3 return_position = new Vector3(0,0,0);
        
        if(colliders.Length != 0 && colliders != null)
        {
           // Debug.Log("****" + colliders.Length);

            Array.Sort(colliders, new DistanceComparer(transform));

           /*  foreach (Collider item in colliders)
            {
                Debug.Log(item.name);
            }
            */
            return_position = colliders[0].transform.position;
        }
      
        return return_position;
    }
	private void OnDrawGizmos(){
		Gizmos.DrawWireSphere(transform.position,checkRadius);
	}

}
