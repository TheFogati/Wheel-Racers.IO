using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreVisualizer : MonoBehaviour
{
    public GameObject[] models;

    public void ShowModel(int n)
    {
        for (int m = 0; m < models.Length; m++)
        {
            if (m == n)
                models[m].SetActive(true);
            else
                models[m].SetActive(false);
        }
    }
}
