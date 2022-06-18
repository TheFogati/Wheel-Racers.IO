using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_Builder : MonoBehaviour
{
    public GameObject startTrack;
    public GameObject middleRegularTrack;
    public GameObject[] middleSpecialTrack;
    public GameObject endTrack;

    GameObject lastTrack;
    GameObject currentTrack;

    int k = 0;

    bool once = true;

    void Start()
    {
        lastTrack = startTrack;
    }

    void Update()
    {
        if(once)
        {
            Stage(5);

            currentTrack = Instantiate(endTrack, transform.position, Quaternion.identity);
            currentTrack.transform.position = lastTrack.transform.GetChild(1).gameObject.transform.position - currentTrack.transform.GetChild(0).gameObject.transform.position;
            currentTrack.transform.SetParent(transform);

            once = false;
        }
    }


    void Stage(int times)
    {
        while(k < times)
        {
            for (int i = 0; i < 2; i++)
            {
                currentTrack = Instantiate(middleRegularTrack, transform.position, Quaternion.Euler(Random.Range(-25f, 25f), 0, 0));
                currentTrack.transform.position = lastTrack.transform.GetChild(1).gameObject.transform.position - currentTrack.transform.GetChild(0).gameObject.transform.position;
                lastTrack = currentTrack;
                lastTrack.transform.SetParent(transform);
            }

            currentTrack = Instantiate(middleSpecialTrack[Random.Range(0, middleSpecialTrack.Length)], transform.position, Quaternion.identity);
            currentTrack.transform.position = lastTrack.transform.GetChild(1).gameObject.transform.position - currentTrack.transform.GetChild(0).gameObject.transform.position;
            lastTrack = currentTrack;
            currentTrack.transform.SetParent(transform);

            for (int i = 0; i < 2; i++)
            {
                currentTrack = Instantiate(middleRegularTrack, transform.position, Quaternion.Euler(Random.Range(-25f, 25f), 0, 0));
                currentTrack.transform.position = lastTrack.transform.GetChild(1).gameObject.transform.position - currentTrack.transform.GetChild(0).gameObject.transform.position;
                lastTrack = currentTrack;
                lastTrack.transform.SetParent(transform);
            }

            k++;
        }

        
    }
}
