using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    
    public Animator animator;
    public GameObject LoadingScene;
    public Image LoadBar;
    public GameObject MainBg;
    
    public void QuitButton(){
        Application.Quit();
    }
    
    public void SceneChangeButton(int sceneNumber){
        SceneManager.LoadScene(sceneNumber);
    }

    public void LoadPlayScene(int sceneNumber){
        StartCoroutine(LoadSceneAsync(sceneNumber));
    }

    IEnumerator LoadSceneAsync(int sceneNumber){
       
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneNumber);

        LoadingScene.SetActive(true);

        while(!operation.isDone){
            float value = Mathf.Clamp01(operation.progress / 0.9f);

            LoadBar.fillAmount = value;

            yield return null;
        }
    }
    public void CreateLobby(){        
        StartCoroutine(ExampleCoroutine());
    }

    IEnumerator ExampleCoroutine()
    {
        //Print the time of when the function is first called.
        animator.SetBool("create",true);
        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(1);

        //After we have waited 5 seconds print the time again.
        animator.SetBool("create",false);
    }
    


}
