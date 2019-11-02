using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubblePlatform : MonoBehaviour
{
    // allows for animation switch depending on action
    public Animator animator;

    // speed of bounce
    public float bounceForce = 2f;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    // if player lands on bubble, stop the falling momentum and make the bubble bounce
    IEnumerator OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            // play bubble animation, set velocity of player to bounce force for jump
            animator.SetInteger("PlayerLanded", 1);
            Rigidbody2D playerRb = collision.collider.GetComponent<Rigidbody2D>();
            Vector2 velocity = playerRb.velocity;
            velocity.y = bounceForce;
            playerRb.velocity = velocity;
            // disable animation after player has bounced off platform
            yield return new WaitForSeconds(0.01f);
            animator.SetInteger("PlayerLanded", 0);
        }

    }
}
