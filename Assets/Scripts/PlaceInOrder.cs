using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceInOrder : MonoBehaviour {

	public int index = 0 ;
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
			if(p!=null) {
				if(placeables.Count>index)
			   		++index;
				placer.placeable= p;

				//for(int i = 0; i < i+1;++i){
					//if(!dist.DistanceCheckWith2Objects(placeables[i].transform.position,placeables[i+1].transform.position,1))
					//	flag = false;

			//	if(index >= 1 &&  placeables.Count>index){
					//Debug.Log(dist.FindDistance(placeables[0].placerModel.transform.position,placeables[1].placerModel.transform.position));
					//Debug.Log(placeables[1].transform.position);
			}
					
			
		}
	}

	Placeable NextPlaceable() {
		if( placeables.Count > index ) {
			Placeable p= placeables[index];
			//placeables.Remove(p);
			return p;
		}
		return null;
	}
}

