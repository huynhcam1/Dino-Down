using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IcePlatform : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // ice platform has reduced friction
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Rigidbody2D playerRb = collision.collider.GetComponent<Rigidbody2D>();
            // add force on the direction player is moving
            if (playerRb.velocity.x > 0f)
            {
                playerRb.AddForce(Vector2.right * 20f);
            }
            else if (playerRb.velocity.x < 0f)
            {
                playerRb.AddForce(Vector2.left * 20f);
            }
        }
    }
}
