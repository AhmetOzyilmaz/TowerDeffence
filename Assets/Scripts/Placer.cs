using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Placer : MonoBehaviour {

	public Placeable placeable;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void LateUpdate () {
		UpdatePlaceablePosition();

		if( Input.GetMouseButtonDown(0)) {
			Place();
		}
	}

	public void StartPlacing(Placeable placeable) {
		this.placeable= placeable;

		placeable.placedModel.SetActive(false);
		placeable.placerModel.SetActive(false);
	}

	void UpdatePlaceablePosition(){
		if(placeable != null) {
			if( Cursor3D.instance.IsOnTable ) {
				placeable.transform.position= Cursor3D.instance.PositionOnTable;
				placeable.placerModel.SetActive(true);
			}
			else{
				placeable.placerModel.SetActive(false);
			}
		}
	}

	void Place(){
		if(placeable != null) {
			if( Cursor3D.instance.IsOnTable ) {
				placeable.transform.position= Cursor3D.instance.PositionOnTable;
				placeable.placerModel.SetActive(false);
				placeable.placedModel.SetActive(true);

				placeable= null;
			}
		}
	}
}
