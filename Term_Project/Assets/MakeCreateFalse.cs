using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeCreateFalse : StateMachineBehaviour
{
    public Animator animator;

    public void CreateLobbyFalse(){

        animator.SetBool("create",false);

    }
    void Start(){
        CreateLobbyFalse();
    }
}
