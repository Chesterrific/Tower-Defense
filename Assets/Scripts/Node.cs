using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour {

    public Color hoverColor;
    public Color notEnoughMoneyColor;
    public Vector3 positionOffset;

    [Header("Optional")]
    public GameObject turret; //can place turret on any node

    private Renderer rend; //changes object color based on hoverColor
    private Color startColor;

    BuildManager buildManager;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        buildManager = BuildManager.instance;
    }

    /*
     * Detects mouse over object and calls function
     */
    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (!buildManager.CanBuild) //checks if turretToBuild has been initialized.
            return;

        if (buildManager.HasMoney)
        {
            rend.material.color = hoverColor;
        }
        else
        {
            rend.material.color = notEnoughMoneyColor;
        }
    }

    /*
     * Detects mouse leaving object area and calls function
     */
    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }

    /*
     * On click of object
     */
    private void OnMouseDown()
    {
        //Checks if mouse is hovering over something else like the shop and disables clicking
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        //checks if turretToBuild has been initialized.
        if (!buildManager.CanBuild)
            return;

        //Checks if turret is present on node
        if(turret != null)
        {
            Debug.Log("Can't build here!");
            return;
        }

        buildManager.BuildTurretOn(this); //calls buildManager function to build turret on node
    }
    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }
}
