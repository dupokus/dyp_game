using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeafMover : MonoBehaviour
{

    private bool isColliding;
    private GameObject leaf;
    private Animator leafAnimator;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Leaf"))
        {
            isColliding = true;
            leaf = collision.gameObject;
            leafAnimator = leaf.GetComponent<Animator>();
            leafAnimator.Play("Leaf_Idle");
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Leaf"))
        {
            isColliding = false;
            leafAnimator.Play("Leaf_Moves");
        }
    }

    void Update()
    {
        if (!isColliding && leaf != null)
        {
            leafAnimator.Play("Leaf_Moves");
        }
    }
}
