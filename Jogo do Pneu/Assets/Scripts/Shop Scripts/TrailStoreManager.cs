using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrailStoreManager : MonoBehaviour
{
    public GameObject cantTap;
    [Space]
    public GameObject[] simpleModels;
    public GameObject[] epicModels;
    [Space]
    public Button EquipBtn;
    public Text EquipText;

    int chosenTrail;

    bool epic;

    private void Start()
    {
        for (int w = 0; w < GameManager.manager.simpleTrails.Length; w++)
        {
            if (GameManager.manager.simpleTrails[w].selected)
            {
                IsEpic(false);
                ShowModel(w);
                CheckAvailability(w);
            }
        }

        for (int w = 0; w < GameManager.manager.epicTrails.Length; w++)
        {
            if (GameManager.manager.epicTrails[w].selected)
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
            for (int w = 0; w < GameManager.manager.simpleTrails.Length; w++)
            {
                if (n == w)
                {
                    if (GameManager.manager.simpleTrails[w].isUnlocked)
                    {
                        if (GameManager.manager.simpleTrails[w].selected)
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

                    chosenTrail = w;
                }
            }
        }
        else
        {
            for (int w = 0; w < GameManager.manager.epicTrails.Length; w++)
            {
                if (n == w)
                {
                    if (GameManager.manager.epicTrails[w].isUnlocked)
                    {
                        if (GameManager.manager.epicTrails[w].selected)
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

                    chosenTrail = w;
                }
            }
        }

        
    }

    public void Equip()
    {
        foreach (SimpleTrails w in GameManager.manager.simpleTrails)
        {
            if (w.selected)
                w.selected = false;
        }
        foreach (EpicTrails w in GameManager.manager.epicTrails)
        {
            if (w.selected)
                w.selected = false;
        }

        if (!epic)
        {
            GameManager.manager.simpleTrails[chosenTrail].selected = true;
            CheckAvailability(chosenTrail);
        }
        else
        {
            GameManager.manager.epicTrails[chosenTrail].selected = true;
            CheckAvailability(chosenTrail);
        }

        SaveSystem.SaveGame();
    }





    public void ShowModel(int n)
    {
        if(!epic)
        {
            for (int m = 0; m < epicModels.Length; m++)
            {
                TrailRenderer trail = epicModels[m].GetComponent<TrailRenderer>();
                ParticleSystem[] particle = epicModels[m].transform.GetComponentsInChildren<ParticleSystem>();

                if (trail != null)
                    trail.emitting = false;

                if (particle != null)
                {
                    foreach (ParticleSystem ps in particle)
                        ps.Stop();
                }
            }


            for (int m = 0; m < simpleModels.Length; m++)
            {
                TrailRenderer trail = simpleModels[m].GetComponent<TrailRenderer>();
                ParticleSystem[] particle = simpleModels[m].transform.GetComponentsInChildren<ParticleSystem>();


                if (trail != null)
                {
                    if (m == n)
                        trail.emitting = true;
                    else
                        trail.emitting = false;
                }

                if (particle != null)
                {
                    if (m == n)
                    {
                        foreach (ParticleSystem ps in particle)
                            ps.Play();
                    }
                    else
                    {
                        foreach (ParticleSystem ps in particle)
                            ps.Stop();
                    }
                }

            }
        }
        else
        {
            for (int m = 0; m < simpleModels.Length; m++)
            {
                TrailRenderer trail = simpleModels[m].GetComponent<TrailRenderer>();
                ParticleSystem[] particle = simpleModels[m].transform.GetComponentsInChildren<ParticleSystem>();

                if (trail != null)
                    trail.emitting = false;

                if (particle != null)
                {
                    foreach (ParticleSystem ps in particle)
                        ps.Stop();
                }
            }


            for (int m = 0; m < epicModels.Length; m++)
            {
                TrailRenderer trail = epicModels[m].GetComponent<TrailRenderer>();
                ParticleSystem[] particle = epicModels[m].transform.GetComponentsInChildren<ParticleSystem>();


                if (trail != null)
                {
                    if (m == n)
                        trail.emitting = true;
                    else
                        trail.emitting = false;
                }

                if (particle != null)
                {
                    if (m == n)
                    {
                        foreach (ParticleSystem ps in particle)
                            ps.Play();
                    }
                    else
                    {
                        foreach (ParticleSystem ps in particle)
                            ps.Stop();
                    }
                }
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

        GameManager.manager.simpleTrails[chosenTrail].isUnlocked = true;
        ShowModel(chosenTrail);
        Equip();
        cantTap.SetActive(false);
    }


    void CheckIfGot()
    {
        chosenTrail = Random.Range(0, simpleModels.Length);

        if (GameManager.manager.simpleTrails[chosenTrail].isUnlocked)
            CheckIfGot();
    }
}
