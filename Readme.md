# Out-of-Line

Out-of-Line is a Unity-based 2D action-platformer prototype focused on responsive traversal, precise movement, and combat. Built as a compact metroidvania-inspired gameplay sandbox, it blends platforming, enemy encounters, environmental hazards, and a momentum-driven player controller.

## Overview

This repository contains an early game prototype designed to explore the feel of a fast, skill-based 2D action platformer. The project emphasizes player control and movement readability, with mechanics such as wall interaction, dashing, jumping, melee combat, and projectile attacks forming the core of the play loop.

## Features

- Side-scrolling 2D platforming movement
- Jumping and double-jump support
- Wall sliding, wall jumping, and vertical traversal
- Dash movement with momentum-based feel
- Melee attacks and damage interaction
- Throwable weapon/projectile system
- Enemy AI with hit and death states
- Camera follow and hazard logic
- Audio effects for movement and impact feedback
- Unity Input System and URP setup

## Gameplay Loop

The prototype centers on moving through a compact level, maintaining control while traversing gaps and vertical space, and fighting enemies in rhythm with movement. Players are encouraged to combine platforming mastery with combat timing to stay in control and handle hazards effectively.

## Tech Stack

- Unity 6000.3.13f1
- C# scripting
- Unity Input System
- Universal Render Pipeline (URP)
- 2D physics and animation tools

## Project Structure

- `Assets/Scenes/` - playable scenes and test levels
- `Assets/Scripts/` - gameplay and controller logic
- `Assets/MetroidvaniaController/` - reusable platformer and combat systems
- `ProjectSettings/` - Unity project configuration
- `Packages/manifest.json` - package dependencies

## Getting Started  
1. Install Unity Hub and Unity 6000.3.13f1 (or a compatible Unity version supported by this project).
2. Clone the repository.
3. Open the folder in Unity Hub.
4. Load the main scene from `Assets/Scenes/`.
5. Press Play in the Unity editor to test the prototype.

## Controls

The project uses the Unity Input System and includes keyboard/gamepad-ready actions. Typical controls are:

- Move: `A/D` or `Left/Right Arrow`
- Jump: `Space` or `W/Up Arrow`
- Attack: configured in the Input Actions asset
- Throw projectile: configured in the Input Actions asset

## Current Status

This project is a functional gameplay prototype and a foundation for a larger action-platformer. It is intended for iteration and expansion with more content, polish, enemy variety, UI, and progression systems.

## Roadmap Ideas

- Add more enemy types and encounter patterns
- Expand the level design and vertical traversal routes
- Introduce checkpoints and health systems
- Add UI for health, stamina, and combat feedback
- Implement progression, sound polish, and visual effects

## License

This repository does not currently include a license file. If you plan to distribute or reuse this project publicly, add an appropriate open-source license before publishing.
