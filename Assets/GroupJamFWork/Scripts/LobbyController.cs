using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GroupJam
{
    public class LobbyController : MonoBehaviourPunCallbacks
    {
        [SerializeField]
        private GameObject loadingText; //text shown while connecting to Photon servers.
        [SerializeField]
        private GameObject hostSessionButton; //button used for joining a game.
        [SerializeField]
        private GameObject joinSessionButton; //button used for joining a game.
        [SerializeField]
        private GameObject cancelJoinButton; //button used to stop searching for a game to join.
        [SerializeField]
        private int RoomSize; //Manual set the number of player in the room at one time.
        [SerializeField]
        private int maxJoinAttempts = 100; // number of times to attempt to join a room before auto cancelling

        private int joinAttemptCount;
        private bool cancelRequested = false;

        public override void OnConnectedToMaster() //Callback function for when the first connection is established successfully.
        {
            PhotonNetwork.AutomaticallySyncScene = true; //Makes it so whatever scene the master client has loaded is the scene all other clients will load
            // hide loading text once connected
            loadingText.SetActive(false);
            ResetScene();
        }
        void ResetScene()
        {
            joinAttemptCount = 0;
            cancelJoinButton.SetActive(false);
            hostSessionButton.SetActive(true);
            joinSessionButton.SetActive(true);
        }

        public void HostSession() //Paired to the HostSession button
        {
            // hide other buttons
            joinSessionButton.SetActive(false);
            cancelJoinButton.SetActive(false);
            CreateRoom();
        }
        public void JoinSession() //Paired to the JoinSession button
        {
            // hide other buttons
            hostSessionButton.SetActive(false);
            // hide this button
            joinSessionButton.SetActive(false);
            // show cancel button
            cancelJoinButton.SetActive(true);
            PhotonNetwork.JoinRandomRoom(); //First tries to join an existing room
        }
        public override void OnJoinRandomFailed(short returnCode, string message) //Callback function for if we fail to join a rooom
        {
            if (!cancelRequested)
            {
                if (joinAttemptCount <= maxJoinAttempts)
                {
                    joinAttemptCount++;
                    Debug.Log("Failed to join a room - Attempt: " + joinAttemptCount);
                    PhotonNetwork.JoinRandomRoom(); // try again
                }
                else
                {
                    Debug.Log("Reached max join attempts");
                    ResetScene();
                }
            }
            else
            {
                // user cancelled
                // reset cancel flag
                cancelRequested = false;
            }
        }
        void CreateRoom() //trying to create our own room
        {
            Debug.Log("Creating room now");
            int randomRoomNumber = Random.Range(0, 10000); //creating a random name for the room
            RoomOptions roomOps = new RoomOptions() { IsVisible = true, IsOpen = true, MaxPlayers = (byte)RoomSize };
            PhotonNetwork.CreateRoom("Room" + randomRoomNumber, roomOps); //attempting to create a new room
            Debug.Log(randomRoomNumber);
        }
        public override void OnCreateRoomFailed(short returnCode, string message) //callback function for if we fail to create a room. Most likely fail because room name was taken.
        {
            Debug.Log("Failed to create room... trying again");
            CreateRoom(); //Retrying to create a new room with a different name.
        }
        public void CancelJoin() //Paired to the cancel button. Used to stop looking for a room to join.
        {
            if (PhotonNetwork.InRoom)
            {
                PhotonNetwork.LeaveRoom();
            }
            Debug.Log("Player cancelled searching for a room");
            cancelRequested = true;
            ResetScene();
        }
    }
}