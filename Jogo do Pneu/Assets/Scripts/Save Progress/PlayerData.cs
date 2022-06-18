using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int money;

    public bool[] unlockedWheels;
    public bool[] selectedWheel;
    public bool[] unlockedTrails;
    public bool[] selectedTrail;

    public PlayerData()
    {
        money = GameManager.manager.money;

        unlockedWheels = new bool[GameManager.manager.wheels.Length];
        for(int w = 0; w < GameManager.manager.wheels.Length; w++)
        {
            unlockedWheels[w] = GameManager.manager.wheels[w].isUnlocked;
        }
        selectedWheel = new bool[GameManager.manager.wheels.Length];
        for (int w = 0; w < GameManager.manager.wheels.Length; w++)
        {
            selectedWheel[w] = GameManager.manager.wheels[w].selected;
        }


        unlockedTrails = new bool[GameManager.manager.trails.Length];
        for (int t = 0; t < GameManager.manager.trails.Length; t++)
        {
            unlockedTrails[t] = GameManager.manager.trails[t].isUnlocked;
        }
        selectedTrail = new bool[GameManager.manager.trails.Length];
        for (int t = 0; t < GameManager.manager.trails.Length; t++)
        {
            selectedTrail[t] = GameManager.manager.trails[t].selected;
        }

    }
}
