using UnityEngine;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    public GameObject optionsPanel;
    public Slider volumeSlider;
    public AudioSource musicSource;

    void Start()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("MusicVolume", 0.5f);
        musicSource.volume = volumeSlider.value;
        volumeSlider.onValueChanged.AddListener(SetVolume);
    }

    public void OpenOptions()
    {
        optionsPanel.SetActive(true);
    }

    public void CloseOptions()
    {
        optionsPanel.SetActive(false);
    }

    public void SetVolume(float value)
    {
        musicSource.volume = value;
        PlayerPrefs.SetFloat("MusicVolume", value);
    }
}
