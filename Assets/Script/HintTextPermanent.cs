using System.Collections;
using UnityEngine;
using TMPro;

public class HintTextPermanent : MonoBehaviour
{
    public static TextMeshProUGUI winText; // Reference to the TextMeshProUGUI component
    public float initialOpacity = 180f / 255f; // Initial opacity of the text (85 out of 255)
    public float initialTextSize = 40.0f; // Initial text size

    void Start()
    {
        // Find the TextMeshProUGUI component in the scene
        winText = GetComponent<TextMeshProUGUI>();

        if (winText == null)
        {
            Debug.LogError("TextMeshProUGUI component not found on the GameObject.");
            return;
        }

        UpdateWinText();
        
    }

    public void UpdateWinText()
    {
        winText.fontSize = initialTextSize;
        SetTextOpacity(initialOpacity);
        winText.text = $"You Have {ScoreManager.instance.maxWallCollisions - 1} Bounce!";
    }

    void SetTextOpacity(float opacity)
    {
        if (winText != null)
        {
            Color color = winText.color;
            color.a = opacity;
            winText.color = color;
        }
    }
}

