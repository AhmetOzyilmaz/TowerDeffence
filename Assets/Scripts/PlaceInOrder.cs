using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceInOrder : MonoBehaviour {

	public Placer placer;

	public List<Placeable> placeables;

	// Use this for initialization
	void Start () {
		foreach( Placeable p in placeables ) {
			p.HideAll();
		}
	}
	
	// Update is called once per frame
	void Update () {
		if( placer.placeable == null ) {
			Placeable p= NextPlaceable();

			if(p!=null) placer.placeable= p;
		}
	}

	Placeable NextPlaceable() {
		if( placeables.Count > 0 ) {
			Placeable p= placeables[0];
			placeables.Remove(p);
			return p;
		}
		return null;
	}
}
