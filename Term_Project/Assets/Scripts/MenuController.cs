using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{

    public GameObject MainBg;


    public void PlayButton(){
        SceneManager.LoadScene(1);   
    }

    public void QuitButton(){
        Application.Quit();
    }

    public void ChangeBack(){
        MainBg.SetActive(false);
    }
    
    public void MenuButton(){
        SceneManager.LoadScene(0);
    }
    public void LobbyButton(){
        SceneManager.LoadScene(3);
    }

}
