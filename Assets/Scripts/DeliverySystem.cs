using System.Collections;

using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DeliverySystem : MonoBehaviour
{

    public GameObject[] Gifts;
    public GameObject[] places;

    public bool hasGift;
    public bool Timer;
    int randGift;
    int randPlace;
    public GameObject chosenPlace;

    //Score Manager
    public GameObject manager;



    //Check hitting a Gift or a Place
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Gift")
        {
            hasGift = true;


        }

        if (other.tag == "Place" && hasGift)  //hasGift Condition --> To make Sure you have a gift first
        {
            hasGift = false;


        }

    }
}
