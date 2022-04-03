using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class NetworkManager : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
        ConnectToServer();
    }

    // Method to connect to Photon server
    // Photon AppId:0a5d50a7-3e1e-4a12-8f96-62db1f68566a
    void ConnectToServer()
    {
        PhotonNetwork.ConnectUsingSettings();
        Debug.Log("Connecting to Server...");
    }

    //function will be called when connected to master
    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to Server.");
        base.OnConnectedToMaster();

        //Room settings
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 4;
        roomOptions.IsVisible = true;
        roomOptions.IsOpen = true;

        //connect to the same room in order to share data b/t players
        PhotonNetwork.JoinOrCreateRoom("Room 1", roomOptions, TypedLobby.Default);
    }

    //function is called when player successfully joined a room
    public override void OnJoinedRoom()
    {
        Debug.Log("Joined a Room");
        base.OnJoinedRoom();
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.Log("New Player has joined!");
        base.OnPlayerEnteredRoom(newPlayer);
    }
}
