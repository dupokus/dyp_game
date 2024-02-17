using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private PlayerController characterController;
    [SerializeField] private Animator characterAnimator;

    float horizontalMove = 0f;
    [SerializeField] float runSpeed = 20f;
    bool jump = false;

    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        characterAnimator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            characterAnimator.SetBool("IsJumping", true);
        }
    }
    public void OnLanding()
    {
        characterAnimator.SetBool("IsJumping", false);
    }

    private void FixedUpdate()
    {
        // moving player
        characterController.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;   
    }

    
}       
