using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screenshoter : MonoBehaviour
{
    int count = 0;
    void Update(){
        if (Input.GetKeyDown(KeyCode.Space)){
            ScreenCapture.CaptureScreenshot($"E:/Foto/screenshot-{count++}.png");
        }
    }
}
