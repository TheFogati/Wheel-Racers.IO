using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetMoney : MonoBehaviour
{
    Text number;

    void Start()
    {
        number = GetComponent<Text>();
    }

    void Update()
    {
        number.text = GameManager.manager.money.ToString();
    }
}
