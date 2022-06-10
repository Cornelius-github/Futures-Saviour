using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    //singleton pattern done here; search for more around this to get a better understanding

    public static BuildManager instance; //this stores a buildmanager in the buildmanager //other scipts
    Shop shop;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        shop = Shop.instance;
    }

    public GameObject standardTurret;
    public GameObject startingTurret;

    private TurretBlueprint turretToBuild;

    //property, as we only allow it to get something as it can never be set. basically we are writing a small function, that returns the result.
    public bool CanBuild {  get { return turretToBuild != null; } } 

    public void SelectTurretToBuild (TurretBlueprint turret)
    {
        turretToBuild = turret;
    }

    public void BuildTurretOn (Node node)
    {
        //// if using currency to buy towers
        //if (PlayerStats.Money < turretToBuild.cost)
        //{
        //    return;
        //}
        //if (PlayerStats.Money >= turretToBuild.cost)
        //{
        //    Debug.Log("build");
        //    PlayerStats.Money -= turretToBuild.cost;

        //    GameObject turret = (GameObject)Instantiate(turretToBuild.prefab, (node.transform.position + node.offset), Quaternion.identity);
        //    node.turret = turret;
        //}

        //if using count rather than currency to buy
        if (turretToBuild.amount <= 0)
        {
            return;
        }
        if (1 >= turretToBuild.amount)
        {
            turretToBuild.amount--;

            GameObject turret = (GameObject)Instantiate(turretToBuild.prefab, (node.transform.position + node.offset), Quaternion.identity);
            node.turret = turret;

            shop.InventoryCheck(turretToBuild);
        }
    }

}
