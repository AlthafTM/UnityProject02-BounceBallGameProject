using UnityEngine;
using UnityEngine.UI;

public class Mute : MonoBehaviour
{
    public Sprite newSprite; // The new sprite to swap to
    private Image buttonImage; // The Image component of the button
    private Sprite originalSprite; // The original sprite of the button

    void Start()
    {
        // Get the Image component attached to the button
        buttonImage = GetComponent<Image>();
        // Store the original sprite
        originalSprite = buttonImage.sprite;

        // Set the initial audio state based on the SceneController's isMuted variable
        SetAudioState(SceneController.isMuted);
    }

    public void OnButtonPress()
    {
        // Swap between the original sprite and the new sprite
        if (buttonImage.sprite == originalSprite)
        {
            buttonImage.sprite = newSprite;
        }
        else
        {
            buttonImage.sprite = originalSprite;
        }

        // Toggle the audio listener
        ToggleAudio();
    }

    private void ToggleAudio()
    {
        // Toggle the isMuted state in the SceneController
        SceneController.isMuted = !SceneController.isMuted;
        SetAudioState(SceneController.isMuted);
    }

    private void SetAudioState(bool isMuted)
    {
        // Find the main camera's AudioListener component
        AudioListener audioListener = Camera.main.GetComponent<AudioListener>();

        if (audioListener != null)
        {
            audioListener.enabled = !isMuted;
        }

        // Update the button sprite based on the isMuted state
        buttonImage.sprite = isMuted ? newSprite : originalSprite;
    }
}
