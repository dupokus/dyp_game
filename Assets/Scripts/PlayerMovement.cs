using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private PlayerController characterController;
    [SerializeField] private Animator characterAnimator;

    float horizontalMove = 0f;
    float runSpeed = 40f;
    bool jump = false;
    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        characterAnimator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }
    }

    private void FixedUpdate()
    {
        // moving player
        characterController.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;   
    }
}       
