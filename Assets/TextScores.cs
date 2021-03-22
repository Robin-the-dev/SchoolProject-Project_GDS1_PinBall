using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextScores : MonoBehaviour
{
    private Text scoresText;

    private int scores;

    // Start is called before the first frame update
    void Start() {
        scoresText = GetComponent<Text>();
        scores = PlayerPrefs.GetInt("Scores", 0);
    }

    // Update is called once per frame
    void Update() {
        scoresText.text = scores.ToString();
    }
}
