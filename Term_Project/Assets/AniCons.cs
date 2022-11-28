using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AniCons : MonoBehaviour
{
    private Animator animator;
    public float health=100f;
     ThirdPersonMovement tps;
    void Start()
    {
        animator = GetComponent<Animator>();
        tps=GetComponent<ThirdPersonMovement>();

    }
    

    // Update is called once per frame
    void Update() {
        if(Input.GetKey(KeyCode.K)){
            health=0;
        }
    if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)&& health>0)
        animator.SetBool("walk", true);
    else
        animator.SetBool("walk", false);
    if(health<=0)
        animator.SetBool("death",true); 

    }
}
