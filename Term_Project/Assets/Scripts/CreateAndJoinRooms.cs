using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using TMPro;
public class CreateAndJoinRooms : MonoBehaviourPunCallbacks
{
    public TMP_InputField playerName;
    public static string name;
    public TMP_InputField createInput;
    public TMP_InputField joinInput;
    public GameObject voiceChatManager;
    private VoiceChatManager voiceChatManagerScript;

    // Start is called before the first frame update
    void Start()
    {
        voiceChatManagerScript = voiceChatManager.GetComponent<VoiceChatManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    // create photon room
    public void CreateRoom()
    {
        PhotonNetwork.CreateRoom(createInput.text);
        name = playerName.text;
    }

    // joint to the created photon room
    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom(joinInput.text);
        name = playerName.text;
    }


    public override void OnJoinedRoom()
    {
        // get related room name
        voiceChatManagerScript.LoadAssetData(PhotonNetwork.CurrentRoom.Name);

        // init rtc engine
        voiceChatManagerScript.InitRtcEngine();

        voiceChatManagerScript.SetBasicConfiguration();

        // get audio devices;
        voiceChatManagerScript.GetAudioPlaybackDevice();

        // join channel
        voiceChatManagerScript.JoinChannel();
        // load the game scene
        PhotonNetwork.LoadLevel("Arena");
    }



}
