using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallsMenager : MonoBehaviour
{
    #region Singleton

    private static BallsMenager _instance;

    public static BallsMenager Instance => _instance;

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

    [SerializeField]
    private Ball ballPrefab;

    private Ball initialBall;

    private Rigidbody2D initialBallRb;

    public List<Ball> Balls { get; set; }

    private void Start()
    {
        InitBall();
    }
    private void Update()
    {
        if (!GameMenager.Instance.IsGameStarted)
        {
            // Align ball position to the paddle position
            Vector3 paddlePosition = Paddle.Instance.gameObject.transform.position;
        }
    }

    private void InitBall()
    {
        Vector3 paddlePosition = Paddle.Instance.gameObject.transform.position;
        Vector3 startingPosition = new Vector3(paddlePosition.x, paddlePosition.y + .27f, 0);
        initialBall = Instantiate(ballPrefab, startingPosition, Quaternion.identity);
        initialBallRb = initialBall.GetComponent<Rigidbody2D>();

        this.Balls = new List<Ball>
        {
initialBall
        };
    }
} 
