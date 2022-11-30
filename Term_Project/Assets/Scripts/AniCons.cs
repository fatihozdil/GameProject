using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class AniCons : MonoBehaviour
{
    private Animator animator;
    public float health = 100f;

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
            {

                animator.SetBool("walk", true);
                
            }

            else if (Input.GetKey(KeyCode.K))
            {
                health = 0;
                animator.SetBool("isDead", true);
            }

            else if (Input.GetButtonDown("Jump"))
            {
                animator.SetBool("jump", true);
            }
            else
            {
                animator.SetBool("walk", false);
                animator.SetBool("isDead", false);
                animator.SetBool("jump", false);

            }
        }
    
    }
}
