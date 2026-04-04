using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public Animator Transition;
    public float TransitionTime = 1f;
    public HintMenu HintMenu;
    public DisableAds disableAds;
    private int _Transition = Animator.StringToHash("Transition");
    public void Play()
    {
        int unlockedLevel = PlayerPrefs.GetInt("UnlockedLevel", 1);
        if (unlockedLevel == 100)
        {
            unlockedLevel = 1;
        }
        int sceneIndex = unlockedLevel;

        StartCoroutine(PlayTransitions(sceneIndex));
    }

    IEnumerator PlayTransitions(int sceneIndex)
    {
        Transition.SetBool(_Transition, true);

        yield return new WaitForSeconds(TransitionTime);

        SceneManager.LoadSceneAsync(sceneIndex);
    }

    IEnumerator PlayTransition()
    {
        Transition.SetBool(_Transition, true);

        yield return new WaitForSeconds(TransitionTime);

        SceneManager.LoadSceneAsync(102);
    }


    public void Quit()
    {
        Application.Quit();
    }

    public void Home()
    {
        SceneManager.LoadSceneAsync(0);
    }

    public void Back()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex -1);
    }
    public void Hints()
    {
        HintMenu.Setup();
    }
    public void DisabledAds(){
        disableAds.Setup();
    }

    public void LevelMenu()
    {
        StartCoroutine(PlayTransition());
    }
}
