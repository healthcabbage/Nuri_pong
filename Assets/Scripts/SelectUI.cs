using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SelectUI : MonoBehaviour
{
    public GameObject SoundUI;
    public bool soundui = false;

    public Slider Bgmslider;
    public Slider Sfxslider;

    public void Start()
    {
        LoadValues();
    }

    public void Soundui()
    {
        if (soundui == false)
        {
            SoundUI.SetActive(true);
            SoundManager.instance.SfxPlay(SoundManager.Sfx.Button);
            soundui = true;
        }
        else if(soundui == true)
        {
            SoundUI.SetActive(false);
            SoundManager.instance.SfxPlay(SoundManager.Sfx.Button);
            soundui = false;
        }
    }

    public void move()
    {
        SceneManager.LoadScene("Start");
    }

    void LoadValues()
    {
        float BGMValue = PlayerPrefs.GetFloat("BGMValue");
        Bgmslider.value = BGMValue;
        AudioListener.volume = BGMValue;

        float SFXValue = PlayerPrefs.GetFloat("SFXValue");
        Sfxslider.value = SFXValue;
        AudioListener.volume = SFXValue;
    }

    public void SaveValues()
    {
        float BGMValue = Bgmslider.value;
        PlayerPrefs.SetFloat("BGMValue", BGMValue);

        float SFXValue = Sfxslider.value;
        PlayerPrefs.SetFloat("SFXValue", SFXValue);
        LoadValues();
    }
}
