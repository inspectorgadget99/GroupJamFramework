using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace GroupJam.FWork
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
            PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "PhotonPlayer"), new Vector3(0f, 1.1f, 0f), Quaternion.identity);
        }
    }
}