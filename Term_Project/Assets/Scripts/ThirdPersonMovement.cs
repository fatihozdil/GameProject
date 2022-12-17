using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class ThirdPersonMovement : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;
    public float playerSpeed;
    private float tempspeed;
    public float propel = 4f;
    public float gravityValue = -9.81f;
    public float jumpHeight = 1.0f;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;
    Vector3 jumpv;
    AniCons aniCons;
    private PlayerStats playerStats;
    private Animator animator;
    private float propel2 = 0.2f;

    PhotonView photonView;

    void Start()
    {
        animator = GetComponent<Animator>();
        playerStats = GetComponent<PlayerStats>();
        playerSpeed = playerStats.getSpeed();
        tempspeed = playerSpeed;
        photonView = GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
        if (photonView.IsMine && playerStats.health > 0)
        {
            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");
            Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;
            //Return playerSpeed to the old value after landing so player won't get faster with every jump
            
            if(animator.GetCurrentAnimatorStateInfo(0).IsName("shieldUp")){
                playerSpeed *= propel2;
            }
                     
            
            else if (controller.isGrounded)
                playerSpeed = tempspeed;

            


            if (Input.GetButtonDown("Jump") && controller.isGrounded)
            {
                jumpv = new Vector3(0f, 0f, 0f);
                jumpv.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
                //Increase playerSpeed the propel the player forward
                playerSpeed = playerSpeed * propel;
            }


            jumpv.y += gravityValue * Time.deltaTime;

            if (direction.magnitude >= 0.1f)
            {
                float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
                transform.rotation = Quaternion.Euler(0f, angle, 0f);


                Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
                //Jump while moving
                controller.Move(jumpv * Time.deltaTime);
                controller.Move(moveDir.normalized * playerSpeed * Time.deltaTime);
            }
            else
                controller.Move(jumpv * Time.deltaTime); //Jump while static

        }
    }
}
