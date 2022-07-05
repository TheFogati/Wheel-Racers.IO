using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnWheel : MonoBehaviour
{
    public bool playerSpawner;

    GameObject spawnedWheel;
    void Start()
    {
        if (playerSpawner)
        {
            foreach(SimpleWheels o in GameManager.manager.simpleWheels)
            {
                if(o.selected)
                {
                    spawnedWheel = Instantiate(o.model, transform.position, Quaternion.identity);

                    foreach(SimpleTrails i in GameManager.manager.simpleTrails)
                    {
                        if(i.selected)
                        {
                            GameObject trail = Instantiate(i.model, spawnedWheel.transform.position, Quaternion.Euler(0, 90, 0));
                            trail.transform.SetParent(spawnedWheel.transform);
                        }
                    }
                    foreach (EpicTrails i in GameManager.manager.epicTrails)
                    {
                        if (i.selected)
                        {
                            GameObject trail = Instantiate(i.model, spawnedWheel.transform.position, Quaternion.Euler(0, 90, 0));
                            trail.transform.SetParent(spawnedWheel.transform);
                        }
                    }
                }
            }
            foreach (EpicWheels o in GameManager.manager.epicWheels)
            {
                if (o.selected)
                {
                    spawnedWheel = Instantiate(o.model, transform.position, Quaternion.identity);

                    foreach (SimpleTrails i in GameManager.manager.simpleTrails)
                    {
                        if (i.selected)
                        {
                            GameObject trail = Instantiate(i.model, spawnedWheel.transform.position, Quaternion.Euler(0, 90, 0));
                            trail.transform.SetParent(spawnedWheel.transform);
                        }
                    }
                    foreach (EpicTrails i in GameManager.manager.epicTrails)
                    {
                        if (i.selected)
                        {
                            GameObject trail = Instantiate(i.model, spawnedWheel.transform.position, Quaternion.Euler(0, 90, 0));
                            trail.transform.SetParent(spawnedWheel.transform);
                        }
                    }
                }
            }

            spawnedWheel.tag = "Player";
            spawnedWheel.GetComponent<Tire_Script>().player = true;
        }
        else
        {
            float wheelRandomizer = Random.Range(0f, 1f);
            float trailRandomizer = Random.Range(0f, 1f);

            if(wheelRandomizer > .2f)
                spawnedWheel = Instantiate(GameManager.manager.simpleWheels[Random.Range(0, GameManager.manager.simpleWheels.Length)].model, transform.position, Quaternion.identity);
            else
                spawnedWheel = Instantiate(GameManager.manager.epicWheels[Random.Range(0, GameManager.manager.epicWheels.Length)].model, transform.position, Quaternion.identity);

            if(trailRandomizer > .2f)
            {
                GameObject trail = Instantiate(GameManager.manager.simpleTrails[Random.Range(0, GameManager.manager.simpleTrails.Length)].model, spawnedWheel.transform.position, Quaternion.Euler(0, 90, 0));
                trail.transform.SetParent(spawnedWheel.transform);
            }
            else
            {
                GameObject trail = Instantiate(GameManager.manager.epicTrails[Random.Range(0, GameManager.manager.epicTrails.Length)].model, spawnedWheel.transform.position, Quaternion.Euler(0, 90, 0));
                trail.transform.SetParent(spawnedWheel.transform);
            }
        }
    }
}
