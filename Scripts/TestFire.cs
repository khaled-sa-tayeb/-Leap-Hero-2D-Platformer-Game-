using UnityEngine;

public class TestFire : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("💥 Trigger entered with: " + other.name);

        if (other.CompareTag("Player"))
        {
            Debug.Log("✅ Hit player!");
        }
    }
}
