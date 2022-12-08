using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints01 : MonoBehaviour
{
    Transform[] waypoint;
    int index = 0;

    public Transform CurrentWaypoint { get => waypoint[index]; }

    private void Awake()
    {
        waypoint = new Transform[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            waypoint[i] = transform.GetChild(i);
        }
    }

    public Transform MoveToNextWaypoint()
    {
        index++;
        index %= waypoint.Length;
        return waypoint[index];
    }
}
