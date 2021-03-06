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
            Debug.Log("not waiting");
        }
        else
        {
            currentlyWaiting = false;
            Debug.Log("waiting");
        }



        if (currentlyWaiting == false)
        {
            ui.SetActive(true);
        }
    }

    public void Hide()
    {
        ui.SetActive(false);
    }

    //hook up to uprgade
    public void Upgrade()
    {
        target.UpgradeTurret();

        StopAllCoroutines();
        StartCoroutine(UpgradeWait());
    }

    //hook up to sell
    public void Sell()
    {
        target.SellTurret();

        StopAllCoroutines();
        StartCoroutine(UpgradeWait());
    }

    IEnumerator UpgradeWait()
    {
        yield return new WaitForSeconds(1f);

        BuildManager.instance.DeselectNode();
    }
}