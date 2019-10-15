# GroupJamFramework
STEPS FOR USE
1.	Import Photon 2 PUN from the asset store 
    https://assetstore.unity.com/packages/tools/network/pun-2-free-119922

2.	Clone the repo into your Assets folder (so you have “Assets/GroupJamFramework”)

3.	Add an empty game object to your own scene, call it GameSetupController or something similar (name is not important)
    attach the GameSetupController script to it (GroupJamFramework/Scripts)

4.	Make sure your camera is tagged as MainCamera.
    Don’t have any weird scripts on the camera as Photon will be controlling it.

5.	Change the project build settings to:
    Scene Index 0: StartMenuScene (GroupJamFramework/Scenes)
    Scene Index 1: Your scene to load into on host/join

6.	Add a new script based on the ButtonExample script (GroupJamFramework/Scripts) to
    any interactable objects in the scene and edit it to your liking.
    This will allow each player to interact with the object by clicking on it 

7.	To test, load up the StartMenuScene (GroupJamFramework/Scenes) and run it.
