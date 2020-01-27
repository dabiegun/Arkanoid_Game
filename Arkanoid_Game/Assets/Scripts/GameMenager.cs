using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMenager : MonoBehaviour
{
    #region Singleton

    private static GameMenager _instance;

    public static GameMenager Instance => _instance;

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

    public bool IsGameStarted { get; set; }
}