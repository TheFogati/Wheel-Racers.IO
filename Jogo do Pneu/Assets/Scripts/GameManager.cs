using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SimpleWheels
{
    public string name;
    public GameObject model;
    public bool isUnlocked;
    public bool selected;
}

[System.Serializable]
public class SimpleTrails
{
    public string name;
    public GameObject model;
    public bool isUnlocked;
    public bool selected;
}

[System.Serializable]
public class EpicWheels
{
    public string name;
    public GameObject model;
    public bool isUnlocked;
    public bool selected;
}

[System.Serializable]
public class EpicTrails
{
    public string name;
    public GameObject model;
    public bool isUnlocked;
    public bool selected;
}

public class GameManager : MonoBehaviour
{
    //Ads
    public int runs = 0;
    //Ads

    public bool gamePaused;
    [Space]
    public SimpleWheels[] simpleWheels;
    public EpicWheels[] epicWheels;
    public SimpleTrails[] simpleTrails;
    public EpicTrails[] epicTrails;
    [Space]
    public int money;

    #region Don't Destroy
    public static GameManager manager;
    void Awake()
    {
        if (!manager)
            manager = this;
        else if (manager)
            Destroy(gameObject);

        DontDestroyOnLoad(this);
    }
    #endregion
}
