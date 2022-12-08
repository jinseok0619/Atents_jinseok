using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEditor;

public class Enemy_이름 : MonoBehaviour
{
    public float sightRange = 10.0f;
        
    Transform[] waypoints;
    int index = 0;
    Transform target;

    NavMeshAgent agent;
    SphereCollider sphereCollider;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        sphereCollider = GetComponent<SphereCollider>();        
    }

    private void Start()
    {
        sphereCollider.radius = sightRange;

        Transform way = GameObject.Find("Waypoints").transform;
        
        waypoints = new Transform[way.childCount];
        for(int i = 0; i < way.childCount; i++)
        {
            waypoints[i] = way.GetChild(i);
        }

        agent.SetDestination(waypoints[index].position);
    }

    private void OnDrawGizmos()
    {
        Handles.DrawWireDisc(transform.position, transform.up, sightRange);
    }

    private void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }

    private void OnTriggerExit(Collider other)
    {
        
    }

    void GoNext()
    {
        
    }

    void ReturnPatrol()
    {
        
    }
}
