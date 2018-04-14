using UnityEngine;

public class Shop : MonoBehaviour {
    
    //items available in shop
    public TurretBlueprint standardTurret;
    public TurretBlueprint missileTurret;

    BuildManager buildManager;

    //stores singleton buildmanager instance into buildManager for use
    private void Start()
    {
        buildManager = BuildManager.instance;
    }

    //selects standard turret and returns it to buildmanager
    public void SelectStandardTurret()
    {
        buildManager.SelectTurretToBuild(standardTurret);
    }

    //selects missile turret and returns it to buildmanager
    public void SelectMissileTurret()
    {
        buildManager.SelectTurretToBuild(missileTurret);
    }
}
