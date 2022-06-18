using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Points : MonoBehaviour
{
    Text points;
    public static int numbers;

    public GameObject endScreen;
    public static bool endIt;

    void Start()
    {
        endIt = false;
        points = GetComponent<Text>();
        numbers = 0;
    }

    void Update()
    {
        points.text = numbers.ToString();

        if(endIt)
            endScreen.SetActive(true);
        else
            endScreen.SetActive(false);
    }

    public static void AddPoints()
    {
        numbers++;
    }
}
