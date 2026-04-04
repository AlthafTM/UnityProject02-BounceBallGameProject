using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HintMenu : MonoBehaviour
{
    public Hint Hint;
    
    public void Setup()
    {
        gameObject.SetActive(true);
    }

    public void GetHint()
    {
        GameObject hintAdsButton = GameObject.FindGameObjectWithTag("HintAdsButton");
        
        if (hintAdsButton != null)
        {
            Button hintButtonComponent = hintAdsButton.GetComponent<Button>();
            if (hintButtonComponent != null)
            {
                AdsManager.Instance.rewardedAds.ShowRewardedAds();
                Hint.Setup();
                StartCoroutine(ResetRewardAfterDelay(30f));
                gameObject.SetActive(false);
                hintButtonComponent.interactable = false;
            }
        }
    }

    public void Exit()
    {
        gameObject.SetActive(false);
    }

    public void DisableInitializeAds()
    {
        GameObject disableAdsButton = GameObject.FindGameObjectWithTag("DisableAdsButton");

        if (disableAdsButton != null)
        {
            Button disableButtonComponent = disableAdsButton.GetComponent<Button>();
            if (disableButtonComponent != null)
            {
                AdsManager.Instance.rewardedAds.ShowRewardedAds();
                AdsManager.Instance.bannerAds.HideBannerAd();
                SceneController.RewardDelay = true;
                SceneController.instance.SceneCount = 1;
                disableButtonComponent.interactable = false;
                StartCoroutine(ResetRewardAfterDelay(30f));
            }
        }
    }

    private IEnumerator ResetRewardAfterDelay(float delay)
    {
        AdsManager.Instance.rewardedAds.LoadRewardedAds();
        yield return new WaitForSeconds(delay);
        SceneController.instance.isRewarded = false;
    }
}
