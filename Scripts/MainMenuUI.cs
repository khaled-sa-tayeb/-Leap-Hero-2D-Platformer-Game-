using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    public void PlayGame()
    {
        Debug.Log("Play button pressed. Loading first level...");
        SceneManager.LoadScene("MainScene"); // Loads First level
    }
}
