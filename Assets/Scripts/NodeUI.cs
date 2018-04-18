using UnityEngine.UI;
using UnityEngine;

public class NodeUI : MonoBehaviour {

    private Node target;

    public GameObject ui;
    public Text upgradeCost;
    public Text sellAmount;
    public Button upgradeButton;

	public void SetTarget(Node t)
    {
        target = t;
        //Displays options menu above turret
        transform.position = target.GetBuildPosition();

        sellAmount.text = "$" + target.turretBlueprint.GetSellAmount();

        if (!target.isUpgraded)
        {
            upgradeCost.text = "$" + target.turretBlueprint.upgradeCost;
            upgradeButton.interactable = true;
        }
        else
        {
            upgradeCost.text = "DONE";
            upgradeButton.interactable = false;
        }

        ui.SetActive(true);
    }

    //Hides options menu
    public void Hide()
    {
        ui.SetActive(false);
    }

    public void Upgrade()
    {
        target.UpgradeTurret();
        BuildManager.instance.DeselectNode();
    }

    public void Sell()
    {
        target.SellTurret();
        BuildManager.instance.DeselectNode();
    }
}
