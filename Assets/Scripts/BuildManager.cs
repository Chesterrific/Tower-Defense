using UnityEngine;

public class BuildManager : MonoBehaviour {

    //Singleton to make sure there's only one manager.
    public static BuildManager instance;

    public GameObject sellEffect;
    public GameObject buildEffect;
    public NodeUI nodeUI;

    //Turret to be built held by this variable.
    private TurretBlueprint turretToBuild;
    private Node selectedNode;

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

        DeselectNode();
    }

    public void SelectNode(Node node)
    {
        if(selectedNode == node)
        {
            DeselectNode();
            return;
        }

        selectedNode = node;
        turretToBuild = null;

        nodeUI.SetTarget(node);
    }

    public void DeselectNode()
    {
        selectedNode = null;
        nodeUI.Hide();
    }

    public bool CanBuild {get { return turretToBuild != null; } } //Property that returns true if turretToBuild is not null.
    public bool HasMoney { get { return PlayerStats.Money >= turretToBuild.cost; } }

    public TurretBlueprint GetTurretToBuild()
    {
        return turretToBuild;
    }
}
