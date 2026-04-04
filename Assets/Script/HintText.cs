using System.Collections;
using UnityEngine;
using TMPro;

public class HintText : MonoBehaviour
{
    public static TextMeshProUGUI winText; // Reference to the TextMeshProUGUI component
    public float fadeDuration = 1.0f; // Duration of the fade out effect
    public float initialOpacity = 125f / 255f; // Initial opacity of the text (85 out of 255)
    public float initialTextSize = 68.0f; // Initial text size

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
        StartCoroutine(FadeOutAfterDelay(3.0f));
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

    IEnumerator FadeOutAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        Color originalColor = winText.color;
        for (float t = 0.0f; t < fadeDuration; t += Time.deltaTime)
        {
            float normalizedTime = t / fadeDuration;
            winText.color = Color.Lerp(originalColor, Color.clear, normalizedTime);
            yield return null;
        }
        winText.color = Color.clear;
    }
}
