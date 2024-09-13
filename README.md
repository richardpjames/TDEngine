# 2D Engine for Top Down Games

This project is inspired by the Top Down Engine by More Mountains. It is a collection of modular scripts 
which I have created to make it easier to get up and running quickly with a 2D top down game in Unity.

# Requirements

For this package to work correctly, both Cinemachine and the new Unity Input System must be present.

# Scripts
## Player and Character Controller

Assign the player controller to playable characters and the character controller to NPCs etc. This provides
base functionality for any character in the game and sets sensible defaults for the top down view (such as
disabling rotation and gravity in the rigidbody). This component is required on an object for all other
character and player components to work correctly.

## Player Movement

Takes movement instructions from WASD, arrow keys or controller input and moves the character a set speed
which is taken as an input to the component.

## Player and Character Animator

Determines the state of the player or character and sets a number of booleans within the specified animator:
 - Running - set to true when the player/character is moving
 - Idle - set to true when the player/character is still
	
# Effects

## Effects Container

Allows grouping of multiple effects to be played at the same time from a single call.

## Screen Shake

Creates a screen shake effect using the Cinemachine 2D camera.

# Demo

A demo scene is also included which shows all of the features and components in the package.