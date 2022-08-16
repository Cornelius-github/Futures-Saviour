using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

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

    public int UpgradingIncrease = 5;
    public float statUpgrades = 0.4f;

    BuildManager buildManager;
    Shop shop;

    public Text nodeUI;

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

            GameObject _turret = (GameObject)Instantiate(blueprint.prefab, (transform.position), Quaternion.identity);
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

        //consistent upgrades but a random range value
        statUpgrades = (Random.Range(((float)(0.1)), (float)0.7));
        turret.GetComponent<Turrett>().fireRate += statUpgrades;

        statUpgrades = (Random.Range(((float)(0.1)), (float)0.7));
        turret.GetComponent<Turrett>().range += statUpgrades;

        statUpgrades = (Random.Range(((float)(0.1)), (float)0.7));
        turret.GetComponent<Turrett>().bulletPrefab.GetComponent<Bullet>().damage += statUpgrades;

        //currentBlueprint = blueprint;

        ////whenever upgrading is done
        //isUpgraded = true;

        //turret has been upgraded
        currentBlueprint.upgradeCost += UpgradingIncrease;

        UpgradingIncrease += 5;

        //nodeUI.text = ("UPGRADE" + "\n" + "-" + currentBlueprint.upgradeCost);
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
