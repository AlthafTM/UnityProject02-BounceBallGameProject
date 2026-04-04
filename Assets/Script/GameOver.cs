using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public Repeat Repeat;
    public void Setup(){
        gameObject.SetActive(true);
        GameObject disableAdsButton = GameObject.FindGameObjectWithTag("DisableAdsButton");

        if (disableAdsButton != null && SceneController.RewardDelay) {
            Button disableButtonComponent = disableAdsButton.GetComponent<Button>();
            if (disableButtonComponent != null){
                disableButtonComponent.interactable = false;
            }
        }
    }

    public void repeat(){
       Repeat.repeat();
       gameObject.SetActive(false);
       Finish.isDead = false;
    }

    public void home(){
        SceneManager.LoadSceneAsync(0);
    }


}
