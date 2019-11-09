# Knocky Shooty

Knocky Shooty is a funfair themed virtual reality casual video game, developed for the Virtual and Augmented Reality (RVAU) class of the Integrated Master's Degree in Informatics and Computing Engineering (MIEIC) at the Faculty of Engineering of the University of Porto (FEUP).

- [Game Report](https://github.com/rendoir/feup-rvau/releases/download/v1.0/GameReport.pdf)
- [Game Executables](https://github.com/rendoir/feup-rvau/releases/download/v1.0/Executables.zip)
- [Gameplay Video](https://www.youtube.com/watch?v=nJDNo7s-Yao)

## Game Description
The game takes place in a funfair, a place of outside entertainment. We've decided to embrace this fun concept and implement two mini-games that are commonly found on these types of amusement parks: a shooter and a thrower.  
  
In the shooter arcade, you'll see a gun, a button and targets. You must pick up the gun and then, whenever you're ready, press the button to start the mini-game. This button is a physical button in the arcade that you press with your virtual hands. You'll be given a limited number of bullets and a small time period to shoot as many targets as you can. If you manage to hit all the targets you win the game!  
We have an increasing level of difficulty based on the movement of the targets and the adjustment of the time and bullets limit, showcased in three different arcades.

In the throwing tent, you'll find a board. Looking at it will start the mini-game and thus, a basket with balls and soda cans appear. Your objective is to pick up one of the limited number of balls, throw it and hit as many of the soda cans as you can. If you hit them all you are prompted to move on to the next level, and if you win all the levels in the tent you win the game. All prompts are given to the player through the board which the player interacts with via their gaze. The board also displays the number of cans the player has been able to knock down and the number of balls left to use, which is useful given that each ball can only be used once. 
We showcase this game with three different tents, each with two different levels, progressively increasing in difficulty. This aspect is controlled by the different layouts of cans combined with the amount of balls available to the player.


## Features
Knocky Shooty is a simple video game with various features developed with virtual reality in mind.  

#### Locomotion
- Touchpad Based Natural Navigation: This type of locomotion is the one commonly used in video games. You control the player by means of an axis with two degrees of freedom.
- Teleport Areas/Points Navigation: This type of locomotion is commonly used in virtual reality games since it's known to decrease motion sickness as it doesn't involve any visible translational motion. Instead the user navigates throughout the map by a point a teleport system to either specific points or areas in the map.  

#### Interfaces
- Diegetic Interface: The game world itself features elements that compose a seamless interface for the player to interact with (example: the button in the arcade). 
- Gaze Based Input: Looking at objects in the game world triggers an action (example: the board in the tent).

#### Spatial Audio
Spatial audio exploits the location of the audio source to further immerse the player and easily perceive where it comes from (example: attention-grabbing sounds in the arcade and tent so the player knows what to interact with).


## Technologies
Knocky Shooty was developed as a Virtual Reality video-game in Unity, using the SteamVR plugin.
The officially supported devices are the HTC Vive HMD and its controllers.

## Installation and Usage
To play the game, you can either run the pre-compiled executables or build it yourself and then run the built executable.

#### Build  
1. Clone or download the repository
2. Import the game to Unity
3. Build the game

##### Control Bindings
###### HTC Vive
- **Trigger:** For "throwable" objects, hold the trigger to hold the object and release it to throw it (used, for example, in throwing balls). On "holdable" objects, click the trigger to hold the object and subsequent clicks will trigger context-specific actions (for example, shooting a gun).
- **Menu:** Clicking this button toggles the locomotion method between natural navigation and teleport-based navigation.
- **Touchpad:** When natural navigation is enabled, the touchpad works by touch, moving the player in the expected axis direction. When teleport navigation is enabled, the touchpad works as a pointer, by pressing it, pointing to the teleport location and releasing to confirm the teleport.
