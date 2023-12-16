using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rat_Movement : MonoBehaviour
{
    public float speed = 2.0f;
    public float maxDistanceFromStart = 5.0f;

    private Vector3 startPosition;
    private int direction = 1;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        // Calculate the new position
        float movement = Mathf.Sin(Time.time * speed) * maxDistanceFromStart;
        Vector3 newPosition = startPosition + transform.right * movement;

        // Move the enemy mouse to the new position
        transform.position = newPosition;

        // Flip the enemy mouse when it changes direction
        if (movement > 0 && direction == -1 || movement < 0 && direction == 1)
        {
            direction *= -1;
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }
    }
}
