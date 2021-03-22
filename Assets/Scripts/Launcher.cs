using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : MonoBehaviour
{
    private SpringJoint2D sJ2D;

    private float chargingSpeed = 0.5f;
    public float currentForce = 0f;

    // Start is called before the first frame update
    void Start()
    {
        sJ2D = GetComponent<SpringJoint2D>();
        sJ2D.distance = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space)) {
            sJ2D.distance = 1.0f;
            currentForce = 0f;
            AudioManager.Instance.PlayCannon_Launch();
        }

        if (Input.GetKey(KeyCode.Space)) {
            currentForce = currentForce + chargingSpeed * Time.deltaTime;
            
            sJ2D.distance = 1.0f - currentForce;

            if(currentForce > 0.8f) {
                sJ2D.distance = 0.2f;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            AudioManager.Instance.PlayCannon_Load();
        }
    }
}
