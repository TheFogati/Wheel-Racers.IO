using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WheelStoreManager : MonoBehaviour
{
    public GameObject cantTap;
    [Space]
    public GameObject[] simpleModels;
    public GameObject[] epicModels;
    [Space]
    public Button EquipBtn;
    public Text EquipText;

    int chosenWheel;

    bool epic;

    private void Start()
    {
        epic = false;

        for(int w = 0; w < GameManager.manager.simpleWheels.Length; w++)
        {
            if (GameManager.manager.simpleWheels[w].selected)
            {
                IsEpic(false);
                ShowModel(w);
                CheckAvailability(w);
            }
        }

        for (int w = 0; w < GameManager.manager.epicWheels.Length; w++)
        {
            if (GameManager.manager.epicWheels[w].selected)
            {
                IsEpic(true);
                ShowModel(w);
                CheckAvailability(w);
            }
        }
    }

    public void CheckAvailability(int n)
    {
        if(!epic)
        {
            for (int w = 0; w < GameManager.manager.simpleWheels.Length; w++)
            {
                if (n == w)
                {
                    if (GameManager.manager.simpleWheels[w].isUnlocked)
                    {
                        if (GameManager.manager.simpleWheels[w].selected)
                        {
                            EquipText.text = "Equipped";
                            EquipBtn.interactable = false;
                        }
                        else
                        {
                            EquipText.text = "Equip";
                            EquipBtn.interactable = true;
                        }
                    }
                    else
                    {
                        EquipText.text = "Locked";
                        EquipBtn.interactable = false;
                    }

                    chosenWheel = w;
                }
            }
        }
        else
        {
            for (int w = 0; w < GameManager.manager.epicWheels.Length; w++)
            {
                if (n == w)
                {
                    if (GameManager.manager.epicWheels[w].isUnlocked)
                    {
                        if (GameManager.manager.epicWheels[w].selected)
                        {
                            EquipText.text = "Equipped";
                            EquipBtn.interactable = false;
                        }
                        else
                        {
                            EquipText.text = "Equip";
                            EquipBtn.interactable = true;
                        }
                    }
                    else
                    {
                        EquipText.text = "Locked";
                        EquipBtn.interactable = false;
                    }

                    chosenWheel = w;
                }
            }
        }

    }

    public void Equip()
    {
        foreach (EpicWheels w in GameManager.manager.epicWheels)
        {
            if (w.selected)
                w.selected = false;
        }
        foreach (SimpleWheels w in GameManager.manager.simpleWheels)
        {
            if (w.selected)
                w.selected = false;
        }

        if (!epic)
        {
            GameManager.manager.simpleWheels[chosenWheel].selected = true;
            CheckAvailability(chosenWheel);
        }
        else
        {
            GameManager.manager.epicWheels[chosenWheel].selected = true;
            CheckAvailability(chosenWheel);
        }

        SaveSystem.SaveGame();
    }



    public void ShowModel(int n)
    {
        if(!epic)
        {
            for (int m = 0; m < epicModels.Length; m++)
                epicModels[m].SetActive(false);

            for (int m = 0; m < simpleModels.Length; m++)
            {
                if (m == n)
                    simpleModels[m].SetActive(true);
                else
                    simpleModels[m].SetActive(false);
            }
        }
        else
        {
            for (int m = 0; m < simpleModels.Length; m++)
                simpleModels[m].SetActive(false);

            for (int m = 0; m < epicModels.Length; m++)
            {
                if (m == n)
                    epicModels[m].SetActive(true);
                else
                    epicModels[m].SetActive(false);
            }
        }
    }

    public void IsEpic(bool maybe)
    {
        epic = maybe;
    }


    public void RodaRoda()
    {
        cantTap.SetActive(true);
        StartCoroutine(WheelOfFortune());
    }

    IEnumerator WheelOfFortune()
    {
        EquipText.text = "Spinning";
        EquipBtn.interactable = false;
        epic = false;

        int timeSpinning = 10;
        float interval = .05f;

        for (int i = 0; i < timeSpinning; i++)
        {
            for (int m = 0; m < simpleModels.Length; m++)
            {
                ShowModel(m);

                if (i > Mathf.RoundToInt(timeSpinning * .85f))
                    interval = .1f;

                yield return new WaitForSeconds(interval);
            }
        }

        CheckIfGot();

        GameManager.manager.simpleWheels[chosenWheel].isUnlocked = true;
        ShowModel(chosenWheel);
        Equip();
        cantTap.SetActive(false);
    }


    void CheckIfGot()
    {
        chosenWheel = Random.Range(0, simpleModels.Length);

        if (GameManager.manager.simpleWheels[chosenWheel].isUnlocked)
            CheckIfGot();
    }
}
