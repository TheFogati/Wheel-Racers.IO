using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Wheels
{
    public string name;
    public GameObject model;
    public int price;
    public bool isUnlocked;
    public bool selected;
}

[System.Serializable]
public class Trails
{
    public string name;
    public GameObject model;
    public int price;
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
    public Wheels[] wheels;
    public Trails[] trails;
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
