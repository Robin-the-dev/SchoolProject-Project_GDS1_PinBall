using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Script for testing audio using keys
 */
public class AudioTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            //Example of how to call the audio
            AudioManager.Instance.PlayBallFall();
        }
        
        if (Input.GetKeyDown(KeyCode.W))
        {
            //Example of how to call the audio
            AudioManager.Instance.PlayFlipperSwing();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            //Example of how to call the audio
            AudioManager.Instance.PlayBallHit_Critical();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            AudioManager.Instance.PlayBallHit_Normal();
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            AudioManager.Instance.StopBGM();
        }
        
        if (Input.GetKeyDown(KeyCode.S))
        {
            AudioManager.Instance.PlayCannon_Load();
        }
        
        if (Input.GetKeyDown(KeyCode.D))
        {
            AudioManager.Instance.PlayCannon_Launch();
        }
        
        if (Input.GetKeyDown(KeyCode.Z))
        {
            AudioManager.Instance.PlayWitch();
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            AudioManager.Instance.PlayDragpn();
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            AudioManager.Instance.PlayUnicorn();
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            AudioManager.Instance.Mute();
        }
    }
}
