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

    //Players
    public GameObject Player1;
    public GameObject Player2;
    public GameObject Player3;
    public GameObject Player4;

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
}
