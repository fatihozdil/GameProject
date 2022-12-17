using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{

    void Start(){
    }
    public void ButtonAction(int num){
        SceneManager.LoadScene(num);
    }

    public void QuitButton(){
        Application.Quit();
    }
    public void Disconnect(){
        PhotonNetwork.Disconnect();
    }

}
