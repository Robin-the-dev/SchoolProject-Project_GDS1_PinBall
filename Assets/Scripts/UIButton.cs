using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIButton : MonoBehaviour
{
    public bool backButton, loadMenu, loadTutorial, loadGame, quitGame;

    private Button button;
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        if (backButton)
        {
            button.onClick.AddListener(AudioManager.Instance.PlayUIExit);
        }
        else
        {
            button.onClick.AddListener(AudioManager.Instance.PlayUIClick);
        }

        if (loadMenu)
        {
            button.onClick.AddListener(SceneController.Instance.LoadTitle);
        }
        
        if (loadTutorial)
        {
            button.onClick.AddListener(SceneController.Instance.LoadTutorial);
        }
        
        if (loadGame)
        {
            button.onClick.AddListener(SceneController.Instance.LoadGame);
        }
        
        if (quitGame)
        {
            button.onClick.AddListener(SceneController.Instance.QuitGame);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
