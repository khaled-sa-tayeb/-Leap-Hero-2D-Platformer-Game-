using UnityEngine;

public class ButtonPulse : MonoBehaviour
{
    public float pulseSpeed = 2f;
    public float scaleAmount = 0.05f;
    private Vector3 originalScale;

    void Start()
    {
        originalScale = transform.localScale;
    }

    void Update()
    {
        float scale = 1 + Mathf.Sin(Time.time * pulseSpeed) * scaleAmount;
        transform.localScale = originalScale * scale;
    }
}
