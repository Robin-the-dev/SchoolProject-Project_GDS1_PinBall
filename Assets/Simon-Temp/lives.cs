using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class lives : MonoBehaviour
{
    public int livesCount;
    private GameObject[] balls;
    [SerializeField]private GameObject ballPrefab;
    [SerializeField]private Transform ballSpawn;
    [SerializeField]private Animator[] hearts;
    private bool isBallsEmpty;
    public bool died = false;
    private Vector3 ballStart;
    private int i;

    void Start(){
      //InvokeRepeating("Testing",5f,5f);
      ballStart = ballSpawn.position;
      i = 0;
    }


    void Update(){
      if (i > 2){
        i = 0;
      }
      balls = GameObject.FindGameObjectsWithTag("Ball");
      if (balls.Length < 1)
        isBallsEmpty = true;
      if (isBallsEmpty & died){
        Debug.Log("died");
        balls = GameObject.FindGameObjectsWithTag("Ball");
        if (balls.Length < 1){
          Instantiate(ballPrefab,ballStart,Quaternion.identity);
          livesCount--;
          hearts[i].SetBool("IsAlive",false);
          i++;
        }
        died = false;
      }
      if (livesCount < 0)
        SceneController.Instance.LoadHighscore();
    }


    // private void Testing(){
    //   Instantiate(ball, new Vector3(0f,0f,0f),Quaternion.identity);
    //   Debug.Log("Spawned Ball");
    // }

}
