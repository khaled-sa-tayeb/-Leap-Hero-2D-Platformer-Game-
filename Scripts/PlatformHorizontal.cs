using UnityEngine;

public class PlatformHorizontal : MonoBehaviour
{
    public float amplitude = 1f;
    public float frequency = 1f;

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
        Debug.Log("PlatformHorizontal initialized. Start position: " + startPos);
    }

    void Update()
    {
        Vector3 tempPos = startPos;
        float offset = Mathf.Sin(Time.time * frequency) * amplitude;
        tempPos.x += offset;
        transform.position = tempPos;

        Debug.Log($"Platform update - Time: {Time.time:F2}, Offset: {offset:F2}, New X: {tempPos.x:F2}");
    }
}
