# Metaverse in Sparta

## 📖 프로젝트 개요
Unity 기반의 메인 씬에서 다양한 미니게임으로 진입할 수 있는 멀티 미니게임 허브 프로젝트입니다.  
플레이어는 메인 씬에서 상호작용(F 키)을 통해 두 가지 미니게임(Flappy Plane, Dungeon)에 진입하여 점수를 획득하고, 메인 UI에 최고 기록을 확인할 수 있습니다.

구현 과정 기록 [https://www.notion.so/Metaverse-In-Sparta_Project-1e6dd79e416180b7aceee4683860ecd0#1ecdd79e4161801f99effdef18653264]

## 🚀 주요 기능(필수 기능 구현)
- **메인 씬**  
  - 플레이어 이동 (WASD 또는 방향키)  
  - 상호작용(F 키) 기반 진입 시스템  
  - 최고 기록 표시 UI (TextMeshPro)  
- **Flappy Plane 미니게임**  
  - 클릭 또는 스페이스바로 시작/조작  
  - 장애물을 피하며 최대 점수 도전  
- **Dungeon 미니게임**  
  - WASD 이동 및 마우스 클릭 공격  
  - 웨이브 별 몬스터 처치 및 최고 웨이브 기록  
- **점수 관리**  
  - MasterGameManager를 통한 점수 수집 및 메인 UI 연동  
- **씬 관리**  
  - Additive 로드/언로드 기반 Pause/Resume 구조
- **커스텀 캐릭터**
  - UI 메뉴를 통해 커스텀 캐릭터 장착 가능

