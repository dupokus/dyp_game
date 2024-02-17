using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitScript : MonoBehaviour
{
    public PlayerCoin player;
    [SerializeField] private bool playerInCollider = false;
    void Start()
    {
        // Find the player using its tag
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            player = playerObject.GetComponent<PlayerCoin>();
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerInCollider)
        {
            if (player.hasScroll)
            {
                SceneManager.LoadScene("KitchenScene");   
            }
            else
            {
                Debug.Log("smth not rihgt");
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == player.gameObject)
        {
            playerInCollider = true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject == player.gameObject)
        {
            playerInCollider = false;
        }
    }
}
