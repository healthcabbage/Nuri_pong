using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartUIManager : MonoBehaviour
{
    public void stagemove()
    {
        SoundManager.instance.SfxPlay(SoundManager.Sfx.Button);
        SceneManager.LoadScene("Select");
    }
}
