using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoRotation : MonoBehaviour
{

    void Update()
    {
        transform.rotation = Quaternion.Euler(0 ,90 ,0);
    }
}
