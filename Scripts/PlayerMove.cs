using UnityEngine;
using Photon.Pun;
using System.Collections;

namespace GroupJam
{
    public class PlayerMove : MonoBehaviour
    {

        [SerializeField]
        private float walkSpeed = 4f;
        private CameraWork cameraWork;
        private CharacterController charControl;
        private PhotonView photonView;



        void Awake()
        {
            cameraWork = GetComponent<CameraWork>();
            photonView = GetComponent<PhotonView>();
            charControl = GetComponent<CharacterController>();
        }

        private void Start()
        {
            if (photonView.IsMine)
            {
                cameraWork.OnStartFollowing();
            }
        }

            {
            }
        }



                void MovePlayer()
                {
                    float horiz = Input.GetAxis("Horizontal");
                    float vert = Input.GetAxis("Vertical");

                    Vector3 moveDirSide = transform.right * horiz * walkSpeed;
                    Vector3 moveDirForward = transform.forward * vert * walkSpeed;


                    charControl.SimpleMove(moveDirSide);
                    charControl.SimpleMove(moveDirForward);
                }
            }
        }
    }
}