using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClickCreateObject : MonoBehaviour {
	public GameObject prefab;

	// Use this for initialization
	void Start () {
		
	}

	public void PutObject(Vector2 mousePosition)
	{
		RaycastHit hit = RayFromCamera(mousePosition, 1000.0f);

		if(hit.collider.tag=="Table")
			GameObject.Instantiate(prefab, hit.point, Quaternion.identity);
	}

	public RaycastHit RayFromCamera(Vector3 mousePosition, float rayLength)
	{
		RaycastHit hit;
		Ray ray = Camera.main.ScreenPointToRay(mousePosition);
		Physics.Raycast(ray, out hit, rayLength);
		return hit;
	}

	// Update is called once per frame
	void Update () {

		if (Input.GetMouseButtonDown (0)) {

			PutObject (Input.mousePosition);	
			Debug.Log("XXXXXXXXXXXXXX");
			PrintMousePosition ();
		}

	}

	void PrintMousePosition(){
	
		Vector3 mousePos = Input.mousePosition;

		Debug.Log ("X" + mousePos.x);
		Debug.Log ("Y" + mousePos.y);
		Debug.Log ("Z" + mousePos.z);

	}
}
