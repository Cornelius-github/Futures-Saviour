using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public TurretBlueprint startingTurret;
    public TurretBlueprint secondTurret;

    BuildManager bm;

    [Header("Turret Shop items")]
    public GameObject boss1turret;

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
        boss1turret.SetActive(true);
    }
}
