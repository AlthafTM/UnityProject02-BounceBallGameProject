using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{
    public int PurchaseAdsDelay = 0;
    public static bool RewardDelay = false;
    public static bool isMuted = false;
    public LevelObject[] LevelObjects;
    public static int CurrentLevel;
    public static int UnlockedLevel;
    public static SceneController instance;
    public AdsManager adsManager;
    public int SceneCount = 1;
    public bool isRewarded = false;
    
    private void Awake()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else 
        {
            Destroy(gameObject);
        }


        InitializeScene();
    }

    private void InitializeScene()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;

        if (currentSceneName == "Menu" || currentSceneName == "LevelMenu")
        {
            if (PurchaseAdsDelay == 0){
                StartCoroutine(DisplayBannerWithDelay());
            }
        }

        if (currentSceneName == "LevelMenu")
        {
            UnlockedLevel = PlayerPrefs.GetInt("UnlockedLevel", 0);
            for (int i = 0; i < LevelObjects.Length; i++)
            {
                if (UnlockedLevel >= i){
                    LevelObjects[i].levelButton.interactable = true;
                }
            }
        }
    }

    private void Update(){
        if (!RewardDelay && PurchaseAdsDelay == 0){
            if ( SceneCount % 6 == 0){
                SceneCount = SceneCount / 5;
                AdsManager.Instance.intersitialAds.ShowIntersitialAds();
            }
        } else if (RewardDelay & PurchaseAdsDelay == 0){
            if ( SceneCount % 21 == 0){
                SceneCount = SceneCount / 20;
                AdsManager.Instance.intersitialAds.ShowIntersitialAds();
                AdsManager.Instance.bannerAds.ShowBannerAds();
                RewardDelay = false;
            }
        }
        
    }

    private IEnumerator DisplayBannerWithDelay(){
        yield return new WaitForSeconds(3f);
        AdsManager.Instance.bannerAds.ShowBannerAds();
    }
    public void NextLevel()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        ScoreManager.instance.DeathCount = 0;
        SceneCount++;
        CurrentLevel++;
        isRewarded = false;
        ScoreManager.isFinished = false;
        Finish.isDead = false;
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadSceneAsync(sceneName);
    }
}
