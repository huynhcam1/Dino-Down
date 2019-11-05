using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    // camera movement speed
    public float speed = 1f;
    // camera acceleration
    public float acceleration = 0.0003f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // move camera down to view new platforms, slowly moves faster to increase difficulty
        transform.Translate(Vector2.down * Time.deltaTime * speed);
        speed += acceleration;
    }
}
