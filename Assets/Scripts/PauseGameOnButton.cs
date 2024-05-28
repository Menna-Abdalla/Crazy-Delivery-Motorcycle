using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PauseGameOnButton : MonoBehaviour
{
   [SerializeField] Button ResumeBtn;
    [SerializeField] GameObject notificationPanel;
    private void OnEnable()
    {
        EventsManager.eDeliverGift += ((dropPoint) => ShowPanel());
    }
    private void OnDisable()
    {
        EventsManager.eDeliverGift -= ((dropPoint) => ShowPanel());
    }

    void Start()
    {
        notificationPanel.SetActive(false);
        // Add a listener to the button to resume the game when clicked
        ResumeBtn.onClick.AddListener(HidePanel);
    }
    void ShowPanel()
    {
        notificationPanel.SetActive(true);
        PauseGame();
    }
    void PauseGame()
    {
        Time.timeScale = 0; // Pauses the game
    }
    void HidePanel()
    {
        notificationPanel.SetActive(false);
        ResumeGame();
    }
    void ResumeGame()
    {
        Time.timeScale = 1; // Resumes the game
       // ResumeBtn.gameObject.SetActive(false); // Optionally hide the button after it's clicked
        
    }
}
