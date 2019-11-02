﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/* Ends game if water touches player.
 */
public class DestroyWater : MonoBehaviour
{
    public ScoreManager scoreManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // if player falls into water, notify score manager player is dead to stop score count and change scene
    private void OnTriggerEnter2D(Collider2D collider)
    {
        // ends game if player enters water collider
        if (collider.gameObject.tag == "Player")
        {
            scoreManager.isAlive = false;
            Destroy(collider.gameObject);
            Debug.Log("game over");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        
    }
}
