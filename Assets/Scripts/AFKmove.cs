using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AFKmove : MonoBehaviour
{    
    public Transform target;
    public string name_target;
    NavMeshAgent agent;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    void FixedUpdate()
    {
        target = GameObject.FindGameObjectWithTag(name_target).GetComponent<Transform>();
        agent.SetDestination(target.position);
    }
}


