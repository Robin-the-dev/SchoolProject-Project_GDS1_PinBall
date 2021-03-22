using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiplierBumperMaker : MonoBehaviour
{
    public GameObject multiplierBumperPrefab;

    private bool isInstantiated = false;

    // Start is called before the first frame update
    void Start() {
        Instantiate(multiplierBumperPrefab, transform.position, Quaternion.identity);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.tag == "Ball") {
            if (!isInstantiated) {
                StartCoroutine(Countdown());
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if(collision.gameObject.tag == "Ball") {
            isInstantiated = true;
        }
    }

    private IEnumerator Countdown() {
        yield return new WaitForSeconds(30);

        Instantiate(multiplierBumperPrefab, transform.position, Quaternion.identity);
        isInstantiated = false;
    }
}
