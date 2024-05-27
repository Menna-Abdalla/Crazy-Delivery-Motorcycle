using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Numerics;

public class GiftControllers : MonoBehaviour
{
    [SerializeField] GameObject[] Gifts;

    public bool hasGift;
    int randGift;
    int randPlace;

    private void OnEnable()
    {
        EventsManager.eDetectGift += HideGift;
        EventsManager.eDeliverGift += ((dropPoint) => ShowRandomGift());
    }
    private void OnDisable()
    {
        EventsManager.eDetectGift -= HideGift;
        EventsManager.eDeliverGift -= ((dropPoint) => ShowRandomGift());
    }
    void Start()
    {
        for (int i = 0; i < Gifts.Length; i++)
        {
            Gifts[i].SetActive(false);
        }
        ShowRandomGift();
    }


    void HideGift(GameObject GO)
    {
        GO.SetActive(false);
    }

    void ShowRandomGift()
    {
        randGift = Random.Range(0, Gifts.Length);
        Gifts[randGift].SetActive(true);
    }
}
