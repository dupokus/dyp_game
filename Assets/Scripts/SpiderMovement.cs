using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderMovement : MonoBehaviour
{
    [SerializeField] private Transform upLimit;
    [SerializeField] private Transform bottomLimit;
    [SerializeField] private float spiderSpeed;
    private bool movingUp = true;
    void Start()
    {
        
    }

    void Update()
    {
        Patrol();
    }

    void Patrol()
    {
        if (transform.position.y < bottomLimit.position.y)
        {
            movingUp = true;
            
        }
        else if (transform.position.y > upLimit.position.y)
        {
            movingUp = false;
            
        }

        if (movingUp)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + spiderSpeed * Time.deltaTime, -1);
        }
        else
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - spiderSpeed * Time.deltaTime, -1);
        }
    }
}
