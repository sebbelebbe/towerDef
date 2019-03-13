using UnityEngine.AI;
using UnityEngine;

public class PlayerController : MonoBehaviour{
    public NavMeshAgent agent;
    
    // Start is called before the first frame update
    void Start()
    {
        GameObject endPoint = GameObject.FindGameObjectWithTag("endPoint");
        agent.SetDestination(endPoint.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}



