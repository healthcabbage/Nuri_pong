using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelClear : MonoBehaviour
{
    public GameObject[] text;
    public int laststage;
    
    void Start()
    {
        laststage = PlayerPrefs.GetInt("levelReached");

        for (int i = laststage - 1; i >= 0; i--)
        {
            text[i].SetActive(true);
        }

    }
}
