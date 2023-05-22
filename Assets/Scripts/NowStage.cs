using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NowStage : MonoBehaviour
{
    int nowstagelevel;

    void Start()
    {
        nowstagelevel = PlayerPrefs.GetInt("NowStage");
    }

    public void OneStage()
    {
        nowstagelevel = 0;
        PlayerPrefs.SetInt("NowStage", nowstagelevel);
    }

    public void TwoStage()
    {
        nowstagelevel = 1;
        PlayerPrefs.SetInt("NowStage", nowstagelevel);
    }

    public void ThreeStage()
    {
        nowstagelevel = 2;
        PlayerPrefs.SetInt("NowStage", nowstagelevel);
    }

    public void FourStage()
    {
        nowstagelevel = 3;
        PlayerPrefs.SetInt("NowStage", nowstagelevel);
    }

    public void FiveStage()
    {
        nowstagelevel = 4;
        PlayerPrefs.SetInt("NowStage", nowstagelevel);
    }

    public void SixStage()
    {
        nowstagelevel = 5;
        PlayerPrefs.SetInt("NowStage", nowstagelevel);
    }

    public void SevenStage()
    {
        nowstagelevel = 6;
        PlayerPrefs.SetInt("NowStage", nowstagelevel);
    }

    public void EightStage()
    {
        nowstagelevel = 7;
        PlayerPrefs.SetInt("NowStage", nowstagelevel);
    }
}
