using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int money;

    public bool unlockWheel;
    public int epicUnlockProgress;

    public bool[] unlockedSimpleWheels;
    public bool[] selectedSimpleWheel;
    public bool[] unlockedEpicWheels;
    public bool[] selectedEpicWheel;

    public bool[] unlockedSimpleTrails;
    public bool[] selectedSimpleTrail;
    public bool[] unlockedEpicTrails;
    public bool[] selectedEpicTrail;

    public PlayerData()
    {
        money = GameManager.manager.money;

        unlockWheel = GameManager.manager.unlockWheel;
        epicUnlockProgress = GameManager.manager.epicUnlockProgress;


        #region Wheels
        unlockedSimpleWheels = new bool[GameManager.manager.simpleWheels.Length];
        for(int w = 0; w < GameManager.manager.simpleWheels.Length; w++)
        {
            unlockedSimpleWheels[w] = GameManager.manager.simpleWheels[w].isUnlocked;
        }
        selectedSimpleWheel = new bool[GameManager.manager.simpleWheels.Length];
        for (int w = 0; w < GameManager.manager.simpleWheels.Length; w++)
        {
            selectedSimpleWheel[w] = GameManager.manager.simpleWheels[w].selected;
        }

        unlockedEpicWheels = new bool[GameManager.manager.epicWheels.Length];
        for (int w = 0; w < GameManager.manager.epicWheels.Length; w++)
        {
            unlockedEpicWheels[w] = GameManager.manager.epicWheels[w].isUnlocked;
        }
        selectedEpicWheel = new bool[GameManager.manager.epicWheels.Length];
        for (int w = 0; w < GameManager.manager.epicWheels.Length; w++)
        {
            selectedEpicWheel[w] = GameManager.manager.epicWheels[w].selected;
        }
        #endregion

        #region Trails
        unlockedSimpleTrails = new bool[GameManager.manager.simpleTrails.Length];
        for (int t = 0; t < GameManager.manager.simpleTrails.Length; t++)
        {
            unlockedSimpleTrails[t] = GameManager.manager.simpleTrails[t].isUnlocked;
        }
        selectedSimpleTrail = new bool[GameManager.manager.simpleTrails.Length];
        for (int t = 0; t < GameManager.manager.simpleTrails.Length; t++)
        {
            selectedSimpleTrail[t] = GameManager.manager.simpleTrails[t].selected;
        }

        unlockedEpicTrails = new bool[GameManager.manager.epicTrails.Length];
        for (int t = 0; t < GameManager.manager.epicTrails.Length; t++)
        {
            unlockedEpicTrails[t] = GameManager.manager.epicTrails[t].isUnlocked;
        }
        selectedEpicTrail = new bool[GameManager.manager.epicTrails.Length];
        for (int t = 0; t < GameManager.manager.epicTrails.Length; t++)
        {
            selectedEpicTrail[t] = GameManager.manager.epicTrails[t].selected;
        }
        #endregion
    }
}
