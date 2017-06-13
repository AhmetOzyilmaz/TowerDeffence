using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClickCreateObject : MonoBehaviour {
	public GameObject BaseTower;
	public GameObject Enemy;

	int Counter = 0;

	// Use this for initialization
	void Start () {
		
	}



	// Update is called once per frame
	void Update () {
		//base flag 

		if (Counter == 0 && Input.GetMouseButtonDown (0)) {
			PutObject (Input.mousePosition,BaseTower);	
			//Debug.Log("XXXXXXXXXXXXXX");
			//PrintMousePosition ();
			++Counter;
		}else if (Counter == 1 && Input.GetMouseButtonDown (0)) {

			RaycastHit hit = RayFromCamera(Input.mousePosition, 1000.0f);
			var TowerPosition = BaseTower.transform.position;


			var Distance = Vector3.Distance (BaseTower.transform.position, hit.point);
			//Distance check part
			Debug.Log ("------------->  " + Distance);
			if (Distance > 1.43) {
				Debug.Log ("------------->  Buraya Koyulamaz " );

			} else {
			
				PutObject (Input.mousePosition,Enemy);
				++Counter;

			}
			//var distance = Vector3.Distance(BaseTower.transform.position, MousePos.transform.position);


			//Debug.Log("XXXXXXXXXXXXXX");
			//PrintMousePosition ();
		}

	}

	public void PutObject(Vector2 mousePosition,GameObject ob)
	{
		RaycastHit hit = RayFromCamera(mousePosition, 1000.0f);
	if (hit.collider.tag == "Table") {
			Vector3 point = hit.point;
			point.y +=(float)0.05;
			GameObject.Instantiate (ob, point, Quaternion.identity);
		}
	}

	public RaycastHit RayFromCamera(Vector3 mousePosition, float rayLength)
	{
		RaycastHit hit;
		Ray ray = Camera.main.ScreenPointToRay(mousePosition);
		Physics.Raycast(ray, out hit, rayLength);
		return hit;
	}

	void PrintMousePosition(){
	
		Vector3 mousePos = Input.mousePosition;

		Debug.Log ("X" + mousePos.x);
		Debug.Log ("Y" + mousePos.y);
		Debug.Log ("Z" + mousePos.z);

	}
}
