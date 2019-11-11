using UnityEngine;

/* Destroys all previously spawned platforms and generates new ones.
 * Ends game if asteroid touches player.
 */
public class DestroyAsteroid : MonoBehaviour
{
    public Player player;

    public GameObject filters;
    public GameObject gameplayWindow;
    public GameObject gameOverWindow;

    // different platforms
    public GameObject bubblePrefab;
    public GameObject groundPrefab;
    public GameObject icePrefab;
    public GameObject leafPrefab;

    // speed and height for moving asteroid
    float speed = 0.3f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // moves the asteroid up and down
        Vector3 position = transform.position;
        float y = 2.15f + Mathf.PingPong(Time.time * speed, 0.2f);
        // child position must be offset with parent position since camera.z is -10 instead of 0
        transform.localPosition = new Vector3(position.x, y, position.z + 10);
    }

    // if player touches asteroid, notify score manager player is dead to stop score count and change scene
    // if platform touches asteroid, generate new platforms
    private void OnTriggerEnter2D(Collider2D collison)
    {
        // ends game if player enters asteroid collider
        if (collison.gameObject.tag == "Player")
        {
            player.isAlive = false;
            Destroy(collison.gameObject);
            Debug.Log("game over");
            filters.SetActive(true);
            gameplayWindow.SetActive(false);
            gameOverWindow.SetActive(true);
        }
        // generate new platforms, then destroy old platform
        float x = collison.transform.position.x;
        float y = collison.transform.position.y;
        Vector2 position = new Vector2(Random.Range(-0.521f, 0.521f), y - Random.Range(2.4f, 2.6f));
        float p = Random.Range(0f, 1f);
        GameObject newPrefab;
        if (p < 0.55f)
        {
            newPrefab = groundPrefab;
        } else if (0.55f <= p && p < 0.7f)
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
