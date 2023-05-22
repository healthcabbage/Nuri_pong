using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLock : MonoBehaviour
{
    int levelat; //현재 스테이지 번호 or 현재 오픈된 스테이지 번호
    public Button[] selectbutton;

    void Start()
    {
        levelat = PlayerPrefs.GetInt("levelReached");
        for (int i = levelat + 1; i < selectbutton.Length; i++)
        {
            selectbutton[i].gameObject.SetActive(false);
        }
    }
}
