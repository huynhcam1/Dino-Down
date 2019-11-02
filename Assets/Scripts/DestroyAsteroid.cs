using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/* Destroys all previously spawned platforms and generates new ones.
 * Ends game if asteroid touches player.
 */
public class DestroyAsteroid : MonoBehaviour
{
    public ScoreManager scoreManager;

    // different platforms
    public GameObject bubblePrefab;
    public GameObject groundPrefab;
    public GameObject icePrefab;
    public GameObject leafPrefab;

    // speed and height for moving asteroid
    float speed = 5f;
    float height = 0.01f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // moves the asteroid up and down
        Vector2 position = transform.position;
        float newY = Mathf.Sin(Time.time * speed) * height + position.y;
        transform.position = new Vector2(position.x, newY);
    }

    // if player touches asteroid, notify score manager player is dead to stop score count and change scene
    // if platform touches asteroid, generate new platforms
    private void OnTriggerEnter2D(Collider2D collison)
    {
        // ends game if player enters asteroid collider
        if (collison.gameObject.tag == "Player")
        {
            scoreManager.isAlive = false;
            Destroy(collison.gameObject);
            Debug.Log("game over");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        // generate new platforms, then destroy old platform
        float x = collison.transform.position.x;
        float y = collison.transform.position.y;
        Vector2 position = new Vector2(Random.Range(-0.521f, 0.521f), y - Random.Range(2.4f, 2.6f));
        float p = Random.Range(0f, 1f);
        GameObject newPrefab;
        if (p < 0.6f)
        {
            newPrefab = groundPrefab;
        } else if (0.6f <= p && p < 0.75f)
        {
            newPrefab = icePrefab;
        } else if (0.75f <= p && p < 0.9f)
        {
            newPrefab = bubblePrefab;
        } else
        {
            newPrefab = leafPrefab;
        }
        Instantiate(newPrefab, position, Quaternion.identity);
        Destroy(collison.gameObject);
        Debug.Log("asteroid");
    }
}
