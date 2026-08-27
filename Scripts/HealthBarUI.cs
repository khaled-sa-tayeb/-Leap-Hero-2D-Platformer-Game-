using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
{
    public Slider slider;

    public void SetMaxHealth(int max)
    {
        slider.maxValue = max;
        slider.value = max;
    }

    public void SetHealth(int value)
    {
        slider.value = value;
    }
}
