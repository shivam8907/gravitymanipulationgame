using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public Transform player;            // Reference to the player's transform
    public Vector3 offset = new Vector3(0f, 2f, -5f);  // Offset from the player
    public float smoothTime = 0.3f;     // Smoothing time for camera follow

    public Transform cameraTransform;   // Reference to the main camera's transform

    private Vector3 velocity = Vector3.zero;  // Velocity for SmoothDamp
    private Vector3 lastPlayerPosition; // Store the last position of the player

    void Start()
    {
        // Check if the cameraTransform is not set in the inspector
        if (cameraTransform == null)
        {
            Debug.LogError("Camera Transform is not assigned. Please assign the main camera's transform in the inspector.");
        }

        // Initialize lastPlayerPosition
        lastPlayerPosition = player.position;
    }

    void LateUpdate()
    {
        UpdateCameraPosition();
    }

    void UpdateCameraPosition()
    {
        // Check if the player has moved
        if (player.position != lastPlayerPosition)
        {
            // Set the camera's position based on the player's position and offset
            Vector3 desiredPosition = player.position + offset;
            cameraTransform.position = Vector3.SmoothDamp(cameraTransform.position, desiredPosition, ref velocity, smoothTime);

            // Make the camera look at the player's position
            cameraTransform.LookAt(player.position);

            // Update lastPlayerPosition
            lastPlayerPosition = player.position;
        }
    }
}
