using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public int rightScore;
    public int leftScore;
    public int maxScore;

    public BallController ball;
    public GameObject gameOver;
    public GameObject kanan;
    public GameObject kiri;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddRightScore(int increment)
    {
        rightScore += increment;
        ball.ResetBall();
        ball.rig.velocity = -ball.speed;
        if (rightScore >= maxScore)
        {
            GameOver();
        }
    }

    public void AddLeftScore(int increment)
    {
        leftScore += increment;
        ball.ResetBall();
        ball.rig.velocity = ball.speed;
        if (leftScore >= maxScore)
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        Time.timeScale = 0f;
        gameOver.SetActive(true);
        if (leftScore >= maxScore)
        {
            kanan.SetActive(true);
        } else if (rightScore >= maxScore)
        {
            kiri.SetActive(true);
        }
    }
}
