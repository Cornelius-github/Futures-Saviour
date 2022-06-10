using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public TurretBlueprint startingTurret;
    public TurretBlueprint secondTurret;

    BuildManager bm;

    [Header("Turret Shop items")]
    public GameObject boss1turret;
    public Text boss1amount;

    public static Shop instance; //this stores a buildmanager in the buildmanager

    private void Awake()
    {
        instance = this;
    }

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
        boss1amount.text = secondTurret.amount.ToString();
        bm.SelectTurretToBuild(secondTurret);
        boss1turret.SetActive(true);
    }

    public void InventoryCheck(TurretBlueprint turret)
    {
        //modifications to inventory
        if (turret.amount <= 0)
        {
            boss1turret.SetActive(false);
        }
        else
        {
            boss1amount.text = turret.amount.ToString();
        }
    }
}
