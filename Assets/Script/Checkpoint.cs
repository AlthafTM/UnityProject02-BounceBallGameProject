using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    // Reference to the DeathZone script
    public DeathZone[] deathZoneScripts;
    public Vector2 checkpointRespawnPosition; // Checkpoint's respawn position
    private bool activated = false;

    void OnCollisionEnter2D(Collision2D other)
    {
        if (!activated && other.gameObject.CompareTag("Player"))
        {
            Spawner spawner = FindObjectOfType<Spawner>();
            if (spawner != null)
            {
                spawner.UpdateSpawnPosition(checkpointRespawnPosition);
            }
            
            // Debug.Log("Player has hit the checkpoint!");

            activated = true;
        }
    }
}