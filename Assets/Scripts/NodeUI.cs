using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NodeUI : MonoBehaviour
{
    public GameObject ui;
    public Text upgradeText;

    private Node target;

    private int upgrade;

    public void SetTarget(Node node)
    {
        target = node;

        transform.position = target.GetBuildPosition();

        //upgrade = target.GetComponent<TurretBlueprint>().upgradeCost;
        //upgradeText.text = ("Upgrade" + "/n" + "-" + upgrade);

        ui.SetActive(true);

    }

    public void Hide()
    {
        ui.SetActive(false);
    }

    //hook up to uprgade
    public void Upgrade()
    {
        target.UpgradeTurret();
        BuildManager.instance.DeselectNode();
    }

    //hook up to sell
    public void Sell()
    {
        target.SellTurret();
        BuildManager.instance.DeselectNode();
    }
}