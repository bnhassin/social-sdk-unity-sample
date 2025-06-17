/// <summary>
/// Creates a parallax effect on GameObjects based on mouse position.
/// 
/// This class moves the object in the opposite direction of the mouse cursor
/// to create a depth illusion. The object will move away from the mouse with
/// configurable intensity and smoothing.
/// 
/// This is used to create a cool looking background in the example scene
/// </summary>
using UnityEngine;


public class MouseParallax : MonoBehaviour
{
    [SerializeField] private float parallaxIntensity = 1f;
    [SerializeField] private float smoothTime = 0.1f;
    [SerializeField] private float maxOffset = 2f;

    private Vector3 startPosition;
    private Vector3 targetPosition;
    private Vector3 velocity;
    private Camera mainCamera;

    void Start()
    {
        startPosition = transform.position;
        targetPosition = startPosition;

        mainCamera = Camera.main;
    }

    void Update()
    {
        if (mainCamera == null) return;

        // Get mouse position in viewport coordinates (0-1)
        Vector3 mouseViewport = mainCamera.ScreenToViewportPoint(Input.mousePosition);

        // Convert to centered coordinates (-0.5 to 0.5)
        mouseViewport.x -= 0.5f;
        mouseViewport.y -= 0.5f;

        // Calculate offset (inverted for opposite movement)
        Vector3 offset = new Vector3(
            -mouseViewport.x * parallaxIntensity,
            -mouseViewport.y * parallaxIntensity,
            0f
        );

        // Clamp the offset to prevent objects from moving too far
        offset.x = Mathf.Clamp(offset.x, -maxOffset, maxOffset);
        offset.y = Mathf.Clamp(offset.y, -maxOffset, maxOffset);

        // Calculate target position
        targetPosition = startPosition + offset;

        // Smoothly move to target position
        transform.position = Vector3.SmoothDamp(
            transform.position,
            targetPosition,
            ref velocity,
            smoothTime
        );
    }
}