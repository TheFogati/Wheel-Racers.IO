using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeTab : MonoBehaviour
{
    public GameObject epicTab;
    public GameObject rodaRodaBTN;

    private void Update()
    {
        rodaRodaBTN.SetActive(!epicTab.activeInHierarchy);
    }

    public void ShowEpic()
    {
        epicTab.SetActive(true);
    }

    public void HideTab()
    {
        epicTab.SetActive(false);
    }
}
