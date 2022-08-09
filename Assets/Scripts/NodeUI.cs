using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class NodeUI : MonoBehaviour
{
    public GameObject ui;
    public Text upgradeText;

    private Node target;

    private int upgrade;

    [SerializeField]
    bool currentlyWaiting = false;

    public void FixedUpdate()
    {
        
    }

    public void SetTarget(Node node)
    {
        target = node;

        transform.position = target.GetBuildPosition();

        upgrade = target.currentBlueprint.upgradeCost;
        upgradeText.text = ("UPGRADE" + "\n" + "-" + upgrade);

        if (ui.gameObject.activeSelf == true)
        {
            currentlyWaiting = true;
            //Debug.Log("not waiting");
        }
        else
        {
            currentlyWaiting = false;
            //Debug.Log("waiting");
        }



        if (currentlyWaiting == false)
        {
            ui.SetActive(true);
            ui.transform.Translate(0f, 6f, 0f);
        }
    }

    public void Hide()
    {
        ui.SetActive(false);
        ui.transform.Translate(0f, -6f, 0f);
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

    IEnumerator UpgradeWait()
    {
        yield return new WaitForSeconds(.02f);

        BuildManager.instance.DeselectNode();
    }
}