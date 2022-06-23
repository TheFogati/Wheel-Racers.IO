using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadProgress : MonoBehaviour
{
    private void Awake()
    {
        PlayerData data = SaveSystem.LoadGame();

        GameManager.manager.money = data.money;

        for (int w = 0; w < GameManager.manager.simpleWheels.Length; w++)
        {
            GameManager.manager.simpleWheels[w].isUnlocked = data.unlockedSimpleWheels[w];
            GameManager.manager.simpleWheels[w].selected = data.selectedSimpleWheel[w];
        }
        for (int w = 0; w < GameManager.manager.epicWheels.Length; w++)
        {
            GameManager.manager.epicWheels[w].isUnlocked = data.unlockedEpicWheels[w];
            GameManager.manager.epicWheels[w].selected = data.selectedEpicWheel[w];
        }


        for (int t = 0; t < GameManager.manager.simpleTrails.Length; t++)
        {
            GameManager.manager.simpleTrails[t].isUnlocked = data.unlockedSimpleTrails[t];
            GameManager.manager.simpleTrails[t].selected = data.selectedSimpleTrail[t];
        }
        for (int t = 0; t < GameManager.manager.epicTrails.Length; t++)
        {
            GameManager.manager.epicTrails[t].isUnlocked = data.unlockedEpicTrails[t];
            GameManager.manager.epicTrails[t].selected = data.selectedEpicTrail[t];
        }
    }
}
