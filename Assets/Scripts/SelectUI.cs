using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SelectUI : MonoBehaviour
{
    public GameObject SoundUI;
    public bool soundui = false;

    public void Start()
    {

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
        SceneManager.LoadScene("Stage");
    }
}
