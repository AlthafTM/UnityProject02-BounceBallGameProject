using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class BannerAds : MonoBehaviour
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

        Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
    }

    public void LoadBannerdAds(){
        BannerLoadOptions options = new BannerLoadOptions{
            loadCallback = BannerLoaded,
            errorCallback = BannerLoadedError
        };

        Advertisement.Banner.Load(AdUnitId, options);
    }

    public void ShowBannerAds(){
        BannerOptions options = new BannerOptions{
            showCallback = BannerShown,
            clickCallback = BannerClicked,
            hideCallback = BannerHidden
        };
        Advertisement.Banner.Show(AdUnitId,options);
    }

    public void HideBannerAd(){
        Advertisement.Banner.Hide();
    }

    private void BannerLoaded(){ }
    private void BannerLoadedError(string message){
        Debug.Log("Banner Loaded");
    }
    private void BannerHidden(){ }
    private void BannerClicked(){ }
    private void BannerShown(){ }
}
