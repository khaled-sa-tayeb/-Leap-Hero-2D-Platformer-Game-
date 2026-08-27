using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;
    public float smoothSpeed = 0.125f;
    public float minY;
    public BoxCollider2D cameraBounds;

    private float minX, maxX;
    private float minBoundY, maxBoundY;
    private float camHalfWidth, camHalfHeight;

    private void Start()
    {
        // احسب أبعاد الكاميرا
        camHalfHeight = Camera.main.orthographicSize;
        camHalfWidth = camHalfHeight * Camera.main.aspect;
        Debug.Log($"Camera half size: width = {camHalfWidth}, height = {camHalfHeight}");

        // احسب حدود الكاميرا من البوكس كوليدر
        Bounds bounds = cameraBounds.bounds;
        minX = bounds.min.x + camHalfWidth;
        maxX = bounds.max.x - camHalfWidth;
        minBoundY = bounds.min.y + camHalfHeight;
        maxBoundY = bounds.max.y - camHalfHeight;
        Debug.Log($"Camera bounds: X({minX} to {maxX}), Y({minBoundY} to {maxBoundY})");
    }

    private void LateUpdate()
    {
        Vector3 desiredPosition = player.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        float clampedX = Mathf.Clamp(smoothedPosition.x, minX, maxX);
        float clampedY = Mathf.Clamp(smoothedPosition.y, Mathf.Max(minBoundY, minY), maxBoundY);

        Debug.Log($"Desired position: {desiredPosition}, Smoothed: {smoothedPosition}, Final: ({clampedX}, {clampedY})");


        transform.position = new Vector3(clampedX, clampedY, transform.position.z);
    }
}
