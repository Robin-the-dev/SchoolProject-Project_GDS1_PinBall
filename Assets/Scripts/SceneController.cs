using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    #region Singleton
    private static SceneController _instance; 
    public static SceneController Instance { get { return _instance; } }
    
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        } else {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    #endregion
    
    public void LoadTitle()
    {
        AudioManager.Instance.PlayBGM_Menu();
        SceneManager.LoadScene("Title");
    }

    public void LoadGame()
    {
        AudioManager.Instance.PlayBGM_Level();
        SceneManager.LoadScene("Map");
    }

    public void LoadTutorial()
    {
        SceneManager.LoadScene("TutorialScene");
    }

    public void LoadSettings()
    {
        SceneManager.LoadScene("AudioScene");
    }

    public void LoadHighscore()
    {
        AudioManager.Instance.PlayBGM_End();
        SceneManager.LoadScene("Highscore");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
