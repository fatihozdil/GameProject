using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AniCons : MonoBehaviour
{
    private Animator animator;
    public float health = 100f;
    public CharacterController controller;

    void Start()
    {
        animator = GetComponent<Animator>();
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) && health > 0)
            animator.SetBool("walk", true);
        else
            animator.SetBool("walk", false);

        if (Input.GetKey(KeyCode.K)&&health>0)
        {
            health = 0;
            animator.SetBool("isDead", true);
        }
        else
            animator.SetBool("isDead", false);

        if (Input.GetButtonDown("Jump")&&health>0)
            animator.SetBool("jump", true);
        else
            animator.SetBool("jump", false);
            
            if(Input.GetKey(KeyCode.Q)&& health>0){
                animator.SetBool("roll",true);
            }
            else
            animator.SetBool("roll",false);

    }
}
