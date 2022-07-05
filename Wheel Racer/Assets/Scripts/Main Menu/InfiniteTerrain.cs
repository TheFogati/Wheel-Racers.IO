using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteTerrain : MonoBehaviour
{
    public GameObject ground;
    public GameObject parent;

    private void OnTriggerEnter(Collider other)
    {
        Instantiate(parent, parent.transform.position + new Vector3(0, 0, parent.transform.localScale.z), Quaternion.identity);
        StartCoroutine(Del());
    }

    IEnumerator Del()
    {
        yield return new WaitForSeconds(6);
        Destroy(parent);
    }

}
