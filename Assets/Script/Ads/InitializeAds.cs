using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class InitializeAds : MonoBehaviour, IUnityAdsInitializationListener
{
    [SerializeField] private string androidGameId;
    [SerializeField] private string iosdGameId;
    [SerializeField] private bool testing;

    private string gameId;

    private void Awake(){
        #if UNITY_IOS
        gameId = iosdGameId;
        #elif UNITY_ANDROID
        gameId = androidGameId;
        #elif UNITY_EDITOR
        gameId = androidGameId;
        #endif

        if(!Advertisement.isInitialized && Advertisement.isSupported){
            Advertisement.Initialize(gameId,testing, this);
        }
    }

    public void OnInitializationComplete() {
        Debug.Log("Initialize Ads Loaded");
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message) { }


}
