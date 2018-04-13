using UnityEngine;

public class BuildManager : MonoBehaviour {

    //Singleton to make sure there's only one manager.
    public static BuildManager instance;
     
    //Turrets available in shop.
    public GameObject standardTurretPrefab;
    public GameObject missileTurretPrefab;

    private GameObject turretToBuild;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one BuildManager in scene!");
            return;
        }
        instance = this; //Build manager is set to itself, allowing us to access same build manager everywhere.
    }

    public void SetTurretToBuild(GameObject turret)
    {
        turretToBuild = turret;
    }

    public GameObject GetTurretToBuild()
    {
        return turretToBuild;
    }
	
}
