using UnityEngine;

public class SpeedBoostGem : MonoBehaviour
{
    public float speedMultiplier = 1.3f;
    public float duration = 20f;
    public Color pulseColor = Color.cyan; // أو استخدم new Color(r,g,b)

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerMovement player = other.GetComponent<PlayerMovement>();
            if (player != null)
            {
                StartCoroutine(ApplySpeedBoost(player));
                gameObject.SetActive(false); // اختفِ فورًا
            }
        }
    }

    private System.Collections.IEnumerator ApplySpeedBoost(PlayerMovement player)
    {
        float originalSpeed = player.moveSpeed;
        player.moveSpeed *= speedMultiplier;

        SpriteRenderer sr = player.GetComponent<SpriteRenderer>();
        Color originalColor = sr.color;

        float pulseSpeed = 2f;
        float timer = 0f;

        while (timer < duration)
        {
            float t = (Mathf.Sin(Time.time * pulseSpeed) + 1f) / 2f; // 0 -> 1
            sr.color = Color.Lerp(originalColor, pulseColor, t);
            timer += Time.deltaTime;
            yield return null;
        }

        player.moveSpeed = originalSpeed;
        sr.color = originalColor;
        Destroy(gameObject); // حذف نهائي بعد البوست
    }
}
