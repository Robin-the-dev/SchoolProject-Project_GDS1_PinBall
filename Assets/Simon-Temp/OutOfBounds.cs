using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBounds : MonoBehaviour
{
  public lives livesScript;
    private void OnTriggerEnter2D(Collider2D other){
      if (other.gameObject.tag == "Ball")
      {
        Destroy(other.gameObject);
        livesScript.died = true;
        AudioManager.Instance.PlayBallFall();
      }
    }
}
