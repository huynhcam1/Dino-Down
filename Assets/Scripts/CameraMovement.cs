using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float speed = 1f;
    public float acceleration = 0.0002f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down * Time.deltaTime * speed);
        speed += acceleration;
    }
}
