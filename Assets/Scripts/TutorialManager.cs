using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialManager : MonoBehaviour
{
    // Tutorial states
    public enum TutorialStates { Page1, Page2, Page3 };
    public TutorialStates currentState;

    // Tutorial panels
    public GameObject page1;
    public GameObject page2;
    public GameObject page3;

    private void Awake()
    {
        {
            currentState = TutorialStates.Page1;
        }
    }

    void Update()
    {
        // Checks current menu state
        switch (currentState)
        {
            case TutorialStates.Page1:
                // Sets active panel for page 1
                page1.SetActive(true);
                page2.SetActive(false);
                page3.SetActive(false);

                break;

            case TutorialStates.Page2:
                // Sets active panel for page 2
                page1.SetActive(false);
                page2.SetActive(true);
                page3.SetActive(false);

                break;

            case TutorialStates.Page3:
                // Sets active panel for page 3
                page1.SetActive(false);
                page2.SetActive(false);
                page3.SetActive(true);

                break;
        }
    }

    public void FirstPageNext()
    {
        Debug.Log("Pressed 'Next' on page 1 of tutorial");

        // Goes to page 2
        currentState = TutorialStates.Page2;
    }

    public void SecondPageBack()
    {
        Debug.Log("Pressed 'Back' on page 2 of tutorial");

        // Goes to page 1
        currentState = TutorialStates.Page1;
    }

    public void SecondPageNext()
    {
        Debug.Log("Pressed 'Next' on page 2 of tutorial");

        // Goes to page 3
        currentState = TutorialStates.Page3;
    }

    public void ThirdPageBack()
    {
        Debug.Log("Pressed 'Back' on page 3 of tutorial");

        // Goes to page 2
        currentState = TutorialStates.Page2;
    }

    public void ThirdPageNext()
    {
        Debug.Log("Pressed 'Begin' on page 3 of tutorial");

        // Goes to game
        AudioManager.Instance.PlayBGM_Level();
        SceneManager.LoadScene("Map");
    }

    public void ExitTutorial()
    {
        SceneManager.LoadScene("Title");
    }
}
