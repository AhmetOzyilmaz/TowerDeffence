using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ClosestBuilding : MonoBehaviour {

	private float checkRadius = 1.0f;
	private LayerMask checkLayers = 10;//friend layer


    private void LateUpdate()
	{
       /* timeLeftToSpawn -= Time.deltaTime;
        if (timeLeftToSpawn < 0)
        {

            //0 item en yakın obje

            //closest_item();
            timeLeftToSpawn = spawnRate;

        }*/
    }
    public Vector3 closest_item() {
        Collider[] colliders = Physics.OverlapSphere(transform.position, checkRadius, checkLayers);
        Vector3 return_position = new Vector3(0,0,0);
        
        if(colliders.Length != 0)
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
