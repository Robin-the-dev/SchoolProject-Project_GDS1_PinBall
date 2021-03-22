using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scores : MonoBehaviour
{
    public static int scores = 0;
    public static int highScores;

    private Text scoresText;

    #region Singleton
    private static Scores _instance;
    public static Scores Instance { get { return _instance; } }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    #endregion  //Scores.Instance.function

    void Start()
    {
        scoresText = GetComponent<Text>();
        scores = 0;
    }
    
    void Update()
    {
        scoresText.text = "Scores: " + scores.ToString("d8");

        if(scores > highScores) {
            highScores = scores;
        }
    }
}
