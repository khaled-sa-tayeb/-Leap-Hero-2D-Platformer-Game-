# 🎮 Leap Hero

> A dynamic 2D platformer game built with Unity, featuring physics-based movement, interactive collectibles, particle effects, and temporary player power-ups.

[![Unity](https://img.shields.io/badge/Engine-Unity-black?logo=unity)](https://unity.com/)
[![Genre](https://img.shields.io/badge/Genre-2D%20Platformer-blue)]()
[![Status](https://img.shields.io/badge/Status-Completed-success)]()

---

## 📸 Gameplay

🎥 **[Watch Gameplay Video](Gameplay.mp4)**

Leap Hero is a 2D platformer focused on responsive player interaction and visual feedback.

The player navigates the level by jumping across platforms, collecting gems, and interacting with gameplay elements. The project also implements custom particle effects to make important player actions more visually engaging.

---

## 🕹️ Project Overview

**Leap Hero** is a 2D platformer developed using **Unity**.

The project focuses on combining basic physics-based gameplay with interactive visual effects to create a more immersive player experience.

The player can:

- 🦘 Jump and navigate through the level
- 🌫️ Trigger a dust effect when landing
- 💎 Collect gems
- 🚀 Temporarily increase jump strength
- 🟢 Enter a visual power-up state
- ✨ Experience pulsing visual feedback during the power-up

The project demonstrates how gameplay mechanics, physics, collision detection, and particle systems can work together to provide clear visual feedback to the player.

---

## ✨ Key Features

### 🦘 Player Movement

The player uses Unity's 2D physics system to move and jump through the environment.

Key components include:

- `Rigidbody2D`
- 2D Colliders
- Jump mechanics
- Collision-based interaction

---

### 🌫️ Landing Dust Effect

A custom Particle System is triggered whenever the player lands on the ground after jumping.

The effect was designed to be:

- Short and responsive
- Visually subtle
- Triggered through collision detection
- Representative of the player's impact with the ground

#### Particle Configuration

| Property | Value |
|---|---:|
| Duration | 0.3s |
| Looping | Disabled |
| Start Lifetime | 0.2s |
| Start Speed | 0.5 |
| Start Size | 0.4 |
| Max Particles | 5 |
| Simulation Space | World |
| Emission | Enabled |
| Shape | Enabled |

This provides immediate visual feedback whenever the player lands.

---

### 💎 Gem Power-Up System

The project includes an interactive collectible gem that temporarily enhances the player's abilities.

When the player collects the gem:

1. 🟢 The player's color changes to green.
2. 🚀 Jump force is increased.
3. ✨ A pulsing visual effect is activated.
4. ⏱️ The power-up remains active for **30 seconds**.
5. 🔄 The player's original state is restored after the duration ends.

The system uses a **Coroutine** to manage the temporary power-up duration and its visual feedback.

---

## ⚙️ Technical Implementation

The project combines several Unity systems to create the gameplay experience.

### Physics & Interaction

- `Rigidbody2D`
- 2D Colliders
- Collision Detection
- Player-environment interaction

### Visual Effects

- Unity Particle System
- Landing dust effect
- Power-up visual feedback
- Pulsing color effect

### Gameplay Systems

- Player jumping
- Collectible objects
- Temporary ability enhancement
- Timed power-up state
- Automatic state restoration

---

## 🧠 What This Project Demonstrates

Leap Hero demonstrates practical experience with:

- 🎮 2D game development
- ⚙️ Unity physics
- 💥 Collision-based events
- ✨ Particle Systems
- 🔄 Coroutine-based timed mechanics
- 🎨 Sprite and visual state manipulation
- 🧩 Gameplay system integration
- 📁 Organized Unity project structure

Rather than relying only on static gameplay elements, the project focuses on providing **visual feedback for player actions**, helping important interactions feel more responsive and engaging.

---

## 📂 Repository Structure

```text
Leap-Hero/
│
├── Scripts/
│   └── Game scripts
│
├── Gameplay.mp4
│
├── Leap Hero Report.pdf
│
└── README.md
