using Photon.Pun;
using UnityEngine;
using System.Collections;

namespace GroupJam
{
    public class LockCursor : MonoBehaviour
    {
        private PhotonView photonView;

        void Awake()
        {
            photonView = GetComponentInParent<PhotonView>();
        }

        void Update()
        {
            if (photonView.IsMine)
            {
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
    }
}