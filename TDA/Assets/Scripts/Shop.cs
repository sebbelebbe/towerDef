using UnityEngine;

public class Shop : MonoBehaviour{

    public TurretBlueprint standartTurret;

    public TurretBlueprint missileLauncher;


    BuildManager buildManager;

    void Start()
    {
        buildManager = BuildManager.instance;

    }
    public void SelectStandartTurret() {
        
        Debug.Log("Standart Turret");
        buildManager.SelectTurretToBuild(standartTurret);


    }

    public void SelectMissileLauncher()
    {
        
        Debug.Log("another Turret");
        buildManager.SelectTurretToBuild(missileLauncher);
    }
}
