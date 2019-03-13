using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private Vector3 positionOffSet = new Vector3(0,1000,0);
    public GameObject enemy;
    void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            Instantiate(enemy, transform.position + positionOffSet, transform.rotation);
           
    }
    }


        }
