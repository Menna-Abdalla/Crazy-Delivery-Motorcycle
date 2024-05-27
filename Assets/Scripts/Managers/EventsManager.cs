using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class EventsManager 
{
    #region Delegutes and events
    public delegate void dDetectGift(GameObject GO);
    public static event dDetectGift eDetectGift;

    public delegate void dDeliverGift(GameObject GO); 
    public static event dDeliverGift eDeliverGift;



    #endregion

    #region Functions

    public static void DetectGift(GameObject GO)
    {
        if (eDetectGift != null)
        {
            eDetectGift(GO);
        }
    }

    public static void DeliverGift(GameObject GO)
    {
        if (eDeliverGift != null)
        {
            eDeliverGift(GO);
        }
    }

    #endregion


}
