using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetResolution : MonoBehaviour
{
    private void Awake() {
        Screen.SetResolution(640, 480, true);
    }
}
