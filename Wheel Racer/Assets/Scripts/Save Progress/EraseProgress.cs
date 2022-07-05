using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EraseProgress : MonoBehaviour
{
    public void Erase()
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
}
