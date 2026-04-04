using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    private Transform tele;
    private Portal telePortalScript;
    public bool portal1;
    public float distance = 0.2f;
    public float exitAngle = 0f; // Public angle for the exit direction
    public Vector3 exitOffset = Vector3.zero; // Public variable for the exit offset

    private bool hasBeenUsed = false; // Flag to check if the portal has been used

    void Start()
    {
        if (!portal1)
        {
            GameObject portal1Obj = GameObject.FindGameObjectWithTag("Portal1");
            tele = portal1Obj.GetComponent<Transform>();
            telePortalScript = portal1Obj.GetComponent<Portal>();
        }
        else
        {
            GameObject portal2Obj = GameObject.FindGameObjectWithTag("Portal2");
            tele = portal2Obj.GetComponent<Transform>();
            telePortalScript = portal2Obj.GetComponent<Portal>();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!hasBeenUsed && other.CompareTag("Player") && Vector2.Distance(transform.position, other.transform.position) > distance)
        {
            Vector3 relativePosition = other.transform.position - transform.position;
            Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
            Vector2 incomingVelocity = rb.linearVelocity;
            StartCoroutine(Teleport(other, relativePosition, incomingVelocity));
        }
    }

    private IEnumerator Teleport(Collider2D other, Vector3 relativePosition, Vector2 incomingVelocity)
    {
        // Disable the collider of the object to prevent collision responses
        other.enabled = false;

        // Calculate the new position relative to the exit portal and apply the exit offset
        Vector3 newPosition = tele.position + relativePosition + exitOffset;

        // Reposition the object immediately
        other.transform.position = newPosition;

        // Determine the new velocity based on the specified exit angle
        Vector2 outgoingVelocity = TransformVelocity(incomingVelocity, exitAngle);

        // Wait for a short duration before re-enabling the collider
        yield return new WaitForSeconds(0.1f);

        // Set the new velocity
        Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity = outgoingVelocity;
        }

        other.enabled = true;

        // Mark both portals as used
        MarkPortalsAsUsed();
    }

    private void MarkPortalsAsUsed()
    {
        hasBeenUsed = true;
        if (telePortalScript != null)
        {
            telePortalScript.hasBeenUsed = true;
        }
    }

    public void ResetPortal()
    {
        hasBeenUsed = false;
        if (telePortalScript != null)
        {
            telePortalScript.hasBeenUsed = false;
        }
    }

    private Vector2 TransformVelocity(Vector2 velocity, float angle)
    {
        // Convert the angle to radians
        float angleRad = angle * Mathf.Deg2Rad;

        // Create a rotation matrix
        float cosAngle = Mathf.Cos(angleRad);
        float sinAngle = Mathf.Sin(angleRad);

        // Apply the rotation matrix to the velocity vector
        float newVelX = velocity.x * cosAngle - velocity.y * sinAngle;
        float newVelY = velocity.x * sinAngle + velocity.y * cosAngle;

        return new Vector2(newVelX, newVelY);
    }
}
