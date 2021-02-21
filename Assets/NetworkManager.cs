using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkManager : MonoBehaviourPunCallbacks
{
    public byte maxPlayer;

    private bool isConnectedToMasterServer = false;

    private void Awake()
    {
        PhotonNetwork.ConnectUsingSettings();
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to master");
        isConnectedToMasterServer = true;
        UIController.instance.SetStatus("Connected");
    }

    public void JoinRandomRoom()
    {
        if (!isConnectedToMasterServer)
        {
            Debug.Log("Not yet connected to master server");
            return;
        }
        PhotonNetwork.JoinRandomRoom();
        Debug.Log("Joining random room");
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Successfully joined a room " + PhotonNetwork.CurrentRoom.Name);
        UIController.instance.SetStatus(PhotonNetwork.CurrentRoom.Name);
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("No room existed yet, creating new one");
        CreateRoom();
    }


    public void CreateRoom()
    {
        RoomOptions roomOption = new RoomOptions { MaxPlayers = maxPlayer };
        int randomNumber = Random.Range(0, 999);
        PhotonNetwork.CreateRoom("Room" + randomNumber, roomOption);
        Debug.Log("Creating Room" + randomNumber);
    }
    public override void OnCreatedRoom()
    {
        Debug.Log("Successfully created new room " + PhotonNetwork.CurrentRoom.Name);
    }
}
