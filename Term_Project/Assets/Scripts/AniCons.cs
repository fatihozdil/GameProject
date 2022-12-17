using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class AniCons : MonoBehaviour
{
    private PlayerStats playerStats;
    private Animator animator;
    public CharacterController controller;
    public bool isRoll = false;

    PhotonView photonView;
    void Start()
    {
        playerStats = GetComponent<PlayerStats>();
        animator = GetComponent<Animator>();
        photonView = GetComponent<PhotonView>();
    }


    // Update is called once per frame
    void Update()
    {
        Debug.Log("anicons health" + playerStats.health);

        if (photonView.IsMine)
        {
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) && playerStats.health > 0)
                animator.SetBool("walk", true);
            else
                animator.SetBool("walk", false);
            //repeadet execution
            if (Input.GetKey(KeyCode.K) || playerStats.health <= 0 && playerStats.health >= -100)
            {
                animator.SetBool("isDead", true);
                if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.5f && !animator.IsInTransition(0))
                    playerStats.health -= 100;
            }
            else
                animator.SetBool("isDead", false);

            if (Input.GetButtonDown("Jump") && playerStats.health > 0)
            {
                if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Male Jump Up") && !animator.GetCurrentAnimatorStateInfo(0).IsName("Male Fall") &&
                !animator.GetCurrentAnimatorStateInfo(0).IsName("Male Land"))
                    animator.SetBool("jump", true);
            }
            else
                animator.SetBool("jump", false);

            if (Input.GetKey(KeyCode.Q) && playerStats.health > 0)
            {
                if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Male Roll") && !animator.GetCurrentAnimatorStateInfo(0).IsName("Male Idle 0"))
                {
                    animator.SetBool("roll", true);
                }
            }
            else
                animator.SetBool("roll", false);


        }
        else
        {
            if (playerStats.health <= 0 && playerStats.health >= -100)
            {
                animator.SetBool("isDead", true);
                if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.5f && !animator.IsInTransition(0))
                    playerStats.health -= 100;
            }
            else
                animator.SetBool("isDead", false);
        }

    }
}
