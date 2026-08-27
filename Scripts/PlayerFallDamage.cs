using UnityEngine;

public class PlayerFallDamage : MonoBehaviour
{
    public float fallThreshold = -15f;
    public int fallDamage = 1;

    private bool tookFallDamage = false;
    private Rigidbody2D rb;
    private PlayerHealth playerHealth;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerHealth = GetComponent<PlayerHealth>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (rb.linearVelocity.y < fallThreshold)
        {
            tookFallDamage = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (tookFallDamage)
        {
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(fallDamage);
                Debug.Log("Fall damage applied!");
                StartCoroutine(FlashTransparency()); // تشغيل تأثير الشفافية
            }

            tookFallDamage = false;
        }
    }

    private System.Collections.IEnumerator FlashTransparency()
    {
        float flashDuration = 0.3f;
        float transparentAlpha = 0.3f;

        // نحفظ اللون الأصلي
        Color originalColor = spriteRenderer.color;

        // نخلي اللاعب شفاف
        Color transparentColor = new Color(originalColor.r, originalColor.g, originalColor.b, transparentAlpha);
        spriteRenderer.color = transparentColor;

        yield return new WaitForSeconds(flashDuration);

        // نرجع اللون الطبيعي
        spriteRenderer.color = originalColor;
    }
}
