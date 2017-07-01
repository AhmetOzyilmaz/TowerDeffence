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
		placerModel.SetActive(false);
		placedModel.SetActive(false);
	}
}
