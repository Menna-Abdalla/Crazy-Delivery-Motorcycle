using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlace : MonoBehaviour
{
    [SerializeField] DropPointsControllers dropPointsControllers;
    [SerializeField] GameObject car;
    bool checkGift;
    GameObject place;
    Vector3 offset = new Vector3();

    private void OnEnable()
    {
        EventsManager.eDetectGift += ((gift) => checkGift = true);
    }
    private void OnDisable()
    {
        EventsManager.eDetectGift -= ((gift) => checkGift = false);
    }
    void Start()
    {
        //Get the distance between arrow and car
        offset =  transform.position - car.transform.position ;
        //Hide Arrow at the beginning
        transform.GetChild(0).gameObject.SetActive(false);

    }

    
    void FixedUpdate()
    {
        //Follow the Car
        //  transform.position = car.transform.position + offset;
        //Check if there is a gift or not
        // checkGift = car.GetComponent<DeliverySystem>().hasGift;
        place = dropPointsControllers.chosenPlace;
        if (checkGift && place!=null) //if there, go to the place
        {
            //Show Arrow
            transform.GetChild(0).gameObject.SetActive(true);

            //get the place of the gift and point to it
            
            transform.LookAt(place.transform.position);
        }
        else
        {
            //Hide Arrow
            transform.GetChild(0).gameObject.SetActive(false);
        }

    }

}
