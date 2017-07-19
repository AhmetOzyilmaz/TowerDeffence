using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : Building {
    public override void DestroyBuilding() {
        base.DestroyBuilding();

        Debug.Log("You lose nuub");
    }
}
