using UnityEngine;

public class Apple : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player touched an apple!");

            AppleManager.instance.AddApple();

            Debug.Log("Apple count updated, destroying apple!");

            Destroy(gameObject);
        }
    }
}
