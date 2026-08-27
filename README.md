<div align="center">

# 🎮 Leap Hero - 2D Platformer
### A dynamic interactive 2D platformer developed in Unity featuring custom particle systems and power-up mechanics.

[![Course](https://img.shields.io/badge/Course-CPCS%20494-blue)](https://github.com/)
[![Engine](https://img.shields.io/badge/Engine-Unity%206-black)](https://unity.com/)
[![Language](https://img.shields.io/badge/Language-C%23-orange)](https://docs.microsoft.com/en-us/dotnet/csharp/)
[![University](https://img.shields.io/badge/University-King%20Abdulaziz%20University-green)](https://www.kau.edu.sa/)

</div>

---

## 📌 1. Project Overview
"Leap Hero" is a dynamic 2D platformer project developed as part of the **CPCS 494** coursework under the supervision of **Dr. Emad Albassam**[cite: 1]. The core objective is to integrate immersive physics controls and advanced visual effects to enhance player engagement and gameplay feedback[cite: 1].

---

## ✨ 2. Special Requirements & Implementation

### 💨 Landing Dust Effect
A customized Particle System implemented to trigger upon landing on the ground after a jump, adding realistic dynamic feedback[cite: 1]:
* **Duration:** `0.3 seconds`[cite: 1]
* **Start Lifetime:** `0.2 seconds`[cite: 1]
* **Start Speed & Size:** Speed `0.5`, Size `0.4` with World Simulation Space enabled[cite: 1].

### 💎 Power-Up System (Gem Collectible)
An interactive system where collecting a gem in the level triggers temporary abilities for a **30-second** duration[cite: 1]:
* Changes the player's `SpriteRenderer` color and applies a pulsing color effect using Coroutines[cite: 1].
* Temporarily boosts the player's jump force (`JumpForce`)[cite: 1].
* Automatically reverts attributes back to default after the duration expires[cite: 1].

#### 💻 Power-Up & Color Pulse Code Snippet (C# Coroutine):
```csharp
private System.Collections.IEnumerator PulseColorAndBoost(Color targetColor, float pulseDuration, float totalDuration)
{
    isPulsing = true;
    Color originalColor = spriteRenderer.color;
    float elapsed = 0f;
    playerMovement.jumpForce = boostedJumpForce;

    while (elapsed < totalDuration)
    {
        float timer = 0f;
        while (timer < pulseDuration)
        {
            timer += Time.deltaTime;
            spriteRenderer.color = Color.Lerp(originalColor, targetColor, timer / pulseDuration);
            yield return null;
        }

        timer = 0f;
        while (timer < pulseDuration)
        {
            timer += Time.deltaTime;
            spriteRenderer.color = Color.Lerp(targetColor, originalColor, timer / pulseDuration);
            yield return null;
        }
        elapsed += pulseDuration * 2;
    }
}
