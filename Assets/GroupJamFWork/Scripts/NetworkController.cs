using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GroupJam.FWork
{
    public class NetworkController : MonoBehaviourPunCallbacks
    {
        void Start()
        {
            PhotonNetwork.ConnectUsingSettings();
        }

        public override void OnConnectedToMaster()
        {
            Debug.Log("Connected to region: " + PhotonNetwork.CloudRegion);
        }
    }
}