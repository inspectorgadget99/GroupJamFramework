using Photon.Pun;
using UnityEngine;
using System.Collections;

namespace GroupJam
{
    public class PlayerInteraction : MonoBehaviour
    {
        [SerializeField]
        private float interactDistance = 1000.0f;

        private PhotonView photonView;
        private PlayerData pData;
        private string nickname;

        void Awake()
        {
            photonView = GetComponentInParent<PhotonView>();
            pData = GetComponent<PlayerData>();
            nickname = PhotonNetwork.NickName;
        }

        void LateUpdate()
        {
            nickname = PhotonNetwork.NickName;
            if (photonView.IsMine)
            {
                HandleClick();
            }
        }

        void HandleClick()
        {
            Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
            RaycastHit rayHit;
            if (Physics.Raycast(ray, out rayHit, interactDistance))
            {
                Interactable i = rayHit.collider.GetComponent<Interactable>();
                if (i != null)
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        i.OnActivate(this);
                    }
                }
            }
        }

        public string GetName()
        {
            return pData.GetName();
        }
    }
}