using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadProgress : MonoBehaviour
{
    private void Awake()
    {
        PlayerData data = SaveSystem.LoadGame();

        GameManager.manager.money = data.money;

        for (int w = 0; w < GameManager.manager.wheels.Length; w++)
        {
            GameManager.manager.wheels[w].isUnlocked = data.unlockedWheels[w];
            GameManager.manager.wheels[w].selected = data.selectedWheel[w];
        }

        for (int t = 0; t < GameManager.manager.trails.Length; t++)
        {
            GameManager.manager.trails[t].isUnlocked = data.unlockedTrails[t];
            GameManager.manager.trails[t].selected = data.selectedTrail[t];
        }
    }
}
