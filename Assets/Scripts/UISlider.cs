using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISlider : MonoBehaviour
{
    private Slider slider;

    public bool bgm, sfx, UI;
    
    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
        if (bgm)
        {
            slider.onValueChanged.AddListener(AudioManager.Instance.setBGMVolume);
        }
        
        if (sfx)
        {
            slider.onValueChanged.AddListener(AudioManager.Instance.setSFXVolume);
        }
        
        if (UI)
        {
            slider.onValueChanged.AddListener(AudioManager.Instance.setUIVolume);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
