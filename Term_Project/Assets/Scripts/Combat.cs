using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : MonoBehaviour
{
    private bool dragging = false;
    private Animator animator;
    private float xDragStart;
    private float yDragStart;
    private float xDragEnd = 0f;
    private float yDragEnd = 0f;
    public Collider coll;
    //public CinemachineFreeLook freeLook;
    void Start()
    {
       animator = GetComponent<Animator>(); 
       coll.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if( Input.GetMouseButton(0) )
        {
            //cinemachineFL.m_XAxis.m_MaxSpeed = 0.0f;
            //cinemachineFL.m_YAxis.m_MaxSpeed = 0.0f;

            //Make sure this part will be called only one time at the start of dragging
            if( !dragging )
            {
                dragging = true;
                Debug.Log("Start");
                //Take initial position of cursor
                xDragStart = Input.mousePosition.x;
                yDragStart = Input.mousePosition.y;
            }
        }
        else {
            if(dragging) {
                //Calculate dragging after the mouse button released
                xDragEnd = xDragStart - Input.mousePosition.x;
                yDragEnd = yDragStart - Input.mousePosition.y;
                dragging = false;
            }
        }
        //Determine directions
        if (xDragEnd > 0.5f && Mathf.Abs(yDragEnd) < Mathf.Abs(xDragEnd)) {
            coll.enabled = true;
            Debug.Log("left attack");
            animator.SetBool("left", true);
            xDragEnd = 0f;
            yDragEnd = 0f;
        }
        else if (xDragEnd < -0.5f && Mathf.Abs(yDragEnd) < Mathf.Abs(xDragEnd)) {
            coll.enabled = true;
            Debug.Log("right attack");
            animator.SetBool("right", true);
            xDragEnd = 0f;
            yDragEnd = 0f;
        }
        else if (yDragEnd > 0.5f && Mathf.Abs(xDragEnd) < Mathf.Abs(yDragEnd)) {
            coll.enabled = true;
            Debug.Log("down attack");
            animator.SetBool("down", true);
            yDragEnd = 0f;
            xDragEnd = 0f;
        }
        else if (yDragEnd < -0.5f && Mathf.Abs(xDragEnd) < Mathf.Abs(yDragEnd)) {
            coll.enabled = true;
            Debug.Log("up attack");
            animator.SetBool("up", true);
            yDragEnd = 0f;
            xDragEnd = 0f;
        }
        else {
            //Set animations false
            animator.SetBool("left", false);
            animator.SetBool("right", false);
            animator.SetBool("down", false);
            animator.SetBool("up", false);
            if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.5f && !animator.IsInTransition(0)) {
                coll.enabled = false;
            }
        }         
    }

}
