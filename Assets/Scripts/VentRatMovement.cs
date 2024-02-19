using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VentRatMovement : MonoBehaviour
{
    [SerializeField] private Transform leftLimit;
    [SerializeField] private Transform rightLimit;
    private bool movingRight = true;
    [SerializeField] private float ratSpeed;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Patrol();
    }

    void Patrol()
    {
        if (transform.position.x < leftLimit.position.x)
        {
            movingRight = true;
            Turn();
        }
        else if (transform.position.x > rightLimit.position.x)
        {
            movingRight = false;
            Turn();
        }

        if (movingRight)
        {
            transform.position = new Vector2(transform.position.x + ratSpeed * Time.deltaTime, transform.position.y);
        }
        else
        {
            transform.position = new Vector2(transform.position.x - ratSpeed * Time.deltaTime, transform.position.y);
        }
    }

    void Turn()
    {
        Vector3 currentScale = transform.localScale;
        currentScale.x *= -1;
        transform.localScale = currentScale;
    }
}
