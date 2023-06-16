using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("---------- [ Object Pooling ] ")]
    public GameObject donglePrefab;
    public Transform dongleGroup;
    public List<Dongle> donglePool;

    public GameObject effectPrefab;
    public Transform effectGroup;
    public List<ParticleSystem> effectPool;

    [Range(1, 30)]
    public int poolSize;
    public int poolCursor;
    public Dongle lastDongle;

    [Header(" ---------- [ Core ] ")]
    public int score;
    public int maxLevel;
    public bool isOver;
    public int nowStage;
    public int startUISelect;

    [Header(" ---------- [ UI ] ")]
    public GameObject endGroup;
    public Text scoreText;
    public Text maxScoreText;
    public Text subScoreText;
    public GameObject[] startGroup;

    void Awake()
    {
        Application.targetFrameRate = 60;

        donglePool = new List<Dongle>();
        effectPool = new List<ParticleSystem>();
        for (int index = 0; index < poolSize; index++)
        {
            MakeDonle();
        }

        if (!PlayerPrefs.HasKey("MaxScore"))
        {
            PlayerPrefs.SetInt("MaxScore", 0);
        }
        maxScoreText.text = PlayerPrefs.GetInt("MaxScore").ToString();

        startUISelect = PlayerPrefs.GetInt("NowStage");
    }

    void Start()
    {
        StartUI();
        Invoke("NextDongle", 3.5f);
        nowStage = PlayerPrefs.GetInt("levelReached");
    }

    Dongle MakeDonle()
    {
        //이펙트 생성
        GameObject instantEffectObj = Instantiate(effectPrefab, effectGroup);
        instantEffectObj.name = "Effect " + effectPool.Count;
        ParticleSystem instantEffect = instantEffectObj.GetComponent<ParticleSystem>();
        effectPool.Add(instantEffect);

        //동글 생성
        GameObject instantDongleObj = Instantiate(donglePrefab, dongleGroup);
        instantDongleObj.name = "Dongle " + donglePool.Count;
        Dongle instantDongle = instantDongleObj.GetComponent<Dongle>();
        instantDongle.manager = this;
        instantDongle.effect = instantEffect;
        donglePool.Add(instantDongle);

        return instantDongle;
    }

    Dongle GetDongle()
    {
        for (int index = 0; index < donglePool.Count; index++)
        {
            poolCursor = (poolCursor + 1) % donglePool.Count;
            if (!donglePool[poolCursor].gameObject.activeSelf)
            {
                return donglePool[poolCursor];
            }
        }        
        return MakeDonle();
    }
    
    void NextDongle()
    {
        if(isOver)
        {
            return;
        }
        lastDongle = GetDongle();
        lastDongle.level = Random.Range(0, maxLevel);
        lastDongle.gameObject.SetActive(true);

        SoundManager.instance.SfxPlay(SoundManager.Sfx.Next);
        StartCoroutine(WaitNext());
    }

    IEnumerator WaitNext()
    {
        while(lastDongle != null)
        {
            yield return null;
        }
        yield return new WaitForSeconds(2.5f);

        NextDongle();
    }

    public void TouchDown()
    {
        if (lastDongle == null)
        {
            return;
        }
        
        lastDongle.Drag();
    }

    public void TouchUp()
    {
        if (lastDongle == null)
        {
            return;
        }

        lastDongle.Drop();
        lastDongle = null;
    }

    public void GameOver()
    {
        if (isOver)
        {
            return;
        }
        isOver = true;

        switch (nowStage)
        {
            case 0 :
                if (score >= 50)
                {
                    if (nowStage == 0)
                        nowStage = nowStage + 1;
                    PlayerPrefs.SetInt("levelReached", nowStage);
                    StartCoroutine("GameOverRoutine");
                }
                else
                    StartCoroutine("GameOverRoutine");
                break;
            case 1 :
                if (score >= 70)
                {
                    if (nowStage == 1)
                        nowStage = nowStage + 1;
                    PlayerPrefs.SetInt("levelReached", nowStage);
                    StartCoroutine("GameOverRoutine");
                }
                else
                    StartCoroutine("GameOverRoutine");
                break;
            case 2 :
                if (score >= 90)
                {
                    if (nowStage == 2)
                        nowStage = nowStage + 1;
                    PlayerPrefs.SetInt("levelReached", nowStage);
                    StartCoroutine("GameOverRoutine");
                }
                else
                    StartCoroutine("GameOverRoutine");                
                break;
            case 3 :
                if (score >= 110)
                {
                    if (nowStage == 3)
                        nowStage += 1;
                    PlayerPrefs.SetInt("levelReached", nowStage);
                    StartCoroutine("GameOverRoutine");
                }
                else
                    StartCoroutine("GameOverRoutine");                
                break;
            case 4 : 
                if (score >= 130)
                {
                    if (nowStage == 4)
                        nowStage += 1;
                    PlayerPrefs.SetInt("levelReached", nowStage);
                    StartCoroutine("GameOverRoutine");
                }
                else
                    StartCoroutine("GameOverRoutine");
                break;
            case 5 : 
                if (score >= 150)
                {
                    if (nowStage == 5)
                        nowStage += 1;
                    PlayerPrefs.SetInt("levelReached", nowStage);
                    StartCoroutine("GameOverRoutine");
                }
                else
                    StartCoroutine("GameOverRoutine");
                break;
            case 6 :
                if (score >= 170)
                {
                    if (nowStage == 6)
                        nowStage += 1;
                    PlayerPrefs.SetInt("levelReached", nowStage);
                    StartCoroutine("GameOverRoutine");
                }
                else
                    StartCoroutine("GameOverRoutine");
                break;
            case 7 :
                if (score >= 190)
                {
                    if (nowStage == 7)
                        nowStage += 1;
                    PlayerPrefs.SetInt("levelReached", nowStage);
                    StartCoroutine("GameOverRoutine");
                }
                else
                    StartCoroutine("GameOverRoutine");
                break;
        }

        
    }

    IEnumerator GameOverRoutine()
    {
        //1. 장면 안의 활성화된 모든 동글 가져오기
        Dongle[] dongles = FindObjectsOfType<Dongle>();

        // 2. 지우기 전에 모든 동글의 물리효과 비활성화
         for (int index = 0; index < dongles.Length; index++)
        {
            dongles[index].rigid.simulated = false;
        }       

        //2. 1번의 목록을 하나씩 접근해서 지우기
        for (int index = 0; index < dongles.Length; index++)
        {
            dongles[index].Hide(Vector3.up * 100);
            yield return new WaitForSeconds(0.1f);
        }

        yield return new WaitForSeconds(0.7f);

        //최고 점수 갱신    
        int maxScore = Mathf.Max(score, PlayerPrefs.GetInt("MaxScore"));
        PlayerPrefs.SetInt("MaxScore", maxScore);

        //게임 오버 UI 표시
        subScoreText.text = "점수 : " + scoreText.text;
        endGroup.SetActive(true);

        SoundManager.instance.BgmPlayer.Stop();
        SoundManager.instance.SfxPlay(SoundManager.Sfx.Over);
    }

    public void Reset()
    {
        SoundManager.instance.SfxPlay(SoundManager.Sfx.Button);
        StartCoroutine("ResetCoroutine");
    }

    IEnumerator ResetCoroutine()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Main");
    }

    void LateUpdate()
    {
        scoreText.text = score.ToString();
    }

    public void Selectreturn()
    {
        SoundManager.instance.SfxPlay(SoundManager.Sfx.Button);
        StartCoroutine("ReturnCoroutine");
    }

    IEnumerator ReturnCoroutine()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Select");
    }

    void StartUI()
    {
        if (startUISelect == 0)
        {
            startGroup[startUISelect].gameObject.SetActive(true);
            Invoke("FadeUI", 3f);
        }
        else if (startUISelect == 1)
        {
            startGroup[startUISelect].gameObject.SetActive(true);
            Invoke("FadeUI", 3f);
        }
        else if (startUISelect == 2)
        {
            startGroup[startUISelect].gameObject.SetActive(true);
            Invoke("FadeUI", 3f);
        }
        else if (startUISelect == 3)
        {
            startGroup[startUISelect].gameObject.SetActive(true);
            Invoke("FadeUI", 3f);
        }
        else if (startUISelect == 4)
        {
            startGroup[startUISelect].gameObject.SetActive(true);
            Invoke("FadeUI", 3f);
        }
        else if (startUISelect == 5)
        {
            startGroup[startUISelect].gameObject.SetActive(true);
            Invoke("FadeUI", 3f);
        }
        else if (startUISelect == 6)
        {
            startGroup[startUISelect].gameObject.SetActive(true);
            Invoke("FadeUI", 3f);
        }
        else if (startUISelect == 7)
        {
            startGroup[startUISelect].gameObject.SetActive(true);
            Invoke("FadeUI", 3f);
        }
    }

    void FadeUI()
    {
        if (startUISelect ==  0)
        {
            startGroup[startUISelect].gameObject.SetActive(false);
        }
        else if (startUISelect == 1)
        {
            startGroup[startUISelect].gameObject.SetActive(false);
        }
        else if (startUISelect == 2)
        {
            startGroup[startUISelect].gameObject.SetActive(false);
        }
        else if (startUISelect == 3)
        {
            startGroup[startUISelect].gameObject.SetActive(false);
        }
        else if (startUISelect == 4)
        {
            startGroup[startUISelect].gameObject.SetActive(false);
        }
        else if (startUISelect == 5)
        {
            startGroup[startUISelect].gameObject.SetActive(false);
        }
        else if (startUISelect == 6)
        {
            startGroup[startUISelect].gameObject.SetActive(false);
        }
        else if (startUISelect == 7)
        {
            startGroup[startUISelect].gameObject.SetActive(false);
        }
    }
}
