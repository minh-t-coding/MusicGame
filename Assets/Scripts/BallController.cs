using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {

    [SerializeField] private float inactivityThreshold = 30f;
    [SerializeField] private Rigidbody2D rb;
    private float lastPositionUpdateTime;

    private void Start() {
        lastPositionUpdateTime = Time.time;
    }

    private void FixedUpdate() {
        // Check if the ball has moved
        if (rb.velocity.sqrMagnitude > 0)
        {
            // Update last position update time when the ball moves
            lastPositionUpdateTime = Time.time;
        }
        else
        {
            // Check if the ball has been inactive for the specified threshold
            if ((Time.time - lastPositionUpdateTime >= inactivityThreshold) && StateManager.instance.getIsPlaying())
            {
                // Deactivate the ball object
                gameObject.SetActive(false);
            }
        }
    }

    private void OnEnable() {
        lastPositionUpdateTime = Time.time;
    }
    
    private void OnBecameInvisible() {
        gameObject.SetActive(false);
    }
}
