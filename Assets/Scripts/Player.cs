using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Script to allow movement by touching the screen.
 */
 [RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    // movement scale
    public float movementSpeed = 1f;

    // enables physics
    Rigidbody2D rb;

    // allows for animation switch depending on action
    public Animator animator;

    float movement = 0f;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // limit player within screen width, left side = -0.68f, right side = 0.638f
        if (transform.position.x <= -0.68f)
        {
            transform.position = new Vector2(-0.68f, transform.position.y);
        }
        else if (transform.position.x >= 0.638f)
        {
            transform.position = new Vector2(0.638f, transform.position.y);
        }
        // check for touches on android, left half of screen moves left, right half of screen moves right
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            if (touchPosition.x < 0f)
            {
                movement = -movementSpeed;
            } else if (touchPosition.x > 0f)
            {
                movement = movementSpeed;
            }
        }
        // movement with keyboard, used for debugging without phone
        else
        {
            movement = Input.GetAxis("Horizontal") * movementSpeed;
        }
        // switch to run animation if moving on platforms only (if falling does not switch)
        if (Mathf.Abs(rb.velocity.y) > 0f)
        {
            animator.SetFloat("Speed", 0f);
        }
        else
        {
            animator.SetFloat("Speed", Mathf.Abs(movement));
        }
        // match direction of character with movement, default scale is 1
        Vector2 characterScale = transform.localScale;
        if (movement > 0f)
        {
            characterScale.x = 1;
        }
        else if (movement < 0f)
        {
            characterScale.x = -1;
        }
        transform.localScale = characterScale;
    }

    // assign movement back to rigidbody
    void FixedUpdate()
    {
        Vector2 velocity = rb.velocity;
        velocity.x = movement;
        rb.velocity = velocity;
    }
}
