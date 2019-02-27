using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XInputDotNetPure;

public class PlayerMovement : MonoBehaviour
{
    private GameManager gameManager;

    public int PlayerNumber;

    private Rigidbody rb;

    //Changable Variables
    public float Speed = 20;

    public float ShotForce = 5;

    private bool InRange;

    public GamepadManager gamePadManager;

    private X360_Gamepad myGamepad;

    private bool controller;

    //Ball
    private GameObject ball;
    private Rigidbody ballRb;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        gamePadManager = GamepadManager.Instance;

        myGamepad = gamePadManager.GetGamepad(PlayerNumber);

        gameManager = GameManager.Instance;

        controller = gameManager.controller;

        ball = gameManager.Ball;
        ballRb = gameManager.BallRigidbody;

        InRange = false;
    }

    private void Update()
    {
        if (!controller)
        {
            //Movement
            if (Input.GetAxis("JoyHorizontal" + PlayerNumber) != 0 || Input.GetAxis("JoyVertical" + PlayerNumber) != 0)
            {
                Move();
            }

            //Shooting
            if (Input.GetButtonDown("B" + PlayerNumber))
            {
                if (InRange)
                {
                    Shoot();
                }
            }

            /*Optional Holding
            if (Input.GetButtonDown("A" + PlayerNumber))
            {
                if(InRange)
                {
                    Hold();
                }
            }

            if (Input.GetButtonUp("A" + PlayerNumber))
            {
                ReleaseHold();
            }
            */
        }
        else
        {
            //Movement
            if (myGamepad.GetStick_L().X != 0 || myGamepad.GetStick_L().Y != 0)
            {
                Move();
            }

            //Rotation
            if (myGamepad.GetStick_R().X != 0 || myGamepad.GetStick_R().Y != 0)
            {
                Rotate();
            }

            //Shooting
            if (myGamepad.GetTrigger_R() > 0)
            {
                if (InRange)
                {
                    Shoot();
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "BallTrigger")
        {
            InRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "BallTrigger")
        {
            InRange = false;
        }
    }

    void Hold()
    {
        ballRb.constraints = RigidbodyConstraints.FreezeAll;
        ball.transform.localPosition = new Vector3(rb.transform.forward.x , 0.6f , rb.transform.forward.z);
    }

    void ReleaseHold()
    {
        ballRb.constraints = RigidbodyConstraints.None;
    }

    void Rotate()
    {
        float angle = Mathf.Atan2(myGamepad.GetStick_R().X, myGamepad.GetStick_R().Y) * Mathf.Rad2Deg;
        float bodyRotation = angle + Camera.main.transform.eulerAngles.y;
        transform.rotation = Quaternion.Euler(0, bodyRotation, 0);
    }

    void Shoot()
    {
        ballRb.AddForce(transform.forward * ShotForce);
    }

    void Move()
    {
        if(!controller)
        {
            rb.AddRelativeForce(Input.GetAxis("JoyHorizontal" + PlayerNumber) * Speed, 0, Input.GetAxis("JoyVertical" + PlayerNumber) * Speed);
        }
        else
        {
            rb.AddForce(myGamepad.GetStick_L().X * Speed, 0, myGamepad.GetStick_L().Y * Speed);
        }
    }
}
