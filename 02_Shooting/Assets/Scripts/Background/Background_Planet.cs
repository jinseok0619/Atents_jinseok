using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background_Planet : MonoBehaviour
{
    public float moveSpeed = 10.0f;
    public float minRightEnd = 40.0f;
    public float maxRighrEnd = 60.0f;
    public float minHeight = -8.0f;
    public float maxHeight = -5.0f;

    const float movePositionX = -10.0f;

    private void Update()
    {
        // 이 오브젝트는 왼쪽으로 매 초 moveSpeed만큼 이동한다
        transform.Translate(moveSpeed * Time.deltaTime * -transform.right);

        // 이 오브젝트는 movePositionX보다 왼쪽으로 이동하면 오른쪽 끝으로 이동한다
        if( transform.position.x < movePositionX)
        {
            // 오른쪽 끝의 위치는 minRight ~ maxRightEnd 사이를 랜덤으로 결정한다.
            transform.Translate(transform.right *  Random.Range(minRightEnd, maxRighrEnd));

            //// 높이도 minHeight ~ maxHeight로 조정한다.
            //Vector3 newPos = transform.position;
            //newPos.y = Random.Range(minHeight, maxHeight);
            //transform.position = newPos;

            Vector3 newPos2 = new Vector3(
                transform.position.x + Random.Range(minHeight, maxHeight),  // x 위치랜덤
                Random.Range(minHeight, maxHeight), 0.0f);      // y 위치랜덤
            transform.position = newPos2;
        }

    }
}
