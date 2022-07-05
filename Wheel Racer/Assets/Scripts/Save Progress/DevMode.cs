using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DevMode : MonoBehaviour
{
    public void EraseProgress()
    {
        GameManager.manager.money = 0;

        for (int w = 0; w < GameManager.manager.simpleWheels.Length; w++)
        {
            GameManager.manager.simpleWheels[w].isUnlocked = false;
            GameManager.manager.simpleWheels[w].selected = false;
        }
        for (int w = 0; w < GameManager.manager.epicWheels.Length; w++)
        {
            GameManager.manager.epicWheels[w].isUnlocked = false;
            GameManager.manager.epicWheels[w].selected = false;
        }


        for (int t = 0; t < GameManager.manager.simpleTrails.Length; t++)
        {
            GameManager.manager.simpleTrails[t].isUnlocked = false;
            GameManager.manager.simpleTrails[t].selected = false;
        }
        for (int t = 0; t < GameManager.manager.epicTrails.Length; t++)
        {
            GameManager.manager.epicTrails[t].isUnlocked = false;
            GameManager.manager.epicTrails[t].selected = false;
        }

        GameManager.manager.simpleWheels[0].isUnlocked = true;
        GameManager.manager.simpleTrails[0].isUnlocked = true;
        GameManager.manager.simpleWheels[0].selected = true;
        GameManager.manager.simpleTrails[0].selected = true;

        SaveSystem.SaveGame();

        SceneManager.LoadScene(0);

    }

    public void UnlockAll()
    {
        for (int w = 0; w < GameManager.manager.simpleWheels.Length; w++)
        {
            GameManager.manager.simpleWheels[w].isUnlocked = true;
            GameManager.manager.simpleWheels[w].selected = false;
        }
        for (int w = 0; w < GameManager.manager.epicWheels.Length; w++)
        {
            GameManager.manager.epicWheels[w].isUnlocked = true;
            GameManager.manager.epicWheels[w].selected = false;
        }


        for (int t = 0; t < GameManager.manager.simpleTrails.Length; t++)
        {
            GameManager.manager.simpleTrails[t].isUnlocked = true;
            GameManager.manager.simpleTrails[t].selected = false;
        }
        for (int t = 0; t < GameManager.manager.epicTrails.Length; t++)
        {
            GameManager.manager.epicTrails[t].isUnlocked = true;
            GameManager.manager.epicTrails[t].selected = false;
        }

        GameManager.manager.simpleWheels[0].selected = true;
        GameManager.manager.simpleTrails[0].selected = true;

        SaveSystem.SaveGame();

        SceneManager.LoadScene(0);
    }

    public void HESOYAM()
    {
        GameManager.manager.money += 10000;

        SaveSystem.SaveGame();
    }
}
