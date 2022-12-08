using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    private void Start()
    {
        GameManager.Inst.onGameStart += onGameStart;    // 시작할 때 실행될 델리게이트 연결
        gameObject.SetActive(false);                    // 이 게임 오브젝트 끄기
    }

    private void onGameStart()
    {
        gameObject.SetActive(true);                     // 게임이 시작될 때 이 게임 오브젝트 켜기
    }
}
