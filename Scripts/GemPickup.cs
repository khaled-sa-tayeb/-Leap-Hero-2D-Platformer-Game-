using UnityEngine;

public class GemPickup : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Gem collected by player.");

            AppleManager.instance.AddApple();

            Debug.Log("AppleManager updated. Destroying gem.");

            Destroy(gameObject);
        }
    }
}
