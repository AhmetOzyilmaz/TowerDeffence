using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieHealth : EnemySoldier
{
    public override void DestroyBuilding()
    {
        base.DestroyBuilding();

        Debug.Log("Zombie Diee");
    }
}
    