using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    public AudioMixer mixer;
    public AudioSource BgmPlayer;
    public AudioClip[] bgmClip;
    public AudioSource[] sfxPlayer;
    public AudioClip[] sfxClip;
    int sfxCursor;

    float BGM;
    float SFX;

    public Slider Bgmslider;
    public Slider Sfxslider;

    public enum Sfx { LevelUp, Next, Attach, Button, Over };

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        LoadValues();
    }

    private void OnSceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        for (int i = 0; i < bgmClip.Length; i++)
        {
            if(arg0.name == bgmClip[i].name)
                BgSoundPlay(bgmClip[i]);
        }

    }

    public void SfxPlay(Sfx type)
    {
        switch(type)
        {
            case Sfx.LevelUp:
                sfxPlayer[sfxCursor].clip = sfxClip[Random.Range(0, 3)];
                break;
            case Sfx.Next:
                sfxPlayer[sfxCursor].clip = sfxClip[3];
                break;
            case Sfx.Attach:
                sfxPlayer[sfxCursor].clip = sfxClip[4];
                break;
            case Sfx.Button:
                sfxPlayer[sfxCursor].clip = sfxClip[5];
                break;
            case Sfx.Over:
                sfxPlayer[sfxCursor].clip = sfxClip[6];
                break;
        }

        sfxPlayer[sfxCursor].Play();
        sfxCursor = (sfxCursor+1) % sfxPlayer.Length;
    }

    public void BgSoundPlay(AudioClip clip)
    {
        BgmPlayer.outputAudioMixerGroup = mixer.FindMatchingGroups("BgSound")[0];
        BgmPlayer.clip = clip;
        BgmPlayer.loop = true;
        BgmPlayer.Play();
    }

    public void SetBgmVolume(float val)
    {
        mixer.SetFloat("BGSound", Mathf.Log10(val) * 20);
        PlayerPrefs.SetFloat("BGSound", val);
        AudioListener.volume = val;
    }

    public void SetSFXVolume(float val)
    {
        mixer.SetFloat("SFX", Mathf.Log10(val) * 20);
        PlayerPrefs.SetFloat("SFX", val);
        AudioListener.volume = val;
    }

    public void LoadValues()
    {
        BGM = PlayerPrefs.GetFloat("BGSound");
        Bgmslider.value = BGM;
        AudioListener.volume = BGM;

        SFX = PlayerPrefs.GetFloat("SFX");
        Sfxslider.value = SFX;
        AudioListener.volume = SFX;
        Debug.Log("체크");
    }
}
