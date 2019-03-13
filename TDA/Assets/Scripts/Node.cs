using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Node : MonoBehaviour {
    public Color hoverColor;
    public Vector3 positionOffSet;
    [HideInInspector]
    public GameObject turret;
    [HideInInspector]
    public TurretBlueprint turretBlueprint;
    [HideInInspector]
    public bool isUpgraded = false;


    private Renderer rend;
    private Color startColor;

    BuildManager buildManager;


    void Start() {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        buildManager = BuildManager.instance;


    }

    public Vector3 getBuildPosition() {
        return transform.position + positionOffSet;
    }

    void OnMouseDown()
    {


        if (turret != null) {
            buildManager.SelectNode(this);
            return;
        }

        if (!buildManager.CanBuild) return;
        BuildTurret(buildManager.GetTurretToBuild());

    }

    void BuildTurret(TurretBlueprint blueprint) {

        if (PlayerStats.Money < blueprint.cost)
        {
            return;
        }

        PlayerStats.Money -= blueprint.cost;

        GameObject _turret = (GameObject)Instantiate(blueprint.prefab, getBuildPosition(), Quaternion.identity);
        turret = _turret;

        turretBlueprint = blueprint;

    }

    public void Upgrade() {
        if (PlayerStats.Money < turretBlueprint.upgradeCost)
        {
            return;
        }

        PlayerStats.Money -= turretBlueprint.upgradeCost;

        Destroy(turret);


        GameObject _turret = (GameObject)Instantiate(turretBlueprint.upgradedPrefab, getBuildPosition(), Quaternion.identity);
        turret = _turret;
        

        isUpgraded = true;
    }

    public void SellTurret () {
        PlayerStats.Money += 50;
        Destroy(turret);
    }


    void OnMouseEnter()
    {
        if (!buildManager.CanBuild) return;
        if (buildManager.hasMoney)
        {
            rend.material.color = hoverColor;
        }

        else {
            rend.material.color = Color.red;
        }
        
            
    }
    void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}

