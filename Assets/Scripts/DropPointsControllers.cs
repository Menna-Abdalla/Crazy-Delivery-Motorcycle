using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropPointsControllers : MonoBehaviour
{
    [SerializeField] GameObject[] DropPoints;
    public GameObject chosenPlace;
    int randPlace;


    private void OnEnable()
    {
        EventsManager.eDetectGift += ((gift) => ShowRandomDropPoint()) ;
        EventsManager.eDeliverGift += HidePlace;
    }
    private void OnDisable()
    {
        EventsManager.eDetectGift -= ((gift) => ShowRandomDropPoint());
        EventsManager.eDeliverGift -= HidePlace;
    }
    void Start()
    {
        for (int i = 0; i < DropPoints.Length; i++)
        {
            DropPoints[i].SetActive(false);
        }
    }


    void ShowRandomDropPoint()
    {
        randPlace = Random.Range(0, DropPoints.Length);
        DropPoints[randPlace].SetActive(true);
        chosenPlace = DropPoints[randPlace];
    }

    void HidePlace(GameObject GO)
    {
        GO.SetActive(false);
        chosenPlace = null;
    }
}
