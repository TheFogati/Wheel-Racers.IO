using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AcceleratePedal : MonoBehaviour
{
    public static bool pisaFundo = false;

    public void Press()
    {
        pisaFundo = true;
    }

    public void Release()
    {
        pisaFundo = false;
    }
}
