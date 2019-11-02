using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    // score display
    public Text score;

    // current score and update value
    public float count = 0;
    public float pointsPerSecond = 5;

    // check if player still alive, freeze score if not
    public bool isAlive = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // if character is alive, update current score (rounded)
        if (isAlive)
        {
            count += pointsPerSecond * Time.deltaTime;
        }
        score.text = Mathf.Round(count).ToString();
    }
}
