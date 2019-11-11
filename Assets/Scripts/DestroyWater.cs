using UnityEngine;

/* Ends game if water touches player.
 */
public class DestroyWater : MonoBehaviour
{
    public Player player;

    public GameObject filters;
    public GameObject gameplayWindow;
    public GameObject gameOverWindow;

    float speed = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x >= 1.772f)
        {
            transform.position = new Vector2(-1.376f, transform.position.y);
        }
        transform.Translate(Vector2.right * Time.deltaTime * speed);
    }

    // if player falls into water, notify score manager player is dead to stop score count and change scene
    private void OnTriggerEnter2D(Collider2D collider)
    {
        // ends game if player enters water collider
        if (collider.gameObject.tag == "Player")
        {
            player.isAlive = false;
            Destroy(collider.gameObject);
            Debug.Log("game over");
            filters.SetActive(true);
            gameplayWindow.SetActive(false);
            gameOverWindow.SetActive(true);
        }
        
    }
}
