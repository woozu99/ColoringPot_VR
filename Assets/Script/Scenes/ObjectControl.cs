﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectControl : MonoBehaviour
{

    public GameObject brush;
    public GameObject brushPoint;
    public GameObject palette;
    public GameObject bakeDialog;

    public static ObjectControl instance;

    #region Singleton
    private void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(this.gameObject);
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    #endregion Singleton

    void Start()
    {
        if (SceneManager.GetActiveScene().name == "PotteryMoldingScene")
        {
            brush.transform.localScale = new Vector3(0, 0, 0);
            brushPoint.transform.localScale = new Vector3(0, 0, 0);
            palette.transform.localScale = new Vector3(0, 0, 0);
        }
    }

 
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "ColoringScene")
        {
            brush.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
            brushPoint.transform.localScale = new Vector3(0.005f, 0.005f, 0.005f);
            palette.transform.localScale = new Vector3(3, 3, 3);

            PotteryColoring pottery = GameObject.Find("ColoringPottery").GetComponent<PotteryColoring>();
            brushPoint.GetComponent<MovingSphere>().pottery = pottery;
            bakeDialog.GetComponent<BakeDialog>().pottery = pottery.GetComponent<MeshFilter>();
            pottery.brush = brushPoint.transform;
            Palette[] colors = palette.gameObject.GetComponentsInChildren<Palette>();
            foreach (Palette color in colors)
            {
                color.brush = brushPoint.transform;
                color.pottery = pottery;
            }
        }
        else
        {
            brush.transform.localScale = new Vector3(0, 0, 0);
            brushPoint.transform.localScale = new Vector3(0, 0, 0);
            palette.transform.localScale = new Vector3(0, 0, 0);
        }
    }
}