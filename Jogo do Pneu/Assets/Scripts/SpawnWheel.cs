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
            foreach(Wheels o in GameManager.manager.wheels)
        {
            if(o.selected)
            {
                spawnedWheel = Instantiate(o.model, transform.position, Quaternion.identity);

                foreach(Trails i in GameManager.manager.trails)
                {
                    if(i.selected)
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
            spawnedWheel = Instantiate(GameManager.manager.wheels[Random.Range(0, GameManager.manager.wheels.Length)].model, transform.position, Quaternion.identity);

            GameObject trail = Instantiate(GameManager.manager.trails[Random.Range(0, GameManager.manager.trails.Length)].model, spawnedWheel.transform.position, Quaternion.Euler(0, 90, 0));
            trail.transform.SetParent(spawnedWheel.transform);

        }
    }
}
