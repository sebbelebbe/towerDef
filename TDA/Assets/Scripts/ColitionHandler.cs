using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColitionHandler : MonoBehaviour
{
    void OnCollisionEnter(Collision col)
    {

          
            Destroy(col.gameObject);
        
    }


}
