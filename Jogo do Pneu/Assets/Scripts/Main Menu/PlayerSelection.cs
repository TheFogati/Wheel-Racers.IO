using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelection : MonoBehaviour
{
    void Start()
    {
        foreach(SimpleWheels o in GameManager.manager.simpleWheels)
        {
            if(o.selected)
            {
                GameObject wheel = Instantiate(o.model, transform.position, Quaternion.identity);

                foreach(SimpleTrails i in GameManager.manager.simpleTrails)
                {
                    if(i.selected)
                    {
                        GameObject trail = Instantiate(i.model, wheel.transform.position, Quaternion.Euler(0, 90, 0));
                        trail.transform.SetParent(wheel.transform);
                    }
                }
                foreach (EpicTrails i in GameManager.manager.epicTrails)
                {
                    if (i.selected)
                    {
                        GameObject trail = Instantiate(i.model, wheel.transform.position, Quaternion.Euler(0, 90, 0));
                        trail.transform.SetParent(wheel.transform);
                    }
                }

                wheel.GetComponent<Tire_Script>().enabled = true;
                wheel.GetComponent<Tire_Script>().showcase = true;
            }
        }
        foreach (EpicWheels o in GameManager.manager.epicWheels)
        {
            if (o.selected)
            {
                GameObject wheel = Instantiate(o.model, transform.position, Quaternion.identity);

                foreach (SimpleTrails i in GameManager.manager.simpleTrails)
                {
                    if (i.selected)
                    {
                        GameObject trail = Instantiate(i.model, wheel.transform.position, Quaternion.Euler(0, 90, 0));
                        trail.transform.SetParent(wheel.transform);
                    }
                }
                foreach (EpicTrails i in GameManager.manager.epicTrails)
                {
                    if (i.selected)
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
