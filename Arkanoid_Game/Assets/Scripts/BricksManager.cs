using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BricksMenager : MonoBehaviour
{
    #region Singleton

    private static BricksMenager _instance;

    public static BricksMenager Instance => _instance;

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

    public Sprite[] Sprites;

}


 