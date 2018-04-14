using UnityEngine;

public class BuildManager : MonoBehaviour {

    //Singleton to make sure there's only one manager.
    public static BuildManager instance;

    public GameObject buildEffect;

    //Turret to be built held by this variable.
    private TurretBlueprint turretToBuild;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one BuildManager in scene!");
            return;
        }
        instance = this; //Build manager is set to itself, allowing us to access same build manager everywhere.
    }

    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;
    }

    public bool CanBuild {get { return turretToBuild != null; } } //Property that returns true if turretToBuild is not null.
    public bool HasMoney { get { return PlayerStats.Money >= turretToBuild.cost; } }

    //Instantiates turret on node passed in.
    public void BuildTurretOn(Node node)
    {
        if(PlayerStats.Money < turretToBuild.cost)
        {
            Debug.Log("Not enough money.");
            return;
        }

        PlayerStats.Money -= turretToBuild.cost;

        GameObject turret = (GameObject)Instantiate(turretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
        node.turret = turret;

        GameObject effect = (GameObject)Instantiate(buildEffect, node.GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);

        Debug.Log("Money left: " + PlayerStats.Money);
    }
}
