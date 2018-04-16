using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour {

    public Color hoverColor;
    public Color notEnoughMoneyColor;
    public Vector3 positionOffset;

    [Header("Optional")]
    public GameObject turret; //can place turret on any node

    [HideInInspector]
    public TurretBlueprint turretBlueprint;

    [HideInInspector]
    public bool isUpgraded = false;

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
     * Detects mouse leaving object area and calls function.
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
        //Checks if mouse is hovering over something else like the shop and disables clicking.
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        //Checks if turret is present on node, select node.
        if(turret != null)
        {
            buildManager.SelectNode(this);
            return;
        }

        //checks if turretToBuild has been initialized.
        if (!buildManager.CanBuild)
        {
            return;
        }
            
        BuildTurret(buildManager.GetTurretToBuild()); //calls buildManager function to build turret on node.
    }

    //Instantiates turret on node passed in.
    void BuildTurret(TurretBlueprint blueprint)
    {
        if (PlayerStats.Money < blueprint.cost)
        {
            Debug.Log("Not enough money.");
            return;
        }

        PlayerStats.Money -= blueprint.cost;

        GameObject t = (GameObject)Instantiate(blueprint.prefab, GetBuildPosition(), Quaternion.identity);
        turret = t;

        turretBlueprint = blueprint;

        GameObject effect = (GameObject)Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);
    }

    public void UpgradeTurret()
    {
        if (PlayerStats.Money < turretBlueprint.upgradeCost)
        {
            Debug.Log("Not enough money to upgrade.");
            return;
        }

        PlayerStats.Money -= turretBlueprint.upgradeCost;

        //get rid of old turret
        Destroy(turret); 

        //builds upgraded turret
        GameObject t = (GameObject)Instantiate(turretBlueprint.upgradedPrefab, GetBuildPosition(), Quaternion.identity);
        turret = t;

        //plays buildEffect
        GameObject effect = (GameObject)Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);

        isUpgraded = true;
    }

    public void SellTurret()
    {
        PlayerStats.Money += turretBlueprint.GetSellAmount();

        //plays sellEffect
        GameObject effect = (GameObject)Instantiate(buildManager.sellEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);

        Destroy(turret);
        turretBlueprint = null;
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }
}
