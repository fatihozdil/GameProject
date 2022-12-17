using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class InGameMenu : MonoBehaviour
{
    public GameObject inGameObject;
    public PlayerStats playerStats;
    private bool isOpen;

    void Start()
    {
        isOpen = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            closeTab();
        }        
        inGameObject.SetActive(isOpen);
    }

    public void closeTab(){
        isOpen = !isOpen;
    }

    public void BackToMenu(){
        SceneManager.LoadScene(0);
        PhotonNetwork.Disconnect();
    }
    public void BackToLobby(){
        SceneManager.LoadScene(2);
    }
}
