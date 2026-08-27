using UnityEngine;
using TMPro;

public class AppleManager : MonoBehaviour
{
    public static AppleManager instance;

    public TextMeshProUGUI appleText;
    private int appleCount = 0;

    void Awake()
    {
        instance = this;
        Debug.Log("AppleManager initialized.");
    }

    public void AddApple()
    {
        appleCount++;
        appleText.text = "Apples: " + appleCount;
        Debug.Log("Apple added. Current count: " + appleCount);
    }
}
