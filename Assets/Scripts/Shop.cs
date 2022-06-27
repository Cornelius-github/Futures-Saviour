using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public TurretBlueprint startingTurret;
    public TurretBlueprint secondTurret;
    public TurretBlueprint thirdTurret;
    public TurretBlueprint fourthTurret;

    BuildManager bm;

    [Header("Turret Shop items")]
    public GameObject boss1turret;
    public Text boss1amount;
    public GameObject boss2turret;
    public Text boss2amount;
    public GameObject boss3turret;
    public Text boss3amount;

    public string currentTurret;

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

    public void PurchaseBoss2Turret() //just selection
    {
        boss2amount.text = thirdTurret.amount.ToString();
        bm.SelectTurretToBuild(thirdTurret);
        boss2turret.SetActive(true);
    }

    public void PurchaseBoss3Turret() //just selection
    {
        boss3amount.text = fourthTurret.amount.ToString();
        bm.SelectTurretToBuild(fourthTurret);
        boss3turret.SetActive(true);
    }

    //button functions
    public void SelectTurret1()
    {
        bm.SelectTurretToBuild(secondTurret);
    }

    public void SelectTurret2()
    {
        bm.SelectTurretToBuild(thirdTurret);
    }

    public void SelectTurret3()
    {
        bm.SelectTurretToBuild(fourthTurret);
    }


    public void InventoryCheck(TurretBlueprint turret)
    {
        //modifications to inventory
        if (turret.amount <= 0)
        {
            if (turret == secondTurret)
            {
                boss1turret.SetActive(false);
            }
            if (turret == thirdTurret)
            {
                boss2turret.SetActive(false);
            }
            if (turret == fourthTurret)
            {
                boss3turret.SetActive(false);
            }

        }
        else
        {
            boss1amount.text = turret.amount.ToString();
            boss2amount.text = turret.amount.ToString();
            boss3amount.text = turret.amount.ToString();
        }
    }
}
