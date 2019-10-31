using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeafPlatform : MonoBehaviour
{
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // if player lands on leaf, stop the falling momentum and make leaf disappear
    IEnumerator OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            animator.SetInteger("PlayerLanded", 1);
            yield return new WaitForSeconds(0.15f);
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            yield return new WaitForSeconds(0.3f);
            gameObject.GetComponent<BoxCollider2D>().enabled = true;
        }
    }
}
