using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AniCons : MonoBehaviour
{
    private Animator animator;
    private float speed;

    void Start()
    {
        animator = GetComponent<Animator>();
    }
    

    // Update is called once per frame
    void Update() {
    if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        animator.SetBool("walk", true);
    else
        animator.SetBool("walk", false);
        

    if(Input.GetButtonDown("Jump"))
        animator.SetBool("jump", true);
    else
        animator.SetBool("jump", false);
        
    }
}
