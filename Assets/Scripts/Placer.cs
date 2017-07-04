using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Placer : MonoBehaviour {
	private int index = 0;
	private bool flag = true;

	public Placeable placeable;
	
    public List<Vector3> positionList;

	public Vector3 LastPosition;

	public Distance dist;

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

	// mouse click ettiğinde sıradaki yerleştirilcek objeyi masaüstündeyse yerleştirir.
	void Place(){
		if(placeable != null) {
			if( Cursor3D.instance.IsOnTable ) {								

				//LastPosition = Cursor3D.instance.PositionOnTable;
             /*   positionList.Add( Cursor3D.instance.PositionOnTable);

				Debug.Log("+++ " + positionList.Count);
				Debug.Log("*** " + positionList[index]);
				++index;
*/
			/*	for(int i = 0 ; i < (positionList.Count-1); ++i){
				  if(positionList.Count>=2){
					if(!dist.DistanceCheckWith2Objects(positionList[0],positionList[i],0.4)){
						flag = false;
					}
						float distance = Vector3.Distance(positionList[i],positionList[i+1]);
						print("Distance to other: " + distance);
			
					
					}
				}
				if(flag){*/
					placeable.transform.position= Cursor3D.instance.PositionOnTable;
					placeable.placerModel.SetActive(false);
					placeable.placedModel.SetActive(true);
					placeable= null;
				/*}else{
					flag = true;

				}*/

			}
		}

	}
}
