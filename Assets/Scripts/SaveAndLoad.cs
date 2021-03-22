using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveAndLoad : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerPrefs.SetInt("Scores", Scores.scores);
        PlayerPrefs.SetInt("HighScores", Scores.highScores);
    }
}
