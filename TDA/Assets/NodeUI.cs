using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeUI : MonoBehaviour
{

    void Start()
    {
        Hide();    
    }


    public GameObject ui;
    private Node target;
    public void SetTartget(Node _target) {
        target = _target;
        transform.position = target.getBuildPosition();
        ui.SetActive(true);
    }

    public void Hide() {

        ui.SetActive(false);
    }

    public void Upgrade() {
        target.Upgrade();
        BuildManager.instance.DeSelectNode();

    }

    public void Sell() {
        target.SellTurret();
        BuildManager.instance.DeSelectNode();

    }
}
