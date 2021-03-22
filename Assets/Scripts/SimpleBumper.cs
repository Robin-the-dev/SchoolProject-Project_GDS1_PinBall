using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleBumper : MonoBehaviour
{
    private int simpleBumperScores = 100;

    private Animator animator;

    private void Start() {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.tag == "Ball") {
            Scores.scores += simpleBumperScores;
            
            //Plays SFX
            AudioManager.Instance.PlayDragpn();

            //Animation
            StartCoroutine(DragonAnim());
        }
    }

    private IEnumerator DragonAnim() {
        animator.SetBool("isHit", true);

        yield return new WaitForSeconds(1.5f);

        animator.SetBool("isHit", false);
    }
}
