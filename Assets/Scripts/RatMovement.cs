using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatMovement : MonoBehaviour
{
    [SerializeField] private float ratSpeed;
    [SerializeField] private float attackRange = 1.0f;
    [SerializeField] private Transform leftLimit;
    [SerializeField] private Transform rightLimit;
    private bool movingRight = true;
    private Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (player != null)
        {
            float distanceToPlayer = Vector2.Distance(transform.position, player.position);
            if (distanceToPlayer < attackRange)
            {
                Attack();
            }
            else
            {
                Patrol();
            }
        }
    }

    void Patrol()
    {
        if (transform.position.x > rightLimit.position.x)
        {
            movingRight = false;
            Turn();
        }
        else if (transform.position.x < leftLimit.position.x)
        {
            movingRight = true;
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

    void Attack()
    {
        Vector2 direction = (player.position - transform.position).normalized;
        transform.position += (Vector3)direction * ratSpeed * Time.deltaTime;

        // Flip the enemy sprite to face the player during attack
        if (direction.x > 0 && !movingRight || direction.x < 0 && movingRight)
        {
            Turn();
            movingRight = !movingRight;
        }

        if (Vector2.Distance(transform.position, player.position) <= attackRange)
        {
            Debug.Log("Player dies, ENDGAME");
            // Destroy(player.gameObject);
        }
    }
}