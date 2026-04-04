using UnityEngine;

public class FrameRateManager : MonoBehaviour
{
    [Header("Frame Settings")]
    public float TargetFrameRate = 240.0f;
    private const int MaxRate = 9999;

    void Awake()
    {
        ApplyFrameSettings();
    }

    void OnEnable()
    {
        ApplyFrameSettings();
    }

    private void ApplyFrameSettings()
    {
        QualitySettings.vSyncCount = 0;
        
        if (TargetFrameRate <= 0f)
            Application.targetFrameRate = MaxRate;
        else
            Application.targetFrameRate = Mathf.FloorToInt(TargetFrameRate);

        // Keep fixed physics timestep at default (50Hz)
        Time.fixedDeltaTime = 0.02f;

        Debug.Log($"[FrameRateManager] vSync={QualitySettings.vSyncCount}, targetFrameRate={Application.targetFrameRate}");
    }
}
