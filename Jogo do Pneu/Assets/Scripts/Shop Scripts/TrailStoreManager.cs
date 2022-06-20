using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrailStoreManager : MonoBehaviour
{
    public GameObject[] models;
    [Space]
    public Button EquipBtn;
    public Text EquipText;

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

                chosenTrail = w;
            }
        }
    }

    public void Equip()
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
        SaveSystem.SaveGame();
    }





    public void ShowModel(int n)
    {
        for (int m = 0; m < models.Length; m++)
        {
            TrailRenderer trail = models[m].GetComponent<TrailRenderer>();
            ParticleSystem[] particle = models[m].transform.GetComponentsInChildren<ParticleSystem>();


            if(trail != null)
            {
                if (m == n)
                    trail.emitting = true;
                else
                    trail.emitting = false;
            }

            if(particle != null)
            {
                if (m == n)
                {
                    foreach (ParticleSystem ps in particle)
                    {
                        ps.Play();
                    }
                }
                else
                {
                    foreach (ParticleSystem ps in particle)
                    {
                        ps.Stop();
                    }
                }
            }
            
        }
    }
}
