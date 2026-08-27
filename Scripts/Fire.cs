using UnityEngine;
using System.Collections;
public class fire : MonoBehaviour
{
    public int damageAmount = 1;
    public float pulseTime = 0.2f;
    public float totalPulseDuration = 2f;
    public Color pulseColor = Color.red;
    public Color fallbackColor = Color.white; // لون يرجع له في حال ما قدر يحدد الأصل

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHealth health = other.GetComponent<PlayerHealth>();
            SpriteRenderer sr = other.GetComponent<SpriteRenderer>();

            if (health != null)
            {
                health.TakeDamage(damageAmount);
                Debug.Log("Player touched fire! Damage applied.");

                if (sr != null)
                {
                    StartCoroutine(PulseColorEffect(sr, pulseColor, pulseTime, totalPulseDuration));
                }
            }

            Destroy(gameObject);
        }
    }

    private IEnumerator PulseColorEffect(SpriteRenderer spriteRenderer, Color targetColor, float pulseDuration, float totalDuration)
    {
        Color originalColor = spriteRenderer.material.HasProperty("_BaseColor")
            ? spriteRenderer.material.GetColor("_BaseColor")
            : spriteRenderer.color;

        // fallback إلى اللون الأبيض إذا الأصل غريب أو شفاف
        if (originalColor.a < 0.5f)
            originalColor = fallbackColor;

        float elapsed = 0f;

        while (elapsed < totalDuration)
        {
            float t = 0f;
            while (t < pulseDuration)
            {
                t += Time.deltaTime;
                spriteRenderer.color = Color.Lerp(originalColor, targetColor, t / pulseDuration);
                yield return null;
            }

            t = 0f;
            while (t < pulseDuration)
            {
                t += Time.deltaTime;
                spriteRenderer.color = Color.Lerp(targetColor, originalColor, t / pulseDuration);
                yield return null;
            }

            elapsed += pulseDuration * 2f;
        }

        spriteRenderer.color = originalColor; // ✅ تأكيد العودة
    }
}
