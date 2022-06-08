using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public TurretBlueprint startingTurret;
    public TurretBlueprint secondTurret;

    BuildManager bm;

    private void Start()
    {
        bm = BuildManager.instance;
    }

    public void PurchaseStandardTurret() //just selection
    {
        bm.SelectTurretToBuild(startingTurret);
    }

    public void PurchaseStartingTurret() //just selection
    {
        bm.SelectTurretToBuild(secondTurret);
    }
}
