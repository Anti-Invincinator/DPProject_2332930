## Introduction

This project is a Unity-based game that incorporates various gameplay mechanics and systems, leveraging several design patterns to ensure code maintainability, reusability, and scalability. The project includes player control, health management, enemy spawning, high score tracking, logging, and visual effects, all structured to follow best programming practices.

Made for Final Project for Design Patterns 

## Features

- **Player Control**: The player can move, aim, and shoot arrows, with mechanics for drawing the bow and varying arrow speed based on draw time.
- **Health Management**: The player's health is tracked and updated, with visual feedback for damage and health changes.
- **Enemy AI and Spawning**: Enemies spawn at set intervals and pursue the player, with logic for attacking and taking damage.
- **High Score System**: Tracks and displays high scores, adapting legacy data and saving/loading scores from persistent storage.
- **Logging**: Enhanced logging for various game events, facilitating debugging and tracking of game states.
- **Visual Effects**: Screen shaking and damage flash effects to enhance the player experience.

## Design Patterns

### Singleton Pattern

- **PlayerController**: Ensures that only one instance of the player controller exists, providing a global point of access.
- **ScreenShaker**: Manages screen shake effects to enhance visual feedback, ensuring a single instance controls the effect.

### Observer Pattern

- **IObserver** Interface: Facilitates the Observer pattern, allowing objects to be notified of state changes.
- **GameManager**: Observes player health and updates the game state accordingly.
- **HealthDisplay**: Updates the UI to reflect changes in player health.
- **PlayerHealth**: Notifies observers when the player's health changes.
- **HealthSystem**: Manages health and notifies observers of changes.

### Command Pattern

- **ICommand** Interface: Encapsulates a request as an object, allowing for parameterization and queuing of requests.
- **RetryCommand**: Implements the command to restart the game, resetting player health and game state.

### Adapter Pattern

- **HighScoreAdapter**: Adapts old player data to the new high score system interface, allowing legacy data integration.

### Object Pooling Pattern

- **ObjectPooler**: Manages a pool of reusable objects, such as arrows and enemies, to optimize performance by minimizing instantiation and destruction.

### MVC Pattern

- **PlayerScore**, **HealthDisplay**, **EnemySpawner**: Separates the data handling, user interface, and control logic to enhance modularity and maintainability.

## SOLID Principles

### Single Responsibility Principle (SRP)

Each class has a single responsibility and encapsulates only related functionality.

### Open/Closed Principle (OCP)

Classes are open for extension but closed for modification. New functionality is added by extending existing classes rather than modifying them.

### Liskov Substitution Principle (LSP)

Subclasses or derived classes should be substitutable for their base classes without altering the correctness of the program.

### Interface Segregation Principle (ISP)

Clients should not be forced to depend on interfaces they do not use. Instead of one large interface, multiple smaller, specific interfaces are preferred.

### Dependency Inversion Principle (DIP)

High-level modules should not depend on low-level modules. Both should depend on abstractions. Abstractions should not depend on details. Details should depend on abstractions.

## Classes and Relationships

### Interfaces

1. **IObserver**
    - `void UpdateObserver()`
    - Implemented by: **GameManager**, **HealthDisplay**, **PlayerHealth**, **HealthSystem**

2. **ICommand**
    - `void Execute()`
    - Implemented by: **RetryCommand**

3. **IHighScore**
    - `string PlayerName { get; }`
    - `int Score { get; }`
    - `void DisplayScore()`
    - Implemented by: **HighScoreAdapter**

### Key Classes

1. **GameManager**
    - Manages the game state and observes player health.
2. **EnhancedLogger**
    - Handles logging of various game events.
3. **PlayerHealth**
    - Manages the player's health and notifies observers.
4. **PlayerScore**
    - Tracks and updates the player's score.
5. **ObjectPooler**
    - Manages a pool of reusable game objects.
6. **ScreenShaker**
    - Manages screen shake effects to enhance visual feedback.
7. **Enemy**
    - Represents an enemy in the game, including its behavior and interactions.
8. **EnemySpawner**
    - Spawns enemies at set intervals.
9. **HealthDisplay**
    - Updates the UI to reflect the player's health.
10. **KnifePickup**
    - Manages the pickup of knife items.
11. **HealthSystem**
    - Manages health and notifies observers of changes.
12. **Quiver**
    - Manages the player's arrow inventory.
13. **Arrow**
    - Represents an arrow in the game, including its behavior and interactions.
14. **PlayerController**
    - Manages player movement, aiming, and shooting.
15. **HighScoreData**
    - Represents high score data.
16. **OldPlayerData**
    - Represents legacy player data.
17. **HighScoreAdapter**
    - Adapts old player data to the new high score system.
18. **HighScoreSystem**
    - Manages high scores, including saving and loading from persistent storage.

## Getting Started

### Prerequisites

- Unity 2020.3 or later

### Installation

1. Clone the repository:
    ```sh
    git clone https://github.com/Anti-Invincinator/DPProject_2332930.git
    ```
2. Open the project in Unity.

### Usage

- Implement game logic in the `GameManager` and other manager classes.
- Use the `PlayerController` for handling player input and movement.
- Utilize the `EnemySpawner` to manage enemy spawning.
- Extend the `HighScoreSystem` to handle player scores.

## Acknowledgments

- Unity Documentation
- https://gameprogrammingpatterns.com/contents.html

