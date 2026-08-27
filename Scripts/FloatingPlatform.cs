using UnityEngine;

public class Floating : MonoBehaviour
{
    public float amplitude = 1f;
    public float frequency = 1f;

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
        Debug.Log("Floating initialized. Start position: " + startPos);
    }

    void Update()
    {
        Vector3 tempPos = startPos;
        float offset = Mathf.Sin(Time.time * frequency) * amplitude;
        tempPos.y += offset;
        transform.position = tempPos;

        Debug.Log($"Floating update - Time: {Time.time:F2}, Offset: {offset:F2}, New Y: {tempPos.y:F2}");
    }
}
