using UnityEngine;
using System.Collections;

public class MovingPlatformAttach : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(AttachNextFrame(collision.transform));
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(null); // هذا آمن عادي
        }
    }

    private IEnumerator AttachNextFrame(Transform player)
    {
        yield return null; // انتظر فريم واحد
        player.SetParent(transform);
    }
}
