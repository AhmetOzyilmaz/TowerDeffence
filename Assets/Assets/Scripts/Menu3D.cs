using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu3D : MonoBehaviour {
	
	public List<Placeable> placeables;


	//public Placer placer;

	//private int ClickedButtonId ;

	//public LayerMask layer;

	// Use this for initialization
	void Start () {
		foreach( Placeable p in placeables ) {
			p.HideAll();
		}
	}
	
	// Update is called once per frame
	void LateUpdate () {
		if( Input.GetMouseButtonDown(0)) {
            //var num = WhichMenuElementClicked();

            //Placeable p = Instantiate(placeables[0]);
				
		}
	}
}
