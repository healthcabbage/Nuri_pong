using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource[] BgmPlayer;
    public AudioClip[] bgmClip;
    public AudioSource[] sfxPlayer;
    public AudioClip[] sfxClip;
    int sfxCursor;

    public enum Bgm { MainGame, StartScene, Stage };
    public enum Sfx { LevelUp, Next, Attach, Button, Over };

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

    public void BgmPlay(Bgm type)
    {
        switch(type)
        {
            case Bgm.MainGame:
                BgmPlayer[0].clip = bgmClip[0];
                break;
            case Bgm.StartScene:
                BgmPlayer[0].clip = bgmClip[1];
                break;
            case Bgm.Stage:
                BgmPlayer[0].clip = bgmClip[2];
                break;
        }
        
        BgmPlayer[0].Play();
    }
}
