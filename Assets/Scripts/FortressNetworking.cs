using System.Collections;
using System.Collections.Generic;
using Photon.VR;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class FortressNetworking : MonoBehaviour
{
    public TMP_Text Status;
    public TMP_Text RoomCode;

    public string StartingRoomCode;

    public int NextGame;

    private const string lettersAndNumbers = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789"; // I did the math here and this would give us 2,176,782,336 diffrent room codes

    void Start()
    {
        NextGame = PlayerPrefs.GetInt("NextGame");

        if (NextGame == 1)
        {
            Status.text = "Defend";

            string randomCode = GenerateRandomCode(6);
            RoomCode.text = randomCode;
            StartingRoomCode = randomCode;
        }
        else if (NextGame == 0)
        {
            Status.text = "Payload";

            string randomCode = GenerateRandomCode(6);
            RoomCode.text = randomCode;
            StartingRoomCode = randomCode;
        }
    }

    void Update()
    {

    }

    public void OnStartClick()
    {
        if (NextGame == 2)
        {
            PhotonVRManager.JoinPrivateRoom(StartingRoomCode);
        }
        else if (NextGame == 0)
        {
            PhotonVRManager.JoinPrivateRoom(StartingRoomCode);
            PhotonVRManager.SwitchScenes(1);
        }
    }

    private string GenerateRandomCode(int length)
    {
        System.Random random = new System.Random();
        char[] code = new char[length];

        for (int i = 0; i < length; i++)
        {
            code[i] = lettersAndNumbers[random.Next(0, lettersAndNumbers.Length)];
        }

        return new string(code);
    }
}
