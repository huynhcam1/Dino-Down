using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Destroys all previously spawned platforms.
 */
public class Destroy : MonoBehaviour
{
    //public GameObject player;
    public GameObject platformPrefab;
    private GameObject newPlatform;

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
        float x = collider.transform.position.x;
        float y = collider.transform.position.y;
        Vector2 position = new Vector2(x, y - Random.Range(1f, 2f));
        newPlatform = Instantiate(platformPrefab, position, Quaternion.identity);
        Destroy(collider.gameObject);
        Debug.Log("break");
    }
}
