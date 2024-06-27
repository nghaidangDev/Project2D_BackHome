using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using TMPro;

public class CreateAndJoinGame : MonoBehaviourPunCallbacks
{
    public TMP_InputField inputField_Create;
    public TMP_InputField inputField_Join;

    public void CreateRoom()
    {
        PhotonNetwork.CreateRoom(inputField_Create.text);
    }

    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom(inputField_Join.text);
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("Level_01");
    }
}
