using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiplierBumper : MonoBehaviour
{
    public GameObject ballPrefab;

    public Transform ballPosition;

    private Animator animator;

    private bool isCreated = false;

    private int multiplierBumperScores = 300;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    
    public void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Ball") {
            Scores.scores += multiplierBumperScores;

            if (!isCreated) {
                Instantiate(ballPrefab, ballPosition.position, Quaternion.identity);
                isCreated = true;
            }

            //Plays SFX
            AudioManager.Instance.PlayUnicorn();

            StartCoroutine(UnicornAnim());
        }
    }

    private IEnumerator UnicornAnim() {
        animator.SetBool("isHit", true);

        yield return new WaitForSeconds(1.5f);

        animator.SetBool("isHit", false);
        isCreated = false;

        Destroy(gameObject);
    }
}
