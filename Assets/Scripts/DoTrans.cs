using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoTrans : MonoBehaviour {

	public GameObject g;



	// Use this for initialization
	void Start () {
		//GetComponent<Renderer>().material.color= new Color (1.0f, 1.0f, 1.0f, 1.0f);
	}

	// Update is called once per frame
	void Update () {
		GetComponent<Renderer> ().material.color = new Color (g.GetComponent<Renderer> ().material.color.r, g.GetComponent<Renderer> ().material.color.g, g.GetComponent<Renderer> ().material.color.b, 0.5f);

	}
}
