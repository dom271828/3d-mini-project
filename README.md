# Mini-Project 3 - 3D Game

## Play Link

<https://play.unity.com/en/games/9718e37f-c781-431b-9447-3e190f61509b/royal-run>

## Asset kit used

<https://kenney.nl/assets/survival-kit>

## Concept

Avoid obstacles and collect as many points as possible in this timed dodged avoidance game!

Extends pre-made Dodge Avoidance game

## Baseline Requirements

### Input

Press A and D to go left and right, and W to dash forward. Esc to Pause and Space to reload when game over.

No bugs to my knowledge, PlayerController enabled/disabled according to pause or game over states

### Game Objects

Randomized Chunks that can contain: fences that slow movement, apple/bottle powerups, and checkpoints that increase timer time. Obstacles fly at the player, randomized types/sizes, and colliders

Prefabs are used for chunks with child prefabs for objects that appear within them (such as powerups and fences). This way, each run is different with different chances for powerups and coins to appear.

### State Management

Win Condition: Get as many points as you can before the timer runs out! Points can be gained by collecting coins, each coin is 100 points.

Score and Timer implemented through stored variables in respective files.

Restart system implemented through SceneManager when space is pressed during Game Over. GameOver variable used to track state.

### Audio/Visual Feedback

Fog particles used for background, as well as surrounding powerups as indicators.

Audio Feedback implemented: Background music as well as when obstacles spawn

Score, Timer changes reflect in UI as well as invincibility and game over statuses.

### UI

TextMesh UI dynamically tracks score and timer, game over text shows when timer runs out

Tracks space input when game over status is present

### Code Requirements

Extensions added with appropriate functions/methods implemented within scripts.

Update() calls functions rather than direct if statements, allowing for easy alterations if necessary.

## Extensions

### Difficulty Scaling

Perhaps the most simple extension I implemented. This increases the amount of speed the player loses when hit by an obstacle every 10 seconds that passes. Works in tandem with invincibility effect so default speed is saved. I made this scaling 0.25f but it is flexible for potential difficulty options.

### Pause Menu

Added a PauseManager which effectively pauses the game when Esc is clicked. Timescale set to 0.1 and playerController is effectively disabled. Added a TextMesh obj as well. This input is also disabled when the gameOver status is true, so no room for unnessary activation.

### Bottle Powerup

Definitely the most in depth extension. This powerup takes the player collision script and alters the adjust movement speed variable (similar to the scaling option I had), and sets it to zero for an allotted amount of time. It uses the pickup abstract class, and calls the collision script within that class similar to how the apple calls the level generator. I also imported an outside asset (credited) which was a fairly smooth process, then did prefab work to get it into the game. There are a couple new methods in the Collision class specifically for this process, simply to decrease clutter in the Bottle class (Also added script within the "chunk" prefab to spawn bottles in similar fashion to other powerups). Last but not least, since I felt a visual indicator was needed to help the player, so I added another textmesh object which only activates when the player is under the effect of the bottle.

### Other small extensions, mostly filling in for baseline reqs

Restart system, particle effects for items

## Challenges etc

Definitely the biggest obstacle I had with this project broadly was coming up with what specific extensions to implement, since many of them were already in the game. I knew for sure I wanted a new power up, the other stuff came later with deliberation to what was essential to add.

The big challenge I had with this though was the bottle. This one took me a WHILE and at points had me confused or flabbergasted at what I had to do. I thought it was simple as adding another power up, making some methods, dragging the collision handler into a serialized field, but no. There were a lot of core mechanics I needed to change, including how the level finds different scripts to call. This took hours of backtracking errors and making alterations, it was a big process but I eventually got everything working correctly.

It was also hard to know how the relationships between some classes were established, there was a lot I could've done had I known how to access stuff like lighting or ven more in depth camera effects.
