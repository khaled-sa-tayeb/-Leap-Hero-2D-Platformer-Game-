using UnityEngine;

public class PlayerPowerUpHandler : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private PlayerMovement playerMovement;

    private float originalJumpForce;
    private float originalSpeed;
    private Color baseColor;

    private Coroutine jumpCoroutine;
    private Coroutine speedCoroutine;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerMovement = GetComponent<PlayerMovement>();

        originalJumpForce = playerMovement.jumpForce;
        originalSpeed = playerMovement.moveSpeed;
        baseColor = spriteRenderer.color;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Gem"))
        {
            if (jumpCoroutine != null) StopCoroutine(jumpCoroutine);
            jumpCoroutine = StartCoroutine(ApplyJumpBoost(Color.green, 1f, 15f, 15f));
            Destroy(collision.gameObject);
        }
        else if (collision.CompareTag("GemSpeed"))
        {
            if (speedCoroutine != null) StopCoroutine(speedCoroutine);
            speedCoroutine = StartCoroutine(ApplySpeedBoost(Color.cyan, 0.5f, 20f, 1.3f));
            Destroy(collision.gameObject);
        }
    }

    private System.Collections.IEnumerator ApplyJumpBoost(Color pulseColor, float pulseTime, float duration, float boostedJump)
    {
        float elapsed = 0f;
        playerMovement.jumpForce = boostedJump;

        while (elapsed < duration)
        {
            yield return PulseColor(pulseColor, pulseTime);
            elapsed += pulseTime * 2f;
        }

        playerMovement.jumpForce = originalJumpForce;

        // Reset color only if speed effect is not active
        if (speedCoroutine == null)
            spriteRenderer.color = baseColor;

        jumpCoroutine = null;
    }

    private System.Collections.IEnumerator ApplySpeedBoost(Color pulseColor, float pulseTime, float duration, float speedMultiplier)
    {
        float elapsed = 0f;
        playerMovement.moveSpeed *= speedMultiplier;

        while (elapsed < duration)
        {
            yield return PulseColor(pulseColor, pulseTime);
            elapsed += pulseTime * 2f;
        }

        playerMovement.moveSpeed = originalSpeed;

        // Reset color only if jump effect is not active
        if (jumpCoroutine == null)
            spriteRenderer.color = baseColor;

        speedCoroutine = null;
    }

    private System.Collections.IEnumerator PulseColor(Color targetColor, float pulseDuration)
    {
        float t = 0f;

        while (t < pulseDuration)
        {
            t += Time.deltaTime;
            spriteRenderer.color = Color.Lerp(baseColor, targetColor, t / pulseDuration);
            yield return null;
        }

        t = 0f;

        while (t < pulseDuration)
        {
            t += Time.deltaTime;
            spriteRenderer.color = Color.Lerp(targetColor, baseColor, t / pulseDuration);
            yield return null;
        }
    }
}
