using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;

public class IAPManager : MonoBehaviour
{
    private string DisableAds = "com.althafm.bounce.disableads";

    public void OnPurchaseComplete(Product product){
        if (product.definition.id == DisableAds)
        {
            SceneController.instance.PurchaseAdsDelay++;
            PlayerPrefs.SetInt("PurchaseAdsDelay", SceneController.instance.PurchaseAdsDelay);
        }
    }

    public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason){
        Debug.Log(product.definition.id + " failed because" + failureReason);
    }
}
