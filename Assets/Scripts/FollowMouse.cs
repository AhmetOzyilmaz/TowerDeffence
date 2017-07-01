using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour {

	public float distance = 1f;
	public bool useInitalCameraDistance = false;
	private float actualDistance;
	public GameObject g;
	// Use this for initialization
	void Start ()
	{
		if(useInitalCameraDistance)
		{
			Vector3 toObjectVector = transform.position - Camera.main.transform.position;
			Vector3 linearDistanceVector = Vector3.Project(toObjectVector,Camera.main.transform.forward);
			actualDistance = linearDistanceVector.magnitude;
		}
		else
		{
			actualDistance = distance;
		}
	}

	// Update is called once per frame
	void Update ()
	{

	/*	Debug.Log ("x ---> "  +Input.mousePosition.x);
		Debug.Log ("y ---> "  +Input.mousePosition.y);
		Debug.Log ("z ---> "  +Input.mousePosition.z);*/


		//if (Input.mousePosition.x > 600 && Input.mousePosition.x < 700 && Input.mousePosition.y > 350  && Input.mousePosition.y < 850) {
		   Vector3 mousePosition = Input.mousePosition;
			CheckOnTheTable (Input.mousePosition, g);
	//
	}

	public void CheckOnTheTable(Vector3 mousePosition,GameObject ob)
	{
		RaycastHit hit = RayFromCamera(mousePosition, 1000.0f);
		if (hit.collider.tag == "Table") {
			Debug.Log ("Masada");

			mousePosition.z = actualDistance;
			transform.position = Camera.main.ScreenToWorldPoint(mousePosition);
		}
	}

	public RaycastHit RayFromCamera(Vector3 mousePosition, float rayLength)
	{
		RaycastHit hit;
		Ray ray = Camera.main.ScreenPointToRay(mousePosition);
		Physics.Raycast(ray, out hit, rayLength);
		return hit;
	}


}
