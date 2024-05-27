using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class TriggersDetector : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Gift")
        {
            EventsManager.DetectGift(other.gameObject);
        }

        if (other.tag == "Place") 
        { 
            EventsManager.DeliverGift(other.gameObject);
        }

    }
}
