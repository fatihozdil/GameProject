using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class AniCons : MonoBehaviour
{
    private Animator animator;
    public float health = 100f;
    public CharacterController controller;
    public bool isRoll = false;

    PhotonView photonView;
    void Start()
    {
        animator = GetComponent<Animator>();
        photonView = GetComponent<PhotonView>();
    }


    // Update is called once per frame
    void Update()
    {
        if (photonView.IsMine)
        {
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) && health > 0)
                animator.SetBool("walk", true);
            else
                animator.SetBool("walk", false);

            if (Input.GetKey(KeyCode.K) && health > 0)
            {
                health = 0;
                animator.SetBool("isDead", true);
            }
            else
                animator.SetBool("isDead", false);

            if (Input.GetButtonDown("Jump") && health > 0)
            {
                if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Male Jump Up") && !animator.GetCurrentAnimatorStateInfo(0).IsName("Male Fall") &&
                !animator.GetCurrentAnimatorStateInfo(0).IsName("Male Land"))
                    animator.SetBool("jump", true);
            }
            else
                animator.SetBool("jump", false);

            if (Input.GetKey(KeyCode.Q) && health > 0)
            {
                if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Male Roll") && !animator.GetCurrentAnimatorStateInfo(0).IsName("Male Idle 0"))
                {
                    animator.SetBool("roll", true);
                }
            }
            else
                animator.SetBool("roll", false);


        }

    }
}
