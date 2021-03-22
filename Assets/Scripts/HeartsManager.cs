using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartsManager : MonoBehaviour
{
    public int livesNumber;
    // For assigning which heart represents which life

    private int lives = 3;

    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Update lives = lives from lives script constantly
        if (livesNumber > lives) // If heart is assigned to a live which is lost
        {
            animator.SetBool("IsAlive", false);
        }
        else
        {
            animator.SetBool("IsAlive", true);
        }

        /* I.e. if heart is assigned to life no.3, as soon as life no.3 is lost
        (3 -> 2 lives left), then the heart will be set to false and change states
         */
    }
}
