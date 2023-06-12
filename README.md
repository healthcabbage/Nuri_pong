# Nuri_pong[누리퐁]
<p align="center">
  <img src="https://github.com/healthcabbage/image/assets/49223403/3ad1c983-6bfb-4f1c-8b3c-909029433908">
</p>

## 프로젝트 소개
유니티에서 제작된 모바일 기반 물리퍼즐게임입니다.   


## 게임 플레이
같은 그림을 맞춰 점수를 올릴 수 있습니다.   
각 스테이지마다 클리어 점수가 존재하며, 해당 스테이지의 클리어 점수를 넘으면 다음 스테이지가 해금됩니다.


## 사용 언어 및 환경
프로그래밍 언어 : C#   
게임 엔진 : Unity(2021.3.6f1)


## 주요 기능
- 시작 -> 선택 -> 메인 게임 맵 이동

- BGM, SFX 추가 및 선택 씬에서 사운드 조절 기능

- 스테이지 락 기능 추가 & 게임 클리어 시 해당 스테이지 클리어 표시

- 드래그로 스테이지 범위 확인

- 같은 그림과 충돌하면 충돌한 그림들은 사라지고 새로운 그림이 생기며 그림은 총 7단계까지 생성

- 생성되는 그림은 현재 돌파한 그림까지만 생성

- 일정 범위를 넘어가면 게임 오버

- 메인 게임 진입 시 클리어 조건 확인

- 클리어 점수를 넘을 시 클리어 & 점수 부족시 게임 오버

## 사용 코드
### 메인 게임
[GameManager](https://github.com/healthcabbage/Nuri_pong/blob/main/Assets/Scripts/GameManager.cs)   
[Dongle](https://github.com/healthcabbage/Nuri_pong/blob/main/Assets/Scripts/Dongle.cs)

### 선택 씬
[LevelClear](https://github.com/healthcabbage/Nuri_pong/blob/main/Assets/Scripts/LevelClear.cs)
[LevelLock](https://github.com/healthcabbage/Nuri_pong/blob/main/Assets/Scripts/LevelLock.cs)
[SelectUI](https://github.com/healthcabbage/Nuri_pong/blob/main/Assets/Scripts/SelectUI.cs)
[NowStage](https://github.com/healthcabbage/Nuri_pong/blob/main/Assets/Scripts/NowStage.cs)
[SwipeUI](https://github.com/healthcabbage/Nuri_pong/blob/main/Assets/Scripts/SwipeUI.cs)

### 시작 씬
[MenuPatten](https://github.com/healthcabbage/Nuri_pong/blob/main/Assets/Scripts/MenuPatten.cs)
[StartUIManager](https://github.com/healthcabbage/Nuri_pong/blob/main/Assets/Scripts/StartUIManager.cs)

## 사운드
[SoundManager](https://github.com/healthcabbage/Nuri_pong/blob/main/Assets/Scripts/SoundManager.cs]
