using UnityEngine;

namespace GroupJam
{
    public class ButtonExample : Interactable // all objects that can be clicked must inherit from Interactable
    {
        // if displayName is not assigned, the game will read it as "Unknown Interactable"
        private void Start()
        {
            displayName = "My Button";
        }

        // code to run when clicked by a player
        public override void OnActivate(PlayerInteraction user)
        {
            // check if the object is in use first
            if (currUser == null)
            {
                // update who is using the item so no one else can use it while the code is running
                currUser = user;

                // Do stuff
                Debug.Log(displayName + " was clicked");

                // mark the object as usable again
                currUser = null;
            }
            else
            {
                // code for when object is already in use
                Debug.Log("Sorry, " + currUser.GetName() + " is using this right now.");
            }

        }
    }
}