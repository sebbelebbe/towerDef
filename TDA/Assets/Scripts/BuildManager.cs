
using UnityEngine;

public class BuildManager : MonoBehaviour{

    public static BuildManager instance;

    void Awake()
    {
        if (instance != null) {
            Debug.LogError("Error");
            return;
        } 
        instance = this;
    }

    public GameObject standartTurretPrefab;
    public GameObject missileLauncherPrefab;



    private TurretBlueprint turretToBuild;
    private Node selectedNode;
    public NodeUI nodeUI;

    public bool CanBuild { get { return turretToBuild != null; } }
    public bool hasMoney { get { return PlayerStats.Money >= turretToBuild.cost; } }

    public void SelectTurretToBuild(TurretBlueprint turret)
    {


        turretToBuild = turret;
        selectedNode = null;
        nodeUI.Hide();
    }

    public void DeSelectNode() {
        selectedNode = null;
        nodeUI.Hide();
    }

    public void SelectNode(Node node) {

        if (selectedNode == node)
        {
            DeSelectNode();
            return;
        }
        selectedNode = node;
        turretToBuild = null;

        nodeUI.SetTartget(node);
    }

    public TurretBlueprint GetTurretToBuild() {
        return turretToBuild;

    }


}
