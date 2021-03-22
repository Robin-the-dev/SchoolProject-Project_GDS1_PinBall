using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MuteButton : MonoBehaviour
{
    public Sprite mutedIcon;
    public Sprite unmutedIcon;

    private Image muteButton;

    private Button button;

    private void Start()
    {
        muteButton = GetComponent<Image>();
        button = GetComponent<Button>();
        button.onClick.AddListener(AudioManager.Instance.Mute);
    }

    public void SwitchSprite(bool muted)
    {
        muteButton.sprite = muted ? unmutedIcon : mutedIcon;
    }
}
