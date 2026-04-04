using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Repeat : MonoBehaviour
{
    public GameObject playerObject;
    public Spawner spawner;             // make sure RespawnPlayer() is public
    public Text Score;
    public BallMovement BallMovement;
    private Portal[] portals;
    private ScoreManager scoreManager;
    private bool canRepeat = true;

    // small configurable delay (0 = next frame)
    [Tooltip("0 = respawn next frame. Use a small value if needed.")]
    public float respawnDelay = 0f;

    private void Start()
    {
        portals = FindObjectsOfType<Portal>();
        scoreManager = ScoreManager.instance;
    }

    public void repeat()
    {
        if (canRepeat)
        {
            StartCoroutine(RepeatCoroutine());
        }
    }

    private IEnumerator RepeatCoroutine()
    {
        canRepeat = false;

        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject player in players)
        {
            Destroy(player); // destroyed at end of frame
        }

        scoreManager.ResetWallCollisionCount();
        BallMovement.SetCanShoot(true);

        foreach (Portal portal in portals)
        {
            portal.ResetPortal();
        }

        // Wait one frame (or a tiny configurable time) so destroyed objects are cleaned up
        if (respawnDelay <= 0f)
            yield return null;
        else
            yield return new WaitForSeconds(respawnDelay);

        // Call respawn directly (avoid string Invoke)
        spawner.RespawnPlayer();

        canRepeat = true;
    }
}
