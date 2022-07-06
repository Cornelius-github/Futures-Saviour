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

    public void Update()
    {
        if (ui.gameObject.activeSelf == true)
        {
            currentlyWaiting = true;
        }
        else
        {
            currentlyWaiting = false;
        }
    }


    public void SetTarget(Node node)
    {
        target = node;

        transform.position = target.GetBuildPosition();

        upgrade = target.currentBlueprint.upgradeCost;
        upgradeText.text = ("UPGRADE" + "\n" + "-" + upgrade);

        if (currentlyWaiting == false)
        {
            ui.SetActive(true);
        }

        //if (EventSystem.current.IsPointerOverGameObject())
        //{
        //    return;
        //}
        //else
        //{
        //    ui.SetActive(true);
        //}
    }

    public void Hide()
    {
        ui.SetActive(false);

        //StopAllCoroutines();
        //StartCoroutine(WaitingUpgrade());
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

        yield return new WaitForSeconds(5f);

        currentlyWaiting = false;

        Debug.Log("No longer waiting");
    }
}