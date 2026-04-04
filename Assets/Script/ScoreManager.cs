using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public int DeathCount = 0;
    public Text Score;
    private int wallCollisionCount = 0; // Counter for collisions with walls
    public int WallCollisionCount => wallCollisionCount; // Accessor for the wall collision count
    public GameObject playerObject;
    public Spawner spawner;
    public BallMovement BallMovement;

    private Portal[] portals;
    public int maxWallCollisions = 6; // Public variable for maximum wall collisions
    public GameOver GameOver;
    public static bool isFinished = false;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        Score.text = wallCollisionCount.ToString();
        spawner = FindObjectOfType<Spawner>();
        portals = FindObjectsOfType<Portal>(); // Find all portals in the scene
    }

    void Update()
    {
        playerObject = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            WallScore();
        }
    }

    public void WallScore()
    {
        wallCollisionCount++;
        Score.text = wallCollisionCount.ToString();

        if (wallCollisionCount >= maxWallCollisions)
        {
            if (!isFinished){
                deathmenu();
                Destroy(playerObject); // Destroy the player object
                Finish.isDead = true;
                ResetWallCollisionCount(); // Reset the count after player death
                Score.text = wallCollisionCount.ToString();
                DeathCount++;
                if (DeathCount >= 7 && !SceneController.RewardDelay){
                    DeathCount = DeathCount % DeathCount;
                    AdsManager.Instance.intersitialAds.ShowIntersitialAds();
                }
            }
            
        }
       
            // spawner.Invoke("RespawnPlayer", 1.0f);
            
    }

    public void ResetWallCollisionCount()
    {
        wallCollisionCount = 0;
        Score.text = wallCollisionCount.ToString();
    }

    public void deathmenu(){
        GameOver.Setup();   
    }
}
