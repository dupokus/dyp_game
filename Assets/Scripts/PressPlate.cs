using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressPlate : MonoBehaviour
{
    // Animator components for both objects
    private Animator buttonAnimator;
    private Animator chestAnimator;

   

    void Start()
    {
        buttonAnimator = GetComponent<Animator>(); // Animator for this object (Button)
        chestAnimator = GameObject.Find("Chest").GetComponent<Animator>(); // Find and assign Animator for the Chest object

        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.name == "Player" && Input.GetKeyDown(KeyCode.E))
        {
            
            buttonAnimator.Play("PressPlate_Pressed"); // Play animation on this object

            // Trigger animation sequence on Chest using its script (adjust call based on actual script)
            chestAnimator.Play("Chest_Opening");
        }
    }

    // Update is not needed in this case

    // (Optional) Add a function to reset the animation state if needed
   
}
