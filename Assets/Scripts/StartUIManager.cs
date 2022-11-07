using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartUIManager : MonoBehaviour
{
    void Awake()
    {
        SoundManager.instance.BgmPlay(SoundManager.Bgm.StartScene);
    }

    public void stagemove()
    {
        SceneManager.LoadScene("Select");
    }
}
