using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Placeable : MonoBehaviour {
	public GameObject placerModel;
	public GameObject placedModel;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void HideAll(){
        if (placerModel.active == true)
            placerModel.SetActive(false);
        if(placedModel.active == true)
		    placedModel.SetActive(false);
	}

	public bool isDistanceCheck(List<Vector3> positionList){

		//Debug.Log("Gelen list " + positionList.Count);

		if( positionList.Count == 0)
        	positionList.Add( Cursor3D.instance.PositionOnTable);

		for(int i = 0 ; i < (positionList.Count); ++i){

			if(!DistanceCheckWith2Objects(positionList[i],Cursor3D.instance.PositionOnTable,0.3)){
				return false;
			}

			float distance = Vector3.Distance(positionList[i],Cursor3D.instance.PositionOnTable);
			//print("Distance to other: " + distance);

		}
		return true;
	}

	//About Distance
	public bool DistanceCheckWith2Objects(Vector3 ObPos,Vector3 ObPos2,double distance){
		if(FindDistance(ObPos,ObPos2) > distance)
			return true;		
		return false;
	}

	public double FindDistance(Vector3 a, Vector3 b)
     {
         return Vector3.Distance(a,b);
     }

	//About Distance*/

}
