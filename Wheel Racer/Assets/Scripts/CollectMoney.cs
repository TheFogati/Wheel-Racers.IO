using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectMoney : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Points.numbers++;
            Destroy(gameObject);
        }
    }
}
