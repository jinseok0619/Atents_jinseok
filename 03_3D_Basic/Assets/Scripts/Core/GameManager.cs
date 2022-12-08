using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public Action onGameStart;

    Player player;
    Timer timer;
    ResultPanel resultPanel;

    bool isGameStart = false;

    public Player Player { get => player; }
    public bool IsGameStart
    {
        get => isGameStart;
        private set
        {
            isGameStart = value;
            if (isGameStart)
            {
                onGameStart?.Invoke();
            }
        }
    }

    protected override void Initialize()
    {
        isGameStart = false ;

        player = FindObjectOfType<Player>();
        timer = FindObjectOfType<Timer>();
        resultPanel = FindObjectOfType<ResultPanel>();
        resultPanel?.gameObject.SetActive(false);   // resultPanel 이 널이 아니면 시작
    }

    public void GameStart()
    {
        if (!isGameStart)
        {
            IsGameStart = true;
        }
    }

    public void ShowResultPanel()
    {
        if (resultPanel != null)
        {
            resultPanel.ClearTime = timer.ResultTime;
            resultPanel?.gameObject.SetActive(true);
        }
    }
}
