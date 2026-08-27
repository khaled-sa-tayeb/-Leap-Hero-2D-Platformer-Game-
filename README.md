<div align="center">

# 🎮 Leap Hero - 2D Platformer
### Comprehensive Technical Documentation & Architecture Overview

[![Course](https://img.shields.io/badge/Course-CPCS%20494-blue)](https://github.com/)
[![Engine](https://img.shields.io/badge/Engine-Unity%206-black)](https://unity.com/)
[![Language](https://img.shields.io/badge/Language-C%23-orange)](https://docs.microsoft.com/en-us/dotnet/csharp/)
[![University](https://img.shields.io/badge/University-King%20Abdulaziz%20University-green)](https://www.kau.edu.sa/)

</div>

---

## 📖 Table of Contents
1. [Project Overview](#-1-project-overview)
2. [Technical Specifications & Engine Setup](#-2-technical-specifications--engine-setup)
3. [Core Systems & Features Breakdown](#-3-core-systems--features-breakdown)
   - [Landing Dust Particle System](#31-landing-dust-particle-system)
   - [Power-Up Gem & Coroutine System](#32-power-up-gem--coroutine-system)
4. [Source Code Implementation](#-4-source-code-implementation)
5. [Repository Structure](#-5-repository-structure)
6. [Project Team & Roles](#-6-project-team--roles)

---

## 📌 1. Project Overview
**Leap Hero** is a feature-rich 2D platformer developed as part of the **CPCS 494** curriculum at King Abdulaziz University, under the supervision of **Dr. Emad Albassam**[cite: 1]. The project bridges game physics and visual feedback mechanisms to deliver a responsive, polished player experience. Key highlights include dynamic environmental interactions, state-based particle emission, and asynchronous coroutine-driven power-up buffers.

---

## ⚙️ 2. Technical Specifications & Engine Setup
* **Game Engine:** Unity 6 (`6000.0.40f1`)[cite: 1]
* **Scripting Language:** C#[cite: 1]
* **Physics Components:** Rigidbody2D, BoxColliders, and Ground Check Raycasting/Collision Events[cite: 1]
* **Target Platform:** Desktop / PC (Standalone)

---

## 🧩 3. Core Systems & Features Breakdown

### 3.1 Landing Dust Particle System
To maximize immersion and give physical weight to movement, a custom particle system fires instantaneously when the player character impacts solid terrain after falling or jumping[cite: 1].
* **Trigger Mechanism:** Ground-collision detection event via script.
* **Particle System Configuration Properties:**
  * **Duration:** `0.3 seconds`[cite: 1]
  * **Looping:** `Disabled`[cite: 1]
  * **Start Lifetime:** `0.2 seconds`[cite: 1]
  * **Start Speed:** `0.5`[cite: 1]
  * **Start Size:** `0.4`[cite: 1]
  * **Simulation Space:** `World`[cite: 1]
  * **Emitter Velocity Mode:** `Rigidbody`[cite: 1]
  * **Max Particles:** `5`[cite: 1]

### 3.2 Power-Up Gem & Coroutine System
An in-game collectible item (Gem) designed to dynamically alter player states for a limited duration when consumed[cite: 1].
* **Lifecycle & State Changes:**
  1. **Collision Detection:** Player enters the Gem's trigger collider.
  2. **Stat Modification:** Jump force (`jumpForce`) is immediately scaled up to a boosted threshold (`boostedJumpForce`)[cite: 1].
  3. **Visual Feedback:** Sprite renderer color shifts dynamically to a glowing green hue accompanied by an alpha pulsing loop[cite: 1].
  4. **Expiration & Reversion:** After exactly **30 seconds**, a background coroutine safely restores original color parameters and baseline jump physics[cite: 1].

---

## 💻 4. Source Code Implementation

Below is the core C# Coroutine responsible for managing the dynamic color lerp pulsing effect and temporary jump amplification:

```csharp
private System.Collections.IEnumerator PulseColorAndBoost(Color targetColor, float pulseDuration, float totalDuration)
{
    isPulsing = true;
    Color originalColor = spriteRenderer.color;
    float elapsed = 0f;
    
    // Apply temporary attribute boost
    playerMovement.jumpForce = boostedJumpForce;

    while (elapsed < totalDuration)
    {
        float timer = 0f;
        // Fade towards target color (Green Pulse)
        while (timer < pulseDuration)
        {
            timer += Time.deltaTime;
            spriteRenderer.color = Color.Lerp(originalColor, targetColor, timer / pulseDuration);
            yield return null;
        }

        timer = 0f;
        // Fade back to original color
        while (timer < pulseDuration)
        {
            timer += Time.deltaTime;
            spriteRenderer.color = Color.Lerp(targetColor, originalColor, timer / pulseDuration);
            yield return null;
        }
        
        elapsed += pulseDuration * 2;
    }

    // Reset status after completion
    isPulsing = false;
}
