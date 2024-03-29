using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMotor : MonoBehaviour
{   

    private Animator animator;
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool IsGrounded;
    public float basespeed = 5f;
    public float speed = 5f;
    public float additionalSpeed = 10f;
    public float gravity = -9.81f;
    public float jumpHeight = 200f;
    bool crouching = false;
    float crouchTimer = 1;
    bool lerpCrouch = false;
    public bool sprinting = false;
    public int AnimDebug = 0;
    
    // Start is called before the first frame update
    void Start()
    {   

        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        IsGrounded = controller.isGrounded;
        if (lerpCrouch)
        {
            crouchTimer += Time.deltaTime;
            float p = crouchTimer / 1;
            p *= p;
            if (crouching)
                controller.height = Mathf.Lerp(controller.height, 1, p);
            else
                controller.height = Mathf.Lerp(controller.height, 2, p);
            if (p > 1)
            {
                lerpCrouch = false;
                crouchTimer = 0f;
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed += additionalSpeed;
            sprinting = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = basespeed;
            sprinting = false;
        }
        
    }
    
    public void Crouch()
    {
        crouching = !crouching;
        crouchTimer = 0;
        lerpCrouch = true;
    }
    public void Sprint()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = 15f;
              
                if (Input.GetKeyDown(KeyCode.LeftShift))
                {
                    speed = 5f;
                }
                Debug.Log(speed);
        }
    

        
        
    }
    public void ProcessMove(Vector2 input)
    {
        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = input.x;
        moveDirection.z = input.y;
        controller.Move(transform.TransformDirection(moveDirection) * speed * Time.deltaTime);
        playerVelocity.y += gravity * Time.deltaTime;
        if(IsGrounded && playerVelocity.y < 0)
            playerVelocity.y = -9.8f;
        controller.Move(playerVelocity * Time.deltaTime);
        // Debug.Log(playerVelocity.y);
    }
    public void Jump()
    {
        if (crouching)
          {
          jumpHeight = 0.3f;
          }
        

        if(IsGrounded)
        {
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -3.0f * gravity);
        }
    }
    // public void CrouchJump()
    // {

    // }
    public void IsMoving( )
    {
    }
}
