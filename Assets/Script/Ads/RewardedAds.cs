using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class RewardedAds : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
{
    [SerializeField] private string androidAdUnitId;
    [SerializeField] private string iosAdUnitId;
    private string AdUnitId;
    private BallMovement ballMovement;

    private void Awake(){
        #if UNITY_IOS
        AdUnitId = iosAdUnitId;
        #elif UNITY_ANDROID
        AdUnitId = androidAdUnitId;
        #endif
    }

    public void LoadRewardedAds(){
        Advertisement.Load(AdUnitId,this);
    }

    public void ShowRewardedAds(){
        Advertisement.Show(AdUnitId,this);
        LoadRewardedAds();
    }

    public void OnUnityAdsAdLoaded(string placementId) {
        Debug.Log("Rewarded Ads Loaded");
    }

    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message) { }
    public void OnUnityAdsShowStart(string placementId) { }
    public void OnUnityAdsShowClick(string placementId) { }
    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message) { }
    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState){
        if (placementId == AdUnitId && showCompletionState.Equals(UnityAdsShowCompletionState.COMPLETED)){
            Debug.Log("Player Rewarded");
            ballMovement = FindObjectOfType<BallMovement>();
            SceneController.instance.isRewarded = true;
            ballMovement.canShoot = true;
            LoadRewardedAds();
        }
    }
}
