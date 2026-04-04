using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class IntersitialAds : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
{
    [SerializeField] private string androidAdUnitId;
    [SerializeField] private string iosAdUnitId;
    private string AdUnitId;

    private void Awake(){
        #if UNITY_IOS
        AdUnitId = iosAdUnitId;
        #elif UNITY_ANDROID
        AdUnitId = androidAdUnitId;
        #endif
    }

    public void LoadIntersitialAds(){
        Advertisement.Load(AdUnitId,this);
    }

    public void ShowIntersitialAds(){
        Advertisement.Show(AdUnitId,this);
        LoadIntersitialAds();
    }

    public void OnUnityAdsAdLoaded(string placementId) {
        Debug.Log("Interstitial Ads Loaded");
    }

    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message) { }
    public void OnUnityAdsShowStart(string placementId) { }
    public void OnUnityAdsShowClick(string placementId) { }
    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message) { }
    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState){
        Debug.Log("Intersitial Ads Initialized");
    }
}