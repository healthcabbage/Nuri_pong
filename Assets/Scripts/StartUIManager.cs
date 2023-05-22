using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class StartUIManager : MonoBehaviour
{
    public float patternSpeed;

    public void stagemove()
    {
        SoundManager.instance.SfxPlay(SoundManager.Sfx.Button);
        SceneManager.LoadScene("Select");
    }

    public void GameQuit()
    {
        Application.Quit();
    }
}
