using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyerBumper : MonoBehaviour
{
    private int destroyerBumperScores = 1000;

    private Transform parent;

    private Animator animator;

    private void Start() {
        animator = GetComponent<Animator>();
        parent = this.transform.parent;
        transform.rotation = parent.rotation;
    }

    public void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.tag == "Ball") {
            Scores.scores += destroyerBumperScores;
    
            //Plays SFX
            AudioManager.Instance.PlayWitch();

            StartCoroutine(WitchAnim());
        }
    }

    private IEnumerator WitchAnim() {
        animator.SetBool("isHit", true);

        yield return new WaitForSeconds(0.2f);

        animator.SetBool("isHit", false);

        Destroy(gameObject);
    }
}
