using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    //singleton pattern done here; search for more around this to get a better understanding

    public static BuildManager instance; //this stores a buildmanager in the buildmanager //other scipts
    Shop shop;

    public NodeUI nodeUI;

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
    public GameObject bossTurret2;
    public GameObject bossTurret3;

    private TurretBlueprint turretToBuild;
    private Node selectedNode;

    //property, as we only allow it to get something as it can never be set. basically we are writing a small function, that returns the result.
    public bool CanBuild {  get { return turretToBuild != null; } } 

    public void SelectTurretToBuild (TurretBlueprint turret)
    {
        turretToBuild = turret;
        DeselectNode();
    }

    public void SelectNode(Node node)
    {
        if (selectedNode == node)
        {
            DeselectNode();
            return;
        }

        selectedNode = node;
        turretToBuild = null;

        nodeUI.SetTarget(selectedNode);
    }

    public void DeselectNode()
    {
        selectedNode = null;
        nodeUI.Hide();
    }

    public TurretBlueprint GetTurretToBuild()
    {
        return turretToBuild;
    }

}
