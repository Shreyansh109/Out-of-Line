# Out-of-Line

Out-of-Line is a 2D action-platformer and metroidvania-inspired Unity prototype focused on responsive movement, traversal, and combat. The project combines side-scrolling platforming with classic skill-based mechanics such as jumping, wall interaction, dashing, melee attacks, and throwable weapons.

## Overview

This repository contains a Unity project for a compact 2D game prototype built around a custom movement controller and enemy interaction system. The gameplay loop is centered on moving through a level, fighting hostile enemies, avoiding hazards, and using platforming movement to gain control and momentum.

## Features

- Side-scrolling 2D movement system
- Jumping and double-jump behavior
- Wall sliding and wall jump support
- Dash mechanics
- Melee combat and damage handling
- Throwable weapon/projectile system
- Enemy AI with hit and death states
- Camera follow and environmental hazard logic
- Audio effects for movement and impacts
- Unity Input System configuration and URP setup

## Tech Stack

- Unity 6000.3.13f1
- C# scripting
- Unity Input System
- Universal Render Pipeline (URP)
- 2D physics and animation packages

## Project Structure

- `Assets/Scenes/` - playable scene files
- `Assets/Scripts/` - custom gameplay scripts
- `Assets/MetroidvaniaController/` - reusable platformer and combat systems
- `ProjectSettings/` - Unity project configuration
- `Packages/manifest.json` - package dependencies

## Getting Started

1. Install Unity Hub and Unity 6000.3.13f1 (or a compatible newer Unity version for this project).
2. Clone this repository.
3. Open the project folder in Unity Hub.
4. Load the main scene from `Assets/Scenes/`.
5. Press Play to test the prototype.

## Controls

The project includes an Input Actions asset for keyboard/gamepad input. Typical controls are:

- Move: A/D or Left/Right arrow keys
- Jump: Space or W/Up arrow
- Attack: configured in the Input Actions asset
- Throw projectile: configured in the Input Actions asset

## Notes

This project is a gameplay prototype and may continue to evolve as a larger game. It is intended as a foundation for 2D action-platforming mechanics and can be expanded with more levels, enemies, UI, save systems, and polish.

## License

This project does not currently declare a specific license. If you plan to distribute or reuse it, add an appropriate license before publishing.
