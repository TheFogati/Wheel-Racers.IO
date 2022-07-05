using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Points : MonoBehaviour
{
    Text points;
    public static int numbers;
    public static int position;

    public GameObject endScreen;
    public Image medal;
    public Sprite[] medals;
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

        if(position <= 3)
            medal.sprite = medals[position - 1];
        else
            medal.sprite = medals[3];
    }

    public static void AddPoints()
    {
        numbers++;
    }
}
