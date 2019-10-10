using UnityEngine;
using System.Collections;

namespace GroupJam.FWork
{
    public class CameraWork : MonoBehaviour    {
        public Transform targetTransform; // player head
        private Transform cameraTransform;
        private bool isFollowing;

        [SerializeField]
        private bool followOnStart = false;

        void Start()
        {
            // Start following the target if wanted.
            if (followOnStart)
            {
                OnStartFollowing();
            }
        }

        void LateUpdate()
        {
            // The transform target may not destroy on level load,
            // so we need to cover corner cases where the Main Camera
            // is different everytime we load a new scene, and reconnect when that happens
            if (cameraTransform == null && isFollowing)
            {
                OnStartFollowing();
            }

            // only follow is explicitly declared
            if (isFollowing)
            {
                FollowTarget();
            }
        }

        public void OnStartFollowing()
        {
            cameraTransform = Camera.main.transform;
            isFollowing = true;
        }

        void FollowTarget()
        {
            cameraTransform.position = targetTransform.position;
            cameraTransform.rotation = targetTransform.rotation;
        }

    }
}