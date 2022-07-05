using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyingScript : MonoBehaviour
{
    public GameObject notEnough;
    [Space]
    public Button buyBTN;
    [Space]
    public Image buyImage;
    public Sprite[] buySprites;
    [Space]
    public WheelStoreManager wheelStore;
    public TrailStoreManager trailStore;
    public bool isTrail;

    bool stillHas;


    private void Update()
    {
        if(!isTrail)
        {
            foreach(SimpleWheels w in GameManager.manager.simpleWheels)
            {
                if(!w.isUnlocked)
                {
                    stillHas = true;
                    break;
                }
                else
                    stillHas = false;
            }
        }
        else
        {
            foreach (SimpleTrails t in GameManager.manager.simpleTrails)
            {
                if (!t.isUnlocked)
                {
                    stillHas = true;
                    break;
                }
                else
                    stillHas = false;
            }
        }

        if (stillHas)
            buyBTN.interactable = true;
        else
            buyBTN.interactable = false;

        if (GameManager.manager.money >= 300)
            buyImage.sprite = buySprites[0];
        else
            buyImage.sprite = buySprites[1];
    }

    public void Buy()
    {
        if(!isTrail)
        {
            if (GameManager.manager.money >= 300)
            {
                GameManager.manager.money -= 300;
                wheelStore.RodaRoda();
            }
            else
                notEnough.SetActive(true);
        }
        else
        {
            if (GameManager.manager.money >= 300)
            {
                GameManager.manager.money -= 300;
                trailStore.RodaRoda();
            }
            else
                notEnough.SetActive(true);
        }
        
    }

}
