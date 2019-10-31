using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace GroupJam
{
    public class GameSetupController : MonoBehaviour


    {
        // This script will be added to any multiplayer scene
        void Start()
        {
            CreatePlayer(); //Create a networked player object for each player that loads into the multiplayer scenes.
        }
        private void CreatePlayer()
        {
            Debug.Log("Creating Player");
            PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "PhotonPlayer"), new Vector3(59f, 2.8f, -81f), Quaternion.identity);
        }
    }
}