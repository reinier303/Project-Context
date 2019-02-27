using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    private ScoreManager scoreManager;
    private GameManager gameManager;

    public void Start()
    {
        scoreManager = ScoreManager.Instance;
        gameManager = GameManager.Instance;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Goal1")
        {
            print(1);
            scoreManager.AddScore(1);
            gameManager.ResetBall();
        }
        if (other.tag == "Goal2")
        {
            print(2);
            scoreManager.AddScore(2);
            gameManager.ResetBall();
        }
    }
}
