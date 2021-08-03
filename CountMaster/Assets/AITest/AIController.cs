using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class AIController : MonoBehaviour
{
    // Agents destination
    public GameObject goal;

    // Get the prefab
    NavMeshAgent agent;


    // Start is called before the first frame update
    /*private void Start()
    {
        GetAgent();
       
    }*/

    public void GetAgent()
    {
        Debug.Log(2);
        agent = GetComponent<NavMeshAgent>();
        // Instruct the agent where it has to go
        agent.SetDestination(goal.transform.position);
     
    }
}