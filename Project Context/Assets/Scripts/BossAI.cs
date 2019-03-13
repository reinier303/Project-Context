using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAI : MonoBehaviour
{
    private GameManager gameManager;

    private GameObject ball;

    private Rigidbody ballRb;

    public float RotationDamping = 1;

    public float Speed = 10;

    public float ShotForce = 5;

    private void Start()
    {
        gameManager = GameManager.Instance;
        ball = gameManager.Ball;
        ballRb = ball.GetComponent<Rigidbody>();
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, ball.transform.position, Speed * 0.01f);
        Rotate();
    }

    void Rotate()
    {
        var lookPos = ball.transform.position - transform.position;
        lookPos.y = 0;
        var rotation = Quaternion.LookRotation(lookPos);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * RotationDamping);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "BallTrigger")
        {
            Shoot();
        }
    }

    void Shoot()
    {
        Vector3 direction = new Vector3(transform.forward.x + Random.Range(-0.8f, 0.8f), transform.forward.y, transform.forward.z + Random.Range(-0.8f, 0.8f));
        ballRb.AddForce(direction * ShotForce);
    }
}
