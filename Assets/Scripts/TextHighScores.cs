using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextHighScores : MonoBehaviour
{
    private Text highScoresText;

    private int highScores;

    // Start is called before the first frame update
    void Start()
    {
        highScoresText = GetComponent<Text>();
        highScores = PlayerPrefs.GetInt("HighScores");
    }

    // Update is called once per frame
    void Update()
    {
        highScoresText.text = highScores.ToString();
    }
}
