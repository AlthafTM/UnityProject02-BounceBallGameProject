using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    // Set this in the Unity Editor inspector to determine where the player should respawn
    public BallMovement BallMovement;
    public Spawner spawner;
    public GameObject playerPrefab; // Reference to your player prefab
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Destroy the player GameObject
            Destroy(other.gameObject);

            // Respawn the player after a delay
            Invoke("RespawnPlayer", 1.0f); // Adjust the delay time as needed

            BallMovement.SetCanShoot(true);
        }
    }
}
