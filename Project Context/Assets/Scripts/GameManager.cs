using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Singleton

    public static GameManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    #endregion

    //Controlls
    public bool controller = true;

    //Ball
    public GameObject Ball;
    public Rigidbody BallRigidbody;
    private Vector3 startPosition;

    public GameObject Boss;
    public GameObject Goal1;
    public GameObject Goal2;
    public GameObject Goal3;

    //Players
    public GameObject Player1;
    public GameObject Player2;
    public GameObject Player3;
    public GameObject Player4;

    public int PowerUpsCollected;

    private void Start()
    {
        startPosition = Ball.transform.position;
        BallRigidbody = Ball.GetComponent<Rigidbody>();
    }

    public void ResetBall()
    {
        BallRigidbody.isKinematic = true;
        BallRigidbody.isKinematic = false;
        Ball.transform.position = startPosition;
    }

    public void CheckForBossSpawn()
    {
        if(PowerUpsCollected >= 10)
        {
            SpawnBoss();
        }
    }

    public void SpawnBoss()
    {
        Boss.SetActive(true);
        Goal1.SetActive(false);
        Goal2.SetActive(false);
        Goal3.SetActive(true);
    }
}
