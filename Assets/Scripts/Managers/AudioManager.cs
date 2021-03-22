using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    #region Singleton
    private static AudioManager _instance; 
    public static AudioManager Instance { get { return _instance; } }
    
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        } else {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    #endregion
    
    private float SFXvolume = 1, BGMVolume = 1, UIVolume = 1;
    private bool Muted;
    
    public MuteButton muteButton;

    [Header("Audio Sources")] 
    [SerializeField] private AudioSource BGMSource;
    [SerializeField] private AudioSource SFXSource, UISource, dragonSource, witchSource, unicornSource;

    //Variables for SFX clips
    [Header("SFX Clips")] 
    [SerializeField] private AudioClip flipperSwing;
    [SerializeField] private AudioClip ballHit_Normal, ballHit_Critical, ballFall, points, cannon_Load, cannon_Launch, bumper_Crumble, bumper_Dragon, bumper_Unicorn, bumper_Witch;

    [Header("UI Clips")] 
    [SerializeField] private AudioClip UI_Click;
    [SerializeField] private AudioClip UI_Exit;
    
    //Variables for BGM clips
    [Header("BGM Clips")] 
    [SerializeField] private AudioClip BGM_level;
    [SerializeField] private AudioClip BGM_Menu, BGM_End;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            Mute();
        }
    }

    #region SFX

    //Each method plays its own AudioClip
    public void PlayFlipperSwing()
    {
        PlaySFX(flipperSwing);
    }
    
    public void PlayBallHit_Normal()
    {
        PlaySFXOneShot(ballHit_Normal);
    }
    
    public void PlayBallHit_Critical()
    {
        PlaySFXOneShot(ballHit_Critical);
    }
    
    public void PlayBallFall()
    {
        PlaySFXOneShot(ballFall);
    }
    
    public void PlayCannon_Load()
    {
        PlaySFX(cannon_Load);
    }
    
    public void PlayCannon_Launch()
    {
        PlaySFX(cannon_Launch);
    }

    public void PlayWitch()
    {
        PlayWitchSource(bumper_Crumble, 0.4f);
        PlayWitchSource(bumper_Witch);
    }
    
    public void PlayDragpn()
    {
        PlayDragonSource(bumper_Dragon);
        PlayBallHit_Normal();
    }

    public void PlayUnicorn()
    {
        PlayUnicornSource(bumper_Unicorn);
        PlayBallHit_Normal();
    }
    #endregion

    #region UI
    //Plays UI audio
    public void PlayUIClick()
    {
        PlayUISound(UI_Click);
    }
    
    public void PlayUIExit()
    {
        PlayUISound(UI_Exit);
    }
    
    #endregion

    #region BGM

    public void PlayBGM_Level()
    {
        PlayBGM(BGM_level);
    }
    
    public void PlayBGM_Menu()
    {
        PlayBGM(BGM_Menu);
    }
    
    public void PlayBGM_End()
    {
        PlayBGM(BGM_End);
    }

    #endregion

    //Stops BGM. Mainly for when time bonus points have finished being added
    public void StopBGM()
    {
        BGMSource.Stop();
    }
    
    //Changes BGM clip and plays it
    public void PlayBGM(AudioClip bgm)
    {
        BGMSource.clip = bgm;
        if (!Muted)
        {
            BGMSource.Play();
        }
    }

    //Plays AudioClip that has been passed through
    private void PlaySFX(AudioClip sound)
    {
        //Stops any current sound effect and plays the sound being passed through
        if (SFXSource.isPlaying)
        {
            SFXSource.Stop(); 
        }// Remove if we can play more than one sound at a time
        SFXSource.clip = sound;
        SFXSource.Play();    
    }
    
    private void PlaySFXOneShot(AudioClip sound, float oneShotVolume = 1)
    {
        //Plays a one shot of the sound so it'll play on top of any sound
        oneShotVolume *= SFXvolume;
        SFXSource.PlayOneShot(sound, oneShotVolume);
    }
    
    private void PlayWitchSource(AudioClip sound, float oneShotVolume = 1)
    {
        //Plays a one shot of the sound so it'll play on top of any sound
        witchSource.Stop();
        oneShotVolume *= SFXvolume;
        witchSource.PlayOneShot(sound, oneShotVolume);
    }
    
    private void PlayDragonSource(AudioClip sound, float oneShotVolume = 1)
    {
        //Plays a one shot of the sound so it'll play on top of any sound
        dragonSource.Stop();
        oneShotVolume *= SFXvolume;
        dragonSource.PlayOneShot(sound, oneShotVolume);
    }
    
    private void PlayUnicornSource(AudioClip sound, float oneShotVolume = 1)
    {
        //Plays a one shot of the sound so it'll play on top of any sound
        unicornSource.Stop();
        oneShotVolume *= SFXvolume;
        unicornSource.PlayOneShot(sound, oneShotVolume);
    }

    private void PlayUISound(AudioClip sound)
    {
        UISource.clip = sound;
        UISource.Play();
    }

    public void Mute()
    {
        //Sets SFX and UI sources to switch enabled status
        SFXSource.enabled = !SFXSource.enabled;
        UISource.enabled = !UISource.enabled;
        dragonSource.enabled = !dragonSource.enabled;
        unicornSource.enabled = !unicornSource.enabled;
        witchSource.enabled = !witchSource.enabled;
        
        Muted = !Muted;
        
        //Switches mute button sprite
        muteButton.SwitchSprite(Muted);
        
        //If muted pause BGM else unpause.
        if (Muted)
        {
            BGMSource.Pause();
        }
        else
        {
            BGMSource.UnPause();
            //If BGMsource isn't already playing play
            if (!BGMSource.isPlaying)
            {
                BGMSource.Play();
            }
        }
    }

    #region Volume Control
    //This region controls the volume using the sliders
    public void setSFXVolume(float vol)
    {
        SFXvolume = vol;
        SFXSource.volume = SFXvolume;
    }
    public void setBGMVolume(float vol)
    {
        BGMVolume = vol;
        BGMSource.volume = vol;
    }
    public void setUIVolume(float vol)
    {
        UIVolume = vol;
        UISource.volume = vol;
    }
    #endregion
}
