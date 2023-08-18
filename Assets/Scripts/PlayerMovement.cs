using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private PlayerController characterController;

    float horizontalMove = 0f;
    float runSpeed = 40f;
    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
    }

    private void FixedUpdate()
    {
        // moving player
        characterController.Move(horizontalMove * Time.fixedDeltaTime, false, false);
    }
}       
