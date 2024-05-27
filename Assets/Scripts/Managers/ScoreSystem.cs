using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreSystem : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    
    int points ;
    //public AudioSource CoinSound;
    private void OnEnable()
    {
        EventsManager.eDeliverGift += ((dropPoint) => addPoints(10)); 
    }
    private void OnDisable()
    {
        EventsManager.eDeliverGift -= ((dropPoint) => addPoints(10));
    }
    // Start is called before the first frame update
    void Start()
    {
        points =0;
        scoreText.GetComponent<TextMeshProUGUI>().text = "" + points;
    }

 
    void addPoints(int amount)
    {
        //CoinSound.Play();
        points += amount;
        Debug.Log(points);
        scoreText.GetComponent<TextMeshProUGUI>().text = "" + points;
    }
}
