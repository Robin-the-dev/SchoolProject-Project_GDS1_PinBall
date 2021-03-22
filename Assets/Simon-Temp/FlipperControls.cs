using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipperControls : MonoBehaviour
{
  public bool isRight = false;
  private HingeJoint2D myHingeJoint;

  void Start(){
    myHingeJoint = GetComponent<HingeJoint2D>();
  }

  void FixedUpdate()
  {
    if (Input.GetKey(KeyCode.LeftArrow) && !isRight)
    {
      myHingeJoint.useMotor = true;
    }
    else
      myHingeJoint.useMotor = false;

    if (Input.GetKey(KeyCode.RightArrow) && isRight)
    {
      myHingeJoint.useMotor = true;
      
    }
  }

  private void Update()
  {
    if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
    {
      AudioManager.Instance.PlayFlipperSwing();
    }
  }
}
