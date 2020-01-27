using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    #region Singleton

    private static Paddle _instance;

    public static Paddle Instance => _instance;

    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    #endregion

    private Camera mainCamera;
    private float paddleinitialY;
    private float deflautPaddleWidthPixels = 200;
    private float deflautLeftClamp = 135;
    private float deflautRightClamp = 410;
    private SpriteRenderer sr;

    private void Start()
    {
        mainCamera = FindObjectOfType<Camera>();
        paddleinitialY = this.transform.position.y;
        sr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        PaddleMovement();
    }

    private void PaddleMovement()
    {
        float paddleShift = (deflautPaddleWidthPixels - ((deflautPaddleWidthPixels / 2) * this.sr.size.x)) / 2;
        float leftClamp = deflautLeftClamp - paddleShift;
        float rightClamp = deflautRightClamp + paddleShift;
        float mousePositionPixels = Mathf.Clamp(Input.mousePosition.x, leftClamp, rightClamp);
        float mousePositionWorldX = mainCamera.ScreenToWorldPoint(new Vector3(mousePositionPixels, 0, 0)).x; 
        this.transform.position = new Vector3(mousePositionWorldX, paddleinitialY, 0);
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {

        if (coll.gameObject.tag == "Ball")
        {
            Rigidbody2D ballRb = coll.gameObject.GetComponent<Rigidbody2D>();
            Vector3 hitPoint = coll.contacts[0].point;
            Vector3 paddleCenter = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y);


            ballRb.velocity = Vector2.zero;

            float difference = paddleCenter.x - hitPoint.x;

            if (hitPoint.x < paddleCenter.x)

            {
                ballRb.AddForce(new Vector2(-(Mathf.Abs(difference * 200)), BallsMenager.Instance.initialBallSpeed));

            }
            else
            {
                ballRb.AddForce(new Vector2((Mathf.Abs(difference * 200)), BallsMenager.Instance.initialBallSpeed));
            }
        }

    }
}
