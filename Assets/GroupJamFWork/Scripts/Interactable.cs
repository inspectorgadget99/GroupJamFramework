using UnityEngine;

namespace GroupJam
{
    public abstract class Interactable : MonoBehaviour
    {
        // user currently using interactable
        protected PlayerInteraction currUser;
        
        // interactable's name
        protected string displayName = "Unnamed Object";

        public virtual void OnActivate(PlayerInteraction user) { }
    }
}