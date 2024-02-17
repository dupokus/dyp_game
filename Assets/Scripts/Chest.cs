using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public Animator animator;
    public PlayerCoin player;
    public RatMovement rat; 
    private bool taskGiven = false;
    [SerializeField] private bool playerInCollider = false;


    void Start()
    {
        // Find the player using its tag
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            player = playerObject.GetComponent<PlayerCoin>();
        }
        // Find the rat using its tag
        GameObject ratObject = GameObject.FindGameObjectWithTag("Rat");
        if (ratObject != null)
        {
            rat = ratObject.GetComponent<RatMovement>();
        }

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerInCollider)
        {
            if (rat.ratIsDead)
            {
                if (!taskGiven)
                {
                    StartCoroutine(PlayAnimations());
                }
                else if (player.coins >= 3)
                {
                    StartCoroutine(PlayFinalAnimations());
                }
            }
            else
            {
                animator.Play("Chest_Idle");
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

    IEnumerator PlayAnimations()
    {
        yield return PlayAnimation("Chest_Opening");
        yield return new WaitForSeconds(0.7f);
        yield return PlayAnimation("Chest_DwarfAppearence");
        yield return new WaitForSeconds(0.8f);
        yield return PlayAnimation("Chest_DwarfPose2");
        yield return new WaitForSeconds(0.8f);
        yield return PlayAnimation("Chest_DwarfGivesTask");
        yield return new WaitForSeconds(5f); 
        taskGiven = true;

        while (player.coins < 3 || !playerInCollider)
        {
            yield return PlayAnimation("Chest_DwarfAwaits");
        }
    }

    IEnumerator PlayFinalAnimations()
    {
        yield return PlayAnimation("Chest_DwarfGivesScroll");
        yield return new WaitForSeconds(3f);
        player.hasScroll = true;
        yield return PlayAnimation("Chest_DwarfHiding");
        yield return new WaitForSeconds(2f);
        yield return PlayAnimation("Chest_Shutting");
        yield return new WaitForSeconds(2f);
        animator.Play("Chest_Idle");
    }

    IEnumerator PlayAnimation(string animationName)
    {
        animator.Play(animationName);
        while (animator.GetCurrentAnimatorStateInfo(0).IsName(animationName))
        {
            yield return null;
        }
    }
}