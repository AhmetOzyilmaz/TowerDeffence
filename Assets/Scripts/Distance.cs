using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Distance : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	public bool DistanceCheckWith2Objects(Vector3 ObPos,Vector3 ObPos2,double distance){
		if(FindDistance(ObPos,ObPos2) > distance)
			return true;		
		return false;
	}

	public double FindDistance(Vector3 a, Vector3 b)
     {
         return Vector3.Distance(a,b);
     }
}
