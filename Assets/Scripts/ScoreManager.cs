using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text score;

    public float count;
    public float pointsPerSecond;

    public bool isAlive = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isAlive)
        {
            count += pointsPerSecond * Time.deltaTime;
        }
        score.text = Mathf.Round(count).ToString();
    }
}
