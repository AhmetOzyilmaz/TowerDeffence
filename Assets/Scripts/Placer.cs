using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Placer : MonoBehaviour {
	private int index = 0;
	private bool flag = true;
	
	public Placeable placeable;
	
    public  List<Vector3> positionList;

	public Vector3 LastPosition;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void LateUpdate () {
		UpdatePlaceablePosition();
        UpdatePositionList();

        if ( Input.GetMouseButtonDown(0)) {
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
    public void UpdatePositionList() {
      /*  bool flag = false;
        foreach (Vector3 pos in positionList) {

            var hitColliders = Physics.OverlapSphere(pos, 0.05f);//1 is purely chosen arbitrarly
            Debug.Log("UPDATE FUCK2 " + hitColliders.Length);

            if (hitColliders.Length > 0) //You have someone with a collider here
                flag = true;
            else
                flag = false;
            
            if (flag == false)
            {
                positionList.Remove(pos);
                --index;
            }
        }
        Debug.Log("UPDATE FUCK " + positionList.Count);*/

    }
    // mouse click ettiğinde sıradaki yerleştirilcek objeyi masaüstündeyse yerleştirir.
    public void Place(){

        
		if(placeable != null) {
			if( Cursor3D.instance.IsOnTable ) {

				if(positionList.Count > 0){							
					flag= placeable.isDistanceCheck(positionList);
					//LastPosition = Cursor3D.instance.PositionOnTable;
					Debug.Log("+++ " + positionList.Count);
					Debug.Log("*** " + positionList[index]);
					//print("distance " + flag);


					if(flag){
						placeable.transform.position= Cursor3D.instance.PositionOnTable;
						positionList.Add( Cursor3D.instance.PositionOnTable);
						placeable.placerModel.SetActive(false);
						placeable.placedModel.SetActive(true);
						placeable= null;

                        ++index;

                    }
                    else
                    {

						//if( Input.GetMouseButtonDown(0)) {
						//	Place();

						//}
					}
				
				}
				else if(positionList.Count == 0){
					placeable.transform.position= Cursor3D.instance.PositionOnTable;
					positionList.Add( Cursor3D.instance.PositionOnTable);
					placeable.placerModel.SetActive(false);
					placeable.placedModel.SetActive(true);
					placeable= null;
                    index = 0;

                }

			}
		}

	}
}
