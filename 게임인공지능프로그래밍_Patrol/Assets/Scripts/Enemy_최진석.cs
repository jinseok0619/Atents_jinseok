using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEditor;
using static Unity.VisualScripting.Metadata;

public class Enemy_최진석 : MonoBehaviour
{
    public float sightRange = 10.0f;        // 시야범위(반경 10안에 있으면 본다)

    Transform[] waypoints;                  // 이 적이 순찰할 지점들
    int index = 0;                          // 순찰할 지점의 인덱스
    Transform target;                       // 추적할 대상

    NavMeshAgent agent;                     // NavMeshAgent 컴포넌트
    SphereCollider sphereCollider;          // 구의 컬라이더 컴포넌트(트리거)

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();               // 컴포넌트 찾기
        sphereCollider = GetComponent<SphereCollider>();

    }

    private void Start()
    {
        sphereCollider.radius = sightRange;                     // 트리거의 크기를 시야범위만큼 확장

        Transform way = GameObject.Find("Waypoints").transform; // Waypoints 찾아서

        waypoints = new Transform[way.childCount];              // 자식 크기만큼 배열 만들고
        for(int i = 0; i < way.childCount; i++)
        {
            waypoints[i] = way.GetChild(i);                     // 자식들을 하나하나 찾아서 저장
        }

        agent.SetDestination(waypoints[index].position);        // 첫번째 지점으로 이동하게 하는 코드
    }

    private void OnDrawGizmos()
    {
        Handles.DrawWireDisc(transform.position, transform.up, sightRange); // 시야 범위를 디스크로 표현
    }

    private void Update()
    {
        if(target != null)      // target이 null이 아니면 추적 대상이 있는것으로 간주
        {
            agent.SetDestination(target.position);      // 추적 대상을 계속 추적하기 
        }
        else if( !agent.pathPending                                 // 경로 계산 중이 아니다
            && agent.remainingDistance <= agent.stoppingDistance)   // 그리고 남아있는 거리가 stoppingDistance보다 적다.
        {
            GoNext();   // 다음 웨이포인트로 이동하라.
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // 플레이어가 트리거 안에 들어왔을 때
        {
            target = other.transform;   // 플레이어를 추적 대상으로 선정
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) // 플레이어가 트리거를 나갔을 때
        {
            target = null;              // 추적 대상을 해제하고
            ReturnPatrol();             // 패트롤 상태로 돌아가기
        }
    }

    void GoNext()
    {
        index++;                        // 인덱스 증가 시키기
        index %= waypoints.Length;      // 인덱스 범위가 배열 크기를 넘어서지 않도록 반복시키기
        agent.SetDestination(waypoints[index].position);    // 인덱스 가 가리키는 위치로 이동하기
    }

    void ReturnPatrol()
    {
        agent.SetDestination(waypoints[index].position);    // 이전 인덱스 지점으로 이동하기
    }
}
