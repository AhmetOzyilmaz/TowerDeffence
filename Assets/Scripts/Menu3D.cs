using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu3D : MonoBehaviour {
	
	public List<Placeable> placeables;

	public GameObject archer;
	public GameObject mortar;
	public GameObject cannon;

	public Placer placer;

	private int ClickedButtonId ;

	public LayerMask layer;

	// Use this for initialization
	void Start () {
		foreach( Placeable p in placeables ) {
			p.HideAll();
		}
	}
	
	// Update is called once per frame
	void LateUpdate () {
		if( Input.GetMouseButtonDown(0)) {
			var num = WhichMenuElementClicked();
			print("--->" +num);
			if(num == 1){
				placer.placeable= placeables[0];
				placer.Place();
				
			}else if(num == 2){
				placer.placeable= placeables[2];
				placer.Place();
				
			}else if(num == 3){
				placer.placeable= placeables[1];
				placer.Place();
				
			}


		}
	}
	public int WhichMenuElementClicked(){

		RaycastHit hit;
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		if ( Physics.Raycast(ray, out hit, Mathf.Infinity, layer.value )) {
			if (hit.collider!=null &&  hit.collider.tag == "archer") {
				//PositionOnTable= hit.point;
				return 1;
			}
			else if (hit.collider!=null &&  hit.collider.tag == "cannon") {
							//PositionOnTable= hit.point;
				return 2;
			}
			else if (hit.collider!=null &&  hit.collider.tag == "mortar") {
							//PositionOnTable= hit.point;
				return 3;
			}		
		}

		return 0;
	}
}
