using Photon.Pun;
using UnityEngine;
using System.Collections;

namespace GroupJam.FWork
{
    public class PlayerLook : MonoBehaviour
    {
        private Transform headTransform;
        public Transform playerTransform;
        private float xAxisClamp = 0.0f;

        [SerializeField]
        private float mouseSensitivityX = 5f;

        [SerializeField]
        private float mouseSensitivityY = 2f;

        [SerializeField]
        private bool invertMouse = false;

        private PhotonView photonView;

        void Awake()
        {
            photonView = GetComponentInParent<PhotonView>();
            headTransform = GetComponent<Transform>();
        }

        void LateUpdate()
        {
            if (photonView.IsMine)
            {
                HandleCameraMovement();
            }
        }

        void HandleCameraMovement()
        {
            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = Input.GetAxis("Mouse Y");

            float rotAmountX = mouseX * mouseSensitivityX;
            float rotAmountY = mouseY * mouseSensitivityY;

            xAxisClamp -= rotAmountY;

            Vector3 targetRotHead = headTransform.rotation.eulerAngles;
            Vector3 targetRotBody = playerTransform.rotation.eulerAngles;

            if (invertMouse)
            {
                targetRotHead.x += rotAmountY;
            }
            else
            {
                targetRotHead.x -= rotAmountY;
            }

            targetRotHead.z = 0;
            targetRotBody.y += rotAmountX;

            if (xAxisClamp > 90)
            {
                xAxisClamp = 90;
                targetRotHead.x = 90;
            }
            else if (xAxisClamp < -90)
            {
                xAxisClamp = -90;
                targetRotHead.x = 270;
            }

            headTransform.rotation = Quaternion.Euler(targetRotHead);
            playerTransform.rotation = Quaternion.Euler(targetRotBody);
        }
    }
}