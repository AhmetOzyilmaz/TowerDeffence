using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursor3D : MonoBehaviour {

	public static Cursor3D instance;

	[HideInInspector]
	public bool IsOnTable;

	[HideInInspector]
	public Vector3 PositionOnTable;

	public LayerMask layer;

	// Use this for initialization
	void Start () {
		instance= this;
	}
	
	// Update is called once per frame
	void Update () {
		CheckOnTheTable();
	}

	public void CheckOnTheTable()
	{
		IsOnTable= false;

		RaycastHit hit;
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		if ( Physics.Raycast(ray, out hit, Mathf.Infinity, layer.value )) {
			if (hit.collider!=null &&  hit.collider.tag == "Table") {
				IsOnTable= true;
				PositionOnTable= hit.point;
				return;
			}
		}
		
	}
}
