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

    bool currentlyWaiting = false;

    public void SetTarget(Node node)
    {
        target = node;

        transform.position = target.GetBuildPosition();

        upgrade = target.currentBlueprint.upgradeCost;
        upgradeText.text = ("UPGRADE" + "\n" + "-" + upgrade);
        
        if(currentlyWaiting == false)
        {
            ui.SetActive(true);
        }

        StopAllCoroutines();
        WaitingUpgrade();
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

    IEnumerator WaitingUpgrade()
    {
        Debug.Log("Waiting");

        currentlyWaiting = true;

        yield return new WaitForSeconds(2);

        currentlyWaiting = false;

        Debug.Log("No longer waiting");
    }
}