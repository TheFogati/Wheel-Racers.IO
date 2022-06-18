using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrailStoreManager : MonoBehaviour
{
    public TrailRenderer[] models;
    [Space]
    public Button buyEquipBtn;
    public Text buyEquipText;

    bool canSelect;
    int chosenTrail;

    private void Start()
    {
        for (int w = 0; w < GameManager.manager.trails.Length; w++)
        {
            if (GameManager.manager.trails[w].selected)
            {
                ShowModel(w);
                CheckAvailability(w);
            }
        }
    }

    public void CheckAvailability(int n)
    {
        for (int w = 0; w < GameManager.manager.trails.Length; w++)
        {
            if (n == w)
            {
                if (GameManager.manager.trails[w].isUnlocked)
                {
                    if (GameManager.manager.trails[w].selected)
                    {
                        buyEquipText.text = "Equipped";
                        buyEquipBtn.interactable = false;
                    }
                    else
                    {
                        buyEquipText.text = "Equip";
                        buyEquipBtn.interactable = true;
                        canSelect = true;
                    }
                }
                else
                {
                    buyEquipText.text = GameManager.manager.trails[w].price.ToString();
                    buyEquipBtn.interactable = true;
                    canSelect = false;
                }

                chosenTrail = w;
            }
        }
    }

    public void BuyEquip()
    {
        if (canSelect)
        {
            foreach (Trails w in GameManager.manager.trails)
            {
                if (w.selected)
                    w.selected = false;
            }
            GameManager.manager.trails[chosenTrail].selected = true;
            CheckAvailability(chosenTrail);
        }
        else
        {
            if (GameManager.manager.money >= GameManager.manager.trails[chosenTrail].price)
            {
                GameManager.manager.money -= GameManager.manager.trails[chosenTrail].price;
                GameManager.manager.trails[chosenTrail].isUnlocked = true;
                CheckAvailability(chosenTrail);
            }
        }
        SaveSystem.SaveGame();
    }





    public void ShowModel(int n)
    {
        for (int m = 0; m < models.Length; m++)
        {
            if (m == n)
                models[m].emitting = true;
            else
                models[m].emitting = false;
        }
    }
}
