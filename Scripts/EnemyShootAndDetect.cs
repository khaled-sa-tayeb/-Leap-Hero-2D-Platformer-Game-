using UnityEngine;

public class EnemyShooterDetector : MonoBehaviour
{
    [Header("Detection")]
    public float detectionRadius = 5f;
    private bool isPlayerInRange = false;

    [Header("Shooting")]
    public GameObject fireballPrefab;
    public Transform firePoint;
    public float shootInterval = 2f;
    public float fireballSpeed = 5f;
    public Transform player;

    private float shootTimer = 0f;

    void Update()
    {
        float distance = Vector2.Distance(transform.position, player.position);

        if (distance <= detectionRadius)
        {
            if (!isPlayerInRange)
            {
                isPlayerInRange = true;
                Debug.Log("Player entered detection range.");
                Shoot(); // Instant shot on enter
                shootTimer = 0f;
            }
            else
            {
                shootTimer += Time.deltaTime;
                Debug.Log("Player still in range. Timer: " + shootTimer.ToString("F2"));

                if (shootTimer >= shootInterval)
                {
                    Shoot();
                    shootTimer = 0f;
                }
            }
        }
        else
        {
            if (isPlayerInRange)
            {
                Debug.Log("Player exited detection range.");
            }

            isPlayerInRange = false;
            shootTimer = 0f;
        }
    }

    void Shoot()
    {
        GameObject fireball = Instantiate(fireballPrefab, firePoint.position, Quaternion.identity);
        Vector2 direction = (player.position - firePoint.position).normalized;
        fireball.GetComponent<Rigidbody2D>().linearVelocity = direction * fireballSpeed;
        Debug.Log("Fireball shot toward player.");
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}
