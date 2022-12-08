using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class Airplane_최진석 : MonoBehaviour
{
    public float rotateSpeed = 720.0f;
    public float moveSpeed = 5.0f;
    //public float angle = 50.0f;

    Transform[] waypoints;
    Transform propeller;
    //Transform target;
    //Transform airplane;
    int targetIndex = 0;

    private void Awake()
    {
        waypoints = new Transform[2];
        waypoints[0] = GameObject.Find("Waypoint1").transform;
        waypoints[1] = GameObject.Find("Waypoint2").transform;
        propeller = GameObject.Find("Propeller").transform;
        //propeller = transform.GetChild(4);
        //airplane = transform.GetChild(0);

    }

    private void Start()
    {
        transform.LookAt(waypoints[targetIndex]);
        //transform.position = waypoints[targetIndex].transform.position;

    }

    private void Update()
    {
        //GoNextWaypoint();
        transform.Translate(moveSpeed * Time.deltaTime * transform.forward, Space.World);   // 무조건 앞으로 이동
        propeller.Rotate(0,0,rotateSpeed * Time.deltaTime);                                 // 프로펠러 회전시키기

        if ((transform.position - waypoints[targetIndex].position).sqrMagnitude < 0.25f) // 도착점 까지의 거리 확인(근접했는지 확인)
        {
            GoNextWaypoint();
        }
    }

    private void FixedUpdate()
    {
        //propeller.transform.Rotate(0,0,angle);
        //// 타겟 방향으로 회전함
        //transform.LookAt(transform);
    }

    void GoNextWaypoint()
    {
        targetIndex++;
        targetIndex %= waypoints.Length;

        transform.LookAt(waypoints[targetIndex].position);
        //transform.position = Vector2.MoveTowards
        //    (transform.position, waypoints[targetIndex].transform.position, moveSpeed * Time.deltaTime);
        //if (transform.position == waypoints[targetIndex].transform.position)
        //    targetIndex++;
        //if(targetIndex == waypoints.Length)
        //    targetIndex = 0;
    }


}
