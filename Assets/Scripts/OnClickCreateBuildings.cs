using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClickCreateBuildings : MonoBehaviour {
    public Placeable create;
    public Placer placer;

    void OnMouseDown()
    {
        Placeable p =Instantiate(create);
        placer.placeable = p;
        placer.Place();
        // this object was clicked - do something
        //Destroy(this.gameObject);
    }

}
