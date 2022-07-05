using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnIndicator : MonoBehaviour
{
    public bool isPlayer;
    public GameObject indicator;
    public Sprite icon;

    GameObject indicatorSpawned;

    void Start()
    {
        isPlayer = gameObject.GetComponent<Tire_Script>().player;

        indicatorSpawned = Instantiate(indicator, Vector3.zero, Quaternion.identity);
        indicatorSpawned.transform.SetParent(GameObject.FindGameObjectWithTag("Minimap").transform, false);
        
        indicatorSpawned.GetComponent<IndicatorScript>().pos = transform;
        indicatorSpawned.GetComponent<IndicatorScript>().customIcon = icon;
    }

    private void Update()
    {
        if (isPlayer)
            indicatorSpawned.transform.SetAsLastSibling();
    }
}