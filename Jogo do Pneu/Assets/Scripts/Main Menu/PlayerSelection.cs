using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelection : MonoBehaviour
{
    void Start()
    {
        foreach(Wheels o in GameManager.manager.wheels)
        {
            if(o.selected)
            {
                GameObject wheel = Instantiate(o.model, transform.position, Quaternion.identity);

                foreach(Trails i in GameManager.manager.trails)
                {
                    if(i.selected)
                    {
                        GameObject trail = Instantiate(i.model, wheel.transform.position, Quaternion.Euler(0, 90, 0));
                        trail.transform.SetParent(wheel.transform);
                    }
                }

                wheel.GetComponent<Tire_Script>().enabled = true;
                wheel.GetComponent<Tire_Script>().showcase = true;
            }
        }


    }

    void Update()
    {
        
    }
}
