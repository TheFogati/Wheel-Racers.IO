using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IndicatorScript : MonoBehaviour
{
    Slider slider;
    [HideInInspector]public Transform pos;

    public Image indicatorIcon;
    [HideInInspector]public Sprite customIcon;

    void Start()
    {
        slider = GetComponent<Slider>();
    }

    void Update()
    {
        slider.maxValue = (GameObject.FindGameObjectWithTag("End").transform.position.z);
        slider.value = pos.position.z;

        indicatorIcon.sprite = customIcon;
    }
}
