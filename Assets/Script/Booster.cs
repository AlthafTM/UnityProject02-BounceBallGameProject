using UnityEngine;

public class Booster : MonoBehaviour
{
    public float boostForce = 10f; // Adjust the boost force as needed
    public Vector2 boostDirection = Vector2.right; // Change the boost direction here

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("DragArea"))
        {
            return;
        }
        
        // Apply the boost to any other object
        Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity = boostDirection * boostForce;
        }
    }
}
