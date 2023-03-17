using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwipeUI : MonoBehaviour
{
    [SerializeField]
    private Scrollbar scrollBar; //scrollbar의 위치를 바탕으로 현재 페이지 검사
    [SerializeField]
    private float swipeTime = 0.2f; // 페이지 스왑 되는 시간
    [SerializeField]
    private float swipeDistance = 50.0f; //페이지가 swipe되기 위해 움직여야 하는 최소 거리

    private float[] scrollPageValues; //각 페이지 위치 값
    private float valueDistance = 0; // 각 페이지 사이의 거리
    private int currentPage = 0; //현재 페이지
    private int maxPage = 0; //최대 페이지
    private float startTouchX; //터치 시작 위치
    private float endTouchX; //터치 종료 위치
    private bool isSwipeMode = false; //현재 swipe 되고 있는지 체크

    //사운드 ui 관련 스크립트 가져오기
    public GameObject soundui_get;

    private void Awake()
    {
        //스크롤 되는 페이지의 각 value 값을 저장하는 배열 메모리 할당
        scrollPageValues = new float[transform.childCount];

        //스크롤 되는 페이지 사이의 거리
        valueDistance = 1f / (scrollPageValues.Length - 1f);

        // 스크롤 되는 페이지의 각 value 위치 설정 [0 <- value <- 1]
        for (int i = 0; i < scrollPageValues.Length; ++ i)
        {
            scrollPageValues[i] = valueDistance * i;
        }

        //최대 페이지의 수
        maxPage = transform.childCount;
    }

    private void Start()
    {
        //최초 시작할 때 0번 페이지를 볼 수 있도록 설정
        SetScrollBarValue(0);
    }

    public void SetScrollBarValue(int index)
    {
        currentPage = index;
        scrollBar.value = scrollPageValues[index];
    }

    private void Update()
    {
        if ( soundui_get.GetComponent<SelectUI>().soundui == false)
        {
            UpdateInput();
        }       
    }

    private void UpdateInput()
    {
        // 현재 swipe를 진행중이면 터치 불가
        if ( isSwipeMode == true ) return;

        #if UNITY_EDITOR
        //마우스 왼쪽 버튼을 눌렀을 때 1회
        if (Input.GetMouseButtonDown(0))
        {
            // 터치 시작 지점 (swipe 방향 구분)
            startTouchX = Input.mousePosition.x;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            // 터치 종료 시점 (swipe 방향 구분)
            endTouchX = Input.mousePosition.x;

            UpdateSwipe();
        }
        #endif

        #if UNITY_ANDROID
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                //터치 시작 지점 ( Swipe 방향 구분)
                startTouchX = touch.position.x;
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                //터치 종료 시점 (Swipe 방향 구분)
                endTouchX = touch.position.x;

                UpdateSwipe();
            }
        }
        #endif
    }

    private void UpdateSwipe()
    {
        //너무 작은 거리를 움직였을 때는 swipe x
        if (Mathf.Abs(startTouchX-endTouchX) < swipeDistance)
        {
            //원래 페이지로 swipe해서 돌아간다
            StartCoroutine(OnSwipeOneStep(currentPage));
            return;
        }

        //swipe 방향
        bool isLeft = startTouchX < endTouchX ? true : false;

        //이동 방향이 왼쪽일 때
        if (isLeft == true)
        {
            //현재 페이지가 왼쪽 끝이면 종료
            if (currentPage == 0) return;

            //왼쪽에서 이동을 위해 현재 페이지를 1 감소
            currentPage --;
        }
        // 이동 방향이 오른쪽일 때
        else
        {
            if (currentPage == maxPage - 1) return;

            //오른쪽으로 이동을 위해 현재 페이지를 1증가
            currentPage ++;
        }

        //currentIndex번째 페이지로 swipe해서 이동
        StartCoroutine(OnSwipeOneStep(currentPage));
    }

    //페이지를 한장 앞으로 넘기는 swipe 효과 재생
    private IEnumerator OnSwipeOneStep(int index)
    {
        float start = scrollBar.value;
        float current = 0;
        float percent = 0;

        isSwipeMode = true;

        while (percent < 1)
        {
            current += Time.deltaTime;
            percent = current / swipeTime;

            scrollBar.value = Mathf.Lerp(start, scrollPageValues[index], percent);

            yield return null;
        }

        isSwipeMode = false;
    }

    
}
