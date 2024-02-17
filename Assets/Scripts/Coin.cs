using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    // Reference to the particle system to play (optional)
    public ParticleSystem collectParticles;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if colliding with the player
        if (collision.gameObject.tag == "Player")
        {
            // Increment the player's coin count
            PlayerCoin player = collision.gameObject.GetComponent<PlayerCoin>();
            if (player != null)
            {
                player.coins++;
            }

            // Add score or other game logic here
            Debug.Log("Collected a coin!");

            // Play particle effect if available
            if (collectParticles)
            {
                collectParticles.Play();
            }

            // Destroy the coin object
            Destroy(gameObject);
        }
    }
}
