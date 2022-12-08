using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

// 수직 또는 슈평으로만 움직일 것, 대각선은 밀리는 현상 발생

public class Platform : MonoBehaviour
{
    public Transform destination;   // 도착위치 destination.position
    public float moveSpeed = 1.0f;

    public Action<Vector3> onMove;

    protected bool isMoving = false;

    private Rigidbody rigid;    //현재위치  rigid.position

    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isMoving = true;
        }
    }

    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.CompareTag("Player"))
    //    {
    //        playerIn = false;
    //    }
    //}

    private void FixedUpdate()
    {
        if (isMoving)
        {
            // 이번 fixedUpdate때 움직일 벡터 구하기
            Vector3 moveDelta = moveSpeed * Time.fixedDeltaTime * (destination.position - rigid.position).normalized;
            // 새로운 위치 구하기
            Vector3 newPos = rigid.position + moveDelta;

            // 새로운 위치가 도착지점에 거의 근접하면
            if ( (destination.position - newPos).sqrMagnitude < 0.0025f )
            {
                // 도착했다고 처리
                isMoving = false;
                newPos = destination.position;
                moveDelta = Vector3.zero;
            }

            // 위치 최종 결정
            rigid.MovePosition(newPos);
            onMove?.Invoke(moveDelta);
        }
    }
}
