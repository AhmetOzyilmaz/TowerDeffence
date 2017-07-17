using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    public ClosestBuilding close;


	public float rayDistance = 3.0f;

	public LayerMask layer;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 target_position = close.closest_item();
        Debug.Log(target_position.x + "  " + target_position.y + " " + target_position.z + " *\n");
        transform.Translate(1f * (Time.deltaTime) / 2, 0f, 1f * (Time.deltaTime) / 2);

    }


    /*	Vector3 FindEnemy(){
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(this.transform.position,hit,rayDistance,layer.value)){
                Debug.DrawLine(ray.origin,hit.point,Color.green);
                if(hit.collider!=null &&hit.transform.tag.Equals("Friend")){
                    Debug.Log("Hit the friend buildingss");	
                    return hit.point;
                }
            }
            return new Vector3(0,0,0);
        }*/
}
