using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    // score display
    public Text score;

    // current score and update value
    float count = 0;
    float pointsPerSecond = 5;

    public Player player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // if character is alive, update current score (rounded)
        if (player.isAlive)
        {
            count += pointsPerSecond * Time.deltaTime;
        }
        score.text = Mathf.Round(count).ToString();
    }
}
