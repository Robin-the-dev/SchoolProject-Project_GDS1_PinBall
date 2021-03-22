using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Highscores : MonoBehaviour
{
    [SerializeField] private Text HSSText;
    [SerializeField] private Text YSSText;
    private Scores scoresScript;

    void Start()
    {
        scoresScript = GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<Scores>(); //this has not been tagged yet
        HSSText.text = Scores.highScores + "";
        YSSText.text = Scores.scores + "";
    }

}
