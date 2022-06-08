using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    //singleton pattern done here; search for more around this to get a better understanding

    public static BuildManager instance; //this stores a buildmanager in the buildmanager

    private void Awake()
    {
        instance = this;
    }

    public GameObject standardTurret;
    public GameObject startingTurret;

    //done for one turret
    //private void Start()
    //{
    //    //change later when doing different turrets
    //    turretToBuild = standardTurret;
    //}

    private TurretBlueprint turretToBuild;

    //public GameObject GetTurretToBuild()
    //{
    //    return turretToBuild;
    //}

    //public void SetTurretToBuild(GameObject turret)
    //{
    //    turretToBuild = turret;
    //}

    //property, as we only allow it to get something as it can never be set. basically we are writing a small function, that returns the result.
    public bool CanBuild {  get { return turretToBuild != null; } } 

    public void SelectTurretToBuild (TurretBlueprint turret)
    {
        turretToBuild = turret;
    }

    public void BuildTurretOn (Node node)
    {
        if (PlayerStats.Money < turretToBuild.cost)
        {
            return;
        }
        if (PlayerStats.Money >= turretToBuild.cost)
        {
            Debug.Log("build");
            PlayerStats.Money -= turretToBuild.cost;

            GameObject turret = (GameObject)Instantiate(turretToBuild.prefab, (node.transform.position + node.offset), Quaternion.identity);
            node.turret = turret;
        }
    }

}
