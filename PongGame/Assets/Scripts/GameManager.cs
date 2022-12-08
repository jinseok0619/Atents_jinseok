using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Ball")]
    public GameObject Ball;

    [Header("Player 1")]
    public GameObject Player1Paddle;
    public GameObject Player1Goal;

    [Header("Player 2")]
    public GameObject Player2Paddle;
    public GameObject Player2Goal;

    [Header("Score UI")]
    public GameObject Player1Text;
    public GameObject Player2Text;

    private int player1score;
    private int player2score;

    private void Resetposition()
    {
        Ball.GetComponent<Ball>().Reset();
    }

    public void Player1Scored()
    {
        player1score++;
        Player1Text.GetComponent<TextMeshProUGUI>().text = player1score.ToString();
        Resetposition();
    }

    public void Player2Scored()
    {
        player2score++;
        Player2Text.GetComponent<TextMeshProUGUI>().text = player2score.ToString();
        Resetposition();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }
}
