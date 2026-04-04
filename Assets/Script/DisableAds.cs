using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableAds : MonoBehaviour
{
    public void Setup(){
        gameObject.SetActive(true);
    }
    public void Exit(){
        gameObject.SetActive(false);
    }
}
