using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;

    public float speed = 0.8f;
    private float tempspeed;

    public float propel = 4f;

    public float gravityValue = -9.81f;

    public float jumpHeight = 1.0f;

    public float turnSmoothTime = 0.1f;

    float turnSmoothVelocity;
    Vector3 jumpv;
    AniCons aniCons ; 

    void Start(){
        aniCons = GetComponent<AniCons>();
        tempspeed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        if(aniCons.health > 0){
            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");
            Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

            if (controller.isGrounded&&speed!=0)
                speed = tempspeed;

            if(Input.GetButtonDown("Jump") && controller.isGrounded)
            {
                jumpv = new Vector3(0f, 0f, 0f);
                jumpv.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
                speed = speed * propel;
            }
            

            jumpv.y += gravityValue * Time.deltaTime;

            if(direction.magnitude >= 0.1f ) 
            {
                float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
                transform.rotation = Quaternion.Euler(0f, angle, 0f);


                Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

                controller.Move(jumpv * Time.deltaTime);
                controller.Move(moveDir.normalized * speed * Time.deltaTime);
            }
            else 
                controller.Move(jumpv * Time.deltaTime);
            
        }
    }
}
