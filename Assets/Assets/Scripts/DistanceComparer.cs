using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class DistanceComparer : IComparer {

	private Transform compareTransform;
	// Use this for initialization

	public DistanceComparer(Transform compTransform){
		compareTransform = compTransform;
	}

	public int Compare(object x, object y){
		Collider xCollider = x as Collider;
		Collider yCollider = y as Collider;

		Vector3 offset = xCollider.transform.position - compareTransform.transform.position;
		float xDistance =  offset.sqrMagnitude;

		offset = yCollider.transform.position - compareTransform.transform.position;
		float yDistance =  offset.sqrMagnitude;
		
		return xDistance.CompareTo(yDistance);
	}
}
