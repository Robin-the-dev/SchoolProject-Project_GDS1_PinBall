using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyerBumperMaker : MonoBehaviour
{
    public GameObject destroyerBumperPrefab;

    public Transform parent;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(destroyerBumperPrefab, transform.position, Quaternion.identity, parent);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Ball") {
            StartCoroutine(Countdown());
        }
    }

    private IEnumerator Countdown() {
        int counter = 10;

        while (counter > 0) {
            yield return new WaitForSeconds(1);
            counter--;
        }

        Instantiate(destroyerBumperPrefab, transform.position, Quaternion.identity, parent);
    }
}
