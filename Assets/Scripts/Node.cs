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

    [Header("Optional")]
    //info we want the node to know
    public GameObject turret;

    //making an offset for building
    public Vector3 offset;

    BuildManager buildManager;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;

        buildManager = BuildManager.instance;
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

        buildManager.BuildTurretOn(this);

        ////otherwise build a turret
        //GameObject turretToBuild = buildManager.GetTurretToBuild();
        //turret = (GameObject)Instantiate(turretToBuild, node.position + offset, transform.rotation);
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
