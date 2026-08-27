using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour
{
    public GameObject[] confettiEffect;
    public float delayBeforeNextLevel = 3f;

    private bool triggered = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!triggered && other.CompareTag("Player"))
        {
            triggered = true;
            Debug.Log("Player reached level end. Triggering effects...");

            foreach (GameObject effect in confettiEffect)
            {
                var ps = effect.GetComponent<ParticleSystem>();
                if (ps != null)
                {
                    ps.Play();
                    Debug.Log("ParticleSystem played: " + effect.name);
                }
                else
                {
                    effect.SetActive(true);
                    Debug.Log("Effect activated: " + effect.name);
                }
            }

            Debug.Log("Waiting " + delayBeforeNextLevel + " seconds to load next level...");
            Invoke(nameof(LoadNextLevel), delayBeforeNextLevel);
        }
    }

    void LoadNextLevel()
    {
        Debug.Log("Loading scene: Level2");
        SceneManager.LoadScene("Level2");
    }
}
