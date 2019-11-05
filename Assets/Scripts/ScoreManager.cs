using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    // score display
    public Text scoreText;
    public Text highscoreText;

    // current score and update value
    float score;
    int highscore;
    float pointsPerSecond = 5;

    public Player player;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        highscore = PlayerPrefs.GetInt("highscore", 0);
        highscoreText.text = highscore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        // if character is alive, update current score (rounded)
        if (player.isAlive)
        {
            score += pointsPerSecond * Time.deltaTime;
            scoreText.text = Mathf.Round(score).ToString();
        }
        else
        {
            if (Mathf.RoundToInt(score) > highscore)
            {
                highscore = Mathf.RoundToInt(score);
                PlayerPrefs.SetInt("highscore", highscore);
            }
            highscoreText.text = highscore.ToString();
        }

        
    }
}
