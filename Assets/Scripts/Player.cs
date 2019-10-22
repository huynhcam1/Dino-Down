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

    float movement = 0f;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movement = Input.GetAxis("Horizontal") * movementSpeed;
        //if (Input.touchCount > 0)
        //{
        //    Touch touch = Input.GetTouch(0);
        //    Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
        //    touchPosition.z = 0f;
        //    transform.position = touchPosition;
        //}
    }

    // movement
    void FixedUpdate()
    {
        Vector2 velocity = rb.velocity;
        velocity.x = movement;
        rb.velocity = velocity;
    }
}
