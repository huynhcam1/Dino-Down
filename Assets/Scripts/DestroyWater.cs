using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWater : MonoBehaviour
{
    public GameObject player;
    public ScoreManager scoreManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider == player.GetComponent("BoxCollider2D"))
        {
            scoreManager.isAlive = false;
            Destroy(collider.gameObject);
            Debug.Log("water");
            // end game here
        }
        
    }
}
