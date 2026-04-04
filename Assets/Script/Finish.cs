using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    public static bool isDead = false;
    public Animator Transition;
    public float TransitionTime = 1f;
    [SerializeField] bool goNextLevel;
    [SerializeField] string LevelName;
    private int _Transition = Animator.StringToHash("Transition");
    private void OnTriggerEnter2D(Collider2D collision) {
        // Debug.Log("Collision detected!");

        if (collision.gameObject.CompareTag("Player"))
        {
            if (!isDead)
            {
                if (SceneController.CurrentLevel >= SceneController.UnlockedLevel){
                SceneController.UnlockedLevel++;
                PlayerPrefs.SetInt("UnlockedLevel", SceneController.UnlockedLevel);
                }

                if (goNextLevel)
                {
                    StartCoroutine(TNextLevel());
                    ScoreManager.isFinished = true;
                }
                else 
                {
                    SceneController.instance.LoadScene(LevelName);
                }
            }
            
        }
    }

    IEnumerator TNextLevel()
    {
        Transition.SetBool(_Transition, true);

        yield return new WaitForSeconds(TransitionTime);

        SceneController.instance.NextLevel();
    }    
}
