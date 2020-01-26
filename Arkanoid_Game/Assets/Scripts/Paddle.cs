using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
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
}
