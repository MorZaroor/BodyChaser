using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float leftOffset = 2f; // Distance from the left edge of the screen
    public float smoothTime = 0.3f; // Time to smooth damp
    public float maxSpeed = 10f; // Maximum speed the camera can move
    public float lookAheadFactor = 0.5f; // How much to look ahead when player accelerates

    private float cameraHalfWidth;
    private Vector3 velocity = Vector3.zero;
    private float initialY;
    private float targetX;

    void Start()
    {
        if (Camera.main == null) return;
        cameraHalfWidth = Camera.main.orthographicSize * Camera.main.aspect;
        initialY = transform.position.y; // Store the initial Y position of the camera
        targetX = target.position.x;
    }

    void LateUpdate()
    {
        if (target == null) return;

        // Calculate the desired x position with look-ahead
        float lookAheadX = (target.position.x - targetX) * lookAheadFactor;
        targetX = target.position.x;
        float desiredX = targetX + cameraHalfWidth - leftOffset + lookAheadX;

        // Create the target position, keeping Y constant
        Vector3 targetPosition = new Vector3(desiredX, initialY, transform.position.z);

        // Smoothly move the camera using SmoothDamp
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime, maxSpeed);
    }
}