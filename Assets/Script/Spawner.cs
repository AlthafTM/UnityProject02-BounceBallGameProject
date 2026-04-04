using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject objectToSpawn; // Assign the prefab you want to spawn in the Inspector
    public Vector2 spawnPosition; // Set the specific coordinates for spawning

    void Start()
    {
        SpawnObject();
    }

    public void SpawnObject()
    {
        Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);
    }

    public void RespawnPlayer()
    {
        // Instantiate a new player GameObject at the specified respawn position
        GameObject newPlayer = Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);
    }
    public void UpdateSpawnPosition(Vector2 newSpawnPosition)
    {
        spawnPosition = newSpawnPosition;
    }
}
