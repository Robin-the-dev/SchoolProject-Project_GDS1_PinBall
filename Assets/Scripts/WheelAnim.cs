using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelAnim : MonoBehaviour
{
    public Launcher launcher;

    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(launcher.currentForce == 0) {
            animator.SetBool("charging", false);
        }
        else if(launcher.currentForce > 0 && launcher.currentForce < 0.8) {
            animator.SetBool("charging", true);
        }
        else {
            animator.SetBool("charging", false);
        }
    }
}
