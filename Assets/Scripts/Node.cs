using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//building nodes
public class Node : MonoBehaviour
{
    public Color hoverColor; //color for when its hovered
    private Color startColor; //color that starts

    private Renderer rend;

    [HideInInspector]
    //info we want the node to know
    public GameObject turret;

    [HideInInspector]
    public TurretBlueprint currentBlueprint;

    [HideInInspector]
    public bool isUpgraded = false;

    //making an offset for building
    public Vector3 offset;

    public int UpgradingIncrease = 1;

    BuildManager buildManager;
    Shop shop;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;

        buildManager = BuildManager.instance;
        shop = Shop.instance;
    }

    private void OnMouseDown()
    {
        //called when pressed down on the mouse button whilst hovering
        if (turret != null)
        {
            buildManager.SelectNode(this);
            return;
        }

        if (!buildManager.CanBuild)
        {
            return;
        }

        BuildTurret(buildManager.GetTurretToBuild());
    }

    //moved building to node from buildmanager
    void BuildTurret(TurretBlueprint blueprint)
    {
        //if using count rather than currency to buy
        if (blueprint.amount <= 0)
        {
            return;
        }
        if (1 <= blueprint.amount)
        {
            blueprint.amount--;

            GameObject _turret = (GameObject)Instantiate(blueprint.prefab, (transform.position + offset), Quaternion.identity);
            turret = _turret;

            shop.InventoryCheck(blueprint);
        }
    }

    public void UpgradeTurret()
    {
        if (PlayerStats.Money < currentBlueprint.upgradeCost)
        {
            return;
        }

        PlayerStats.Money -= currentBlueprint.upgradeCost;

        //consistent upgrades
        turret.GetComponent<Turrett>().fireRate += UpgradingIncrease;
        turret.GetComponent<Turrett>().range += UpgradingIncrease;
        turret.GetComponent<Turrett>().bulletPrefab.GetComponent<Bullet>().damage += UpgradingIncrease;

        ////getting rid of old turret
        //Destroy(turret);
        ////building the new upgraded turret
        //GameObject _turret = (GameObject)Instantiate(currentBlueprint.upgradedPrefab, (transform.position + offset), Quaternion.identity);
        //turret = _turret;

        //currentBlueprint = blueprint;

        ////whenever upgrading is done
        //isUpgraded = true;

        //turret has been upgraded
        return;
    }

    public void SellTurret()
    {
        PlayerStats.Money += 20;

        //add an effect here, same as before but change the buildEffect to sellEffect

        Destroy(turret);
        currentBlueprint = null;
    }

    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (buildManager.CanBuild)
        {
            return;
        }

        //when the mouse enters the collider, it just calls once it doesnt flash
        rend.material.color = hoverColor;
    }

    private void OnMouseExit()
    {
        //when the mouse leaves
        rend.material.color = startColor;
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position;
    }
}
