using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class Combat : MonoBehaviourPunCallbacks, IPunObservable
{
    private bool dragging = false;
    private Animator animator;
    private float xDragStart;
    private float yDragStart;
    private float xDragEnd = 0f;
    private float yDragEnd = 0f;
    public Collider coll;
    private PlayerStats pt;
    bool speedChanged;
    float slowSpeed;

    private bool up;
    private bool down;
    private bool left;
    private bool right;
    private bool shieldUp;


    PhotonView photonView;
    //public CinemachineFreeLook freeLook;
    void Start()
    {
        animator = GetComponent<Animator>();
        coll.enabled = false;
        pt=GetComponent<PlayerStats>();
        speedChanged=false;
        slowSpeed=animator.speed*0.5f;
        Debug.Log(animator.speed);
        Debug.Log(slowSpeed);

        photonView = GetComponent<PhotonView>();
        up = false;
        down = false;
        left = false;
        right = false;
        shieldUp = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (photonView.IsMine)
        {
            if (Input.GetMouseButton(1))
            {
                shieldUp = true;
                animator.SetBool("shieldUp", shieldUp);
                animator.speed=slowSpeed;
                Debug.Log(animator.speed);
            }
            else
            {
                shieldUp = false;
                animator.SetBool("shieldUp", shieldUp);
                animator.speed=pt.getSpeed();
            }

            if (Input.GetMouseButton(0))
            {
                //cinemachineFL.m_XAxis.m_MaxSpeed = 0.0f;
                //cinemachineFL.m_YAxis.m_MaxSpeed = 0.0f;

                //Make sure this part will be called only one time at the start of dragging
                if (!dragging)
                {
                    dragging = true;
                    //Debug.Log("Start");
                    //Take initial position of cursor
                    xDragStart = Input.mousePosition.x;
                    yDragStart = Input.mousePosition.y;
                }
            }
            else
            {
                if (dragging)
                {
                    //Calculate dragging after the mouse button released
                    xDragEnd = xDragStart - Input.mousePosition.x;
                    yDragEnd = yDragStart - Input.mousePosition.y;
                    dragging = false;
                }
            }
            //Determine directions
            if (xDragEnd > 0.5f && Mathf.Abs(yDragEnd) < Mathf.Abs(xDragEnd))
            {
                coll.enabled = true;
                //Debug.Log("left attack");
                left = true;
                animator.SetBool("left", left);
                xDragEnd = 0f;
                yDragEnd = 0f;
            }
            else if (xDragEnd < -0.5f && Mathf.Abs(yDragEnd) < Mathf.Abs(xDragEnd))
            {
                coll.enabled = true;
                //Debug.Log("right attack");
                right = true;
                animator.SetBool("right", right);
                xDragEnd = 0f;
                yDragEnd = 0f;
            }
            else if (yDragEnd > 0.5f && Mathf.Abs(xDragEnd) < Mathf.Abs(yDragEnd))
            {
                coll.enabled = true;
                //Debug.Log("down attack");
                down = true;
                animator.SetBool("down", down);
                yDragEnd = 0f;
                xDragEnd = 0f;
            }
            else if (yDragEnd < -0.5f && Mathf.Abs(xDragEnd) < Mathf.Abs(yDragEnd))
            {
                coll.enabled = true;
                //Debug.Log("up attack");
                up = true;
                animator.SetBool("up", up);
                yDragEnd = 0f;
                xDragEnd = 0f;
            }
            else
            {
                left = false;
                right = false;
                down = false;
                up = false;
                //Set animations false
                animator.SetBool("left", left);
                animator.SetBool("right", right);
                animator.SetBool("down", down);
                animator.SetBool("up", up);
                if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1.5f && !animator.IsInTransition(0))
                {
                    coll.enabled = false;
                }
            }

        }
        else
        {
            //Debug.Log("left" + left);
            //Debug.Log("right" + right);
            //Debug.Log("down" + down);
            //Debug.Log("up" + up);
            //Debug.Log("shieldUp" + shieldUp);
            //animator.SetBool("left", left);
            //animator.SetBool("right", right);
            //animator.SetBool("down", down);
            //animator.SetBool("up", up);
            //Debug.Log(shieldUp);
            //animator.SetBool("shieldUp", shieldUp);


        }
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            // We own this player: send the others our data
            //stream.SendNext(left);
            //stream.SendNext(right);
            //stream.SendNext(down);
            //stream.SendNext(up);
            //stream.SendNext(shieldUp);

        }
        else
        {
            // Network player, receive data
            //left = (bool)stream.ReceiveNext();
            //right = (bool)stream.ReceiveNext();
            //down = (bool)stream.ReceiveNext();
            //up = (bool)stream.ReceiveNext();
            //(bool)stream.ReceiveNext();
            //bool test = (bool)stream.ReceiveNext();
            //Debug.Log(test);
            //animator.SetBool("shieldUp", test);

            //shieldUp = (bool)stream.ReceiveNext();


        }
    }
}

