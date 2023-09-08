using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{

    public CharacterController2D controller;
    float HorizontalMove = 0f;
    public float RunSpeed = 40f;
    public bool jump = false;
    bool crouch = false;
    public Animator animator;

    void Update()
    {
        HorizontalMove = Input.GetAxis("Horizontal") * RunSpeed;
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }
        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;

        }
        else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }
        if (controller.Grounded == false)
        {
            jump = true;
        }
        WalkAnimation();
        JumpAnimation();




    }
    private void FixedUpdate()
    {
        controller.Move(HorizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
        //crouch = false;
    }



    void WalkAnimation()
    {
        if (HorizontalMove != 0)
        {
            animator.SetBool("isRunning", true);

        }
        else
        {
            animator.SetBool("isRunning", false);
        }
    }

    void JumpAnimation()
    {
        if (jump)
        {
            animator.SetBool("isJumping", true);
        }

        else
        {
            animator.SetBool("isJumping", false);

        }
    }
}
