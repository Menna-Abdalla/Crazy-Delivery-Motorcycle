using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TimerManager : MonoBehaviour
{
    float timeLeft ;
    bool startTimer;
    public GameObject car;
    public TextMeshProUGUI timerText;
    // Start is called before the first frame update
    void Start()
    {
        timeLeft = 50f;
    }
    private void OnEnable()
    {
        EventsManager.eDetectGift += ((gift) => startTimer = true); 
        EventsManager.eDeliverGift += ((dropPoint) => startTimer = false);
    }
    private void OnDisable()
    {
        EventsManager.eDetectGift -= ((gift) => startTimer = true); ;
        EventsManager.eDeliverGift -= ((dropPoint) => startTimer = false);
    }
    // Update is called once per frame
    void Update()
    {
        
        //startTimer = car.GetComponent<DeliverySystem>().Timer;
        if (startTimer)
        {
            
            timeLeft -= Time.deltaTime;
            timerText.GetComponent<TextMeshProUGUI>().text =  timeLeft.ToString("#");
            if (timeLeft <= 0)
            {
                Debug.Log("gameOver");
                //startTimer = false;
                SceneManager.LoadScene(1);
            }
        }
        else
        {
            timeLeft = 50f;
            timerText.GetComponent<TextMeshProUGUI>().text = timeLeft.ToString("#.##");
        }
      
    }
}
