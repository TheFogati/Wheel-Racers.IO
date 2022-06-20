using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WheelStoreManager : MonoBehaviour
{
    public GameObject[] models;
    [Space]
    public Button EquipBtn;
    public Text EquipText;

    bool canSelect;
    int chosenWheel;

    private void Start()
    {
        for(int w = 0; w < GameManager.manager.wheels.Length; w++)
        {
            if (GameManager.manager.wheels[w].selected)
            {
                ShowModel(w);
                CheckAvailability(w);
            }
        }
    }

    public void CheckAvailability(int n)
    {
        for(int w = 0; w < GameManager.manager.wheels.Length; w++)
        {
            if(n == w)
            {
                if(GameManager.manager.wheels[w].isUnlocked)
                {
                    if(GameManager.manager.wheels[w].selected)
                    {
                        EquipText.text = "Equipped";
                        EquipBtn.interactable = false;
                    }
                    else
                    {
                        EquipText.text = "Equip";
                        EquipBtn.interactable = true;
                        canSelect = true;
                    }
                }
                else
                {
                    EquipText.text = "Locked";
                    EquipBtn.interactable = false;
                    canSelect = false;
                }

                chosenWheel = w;
            }
        }
    }

    public void Equip()
    {
        if(canSelect)
        {
            foreach(Wheels w in GameManager.manager.wheels)
            {
                if (w.selected)
                    w.selected = false;
            }
            GameManager.manager.wheels[chosenWheel].selected = true;
            CheckAvailability(chosenWheel);
        }
        else

        SaveSystem.SaveGame();
    }





    public void ShowModel(int n)
    {
        for (int m = 0; m < models.Length; m++)
        {
            if (m == n)
                models[m].SetActive(true);
            else
                models[m].SetActive(false);
        }
    }
}
