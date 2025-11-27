
# 🏗 Unity Inventory & Player Stats UI System

## ✅ 프로젝트 개요
Unity 기반으로 제작된 **인벤토리 시스템**과 **플레이어 스탯 UI** 구현 프로젝트입니다.  
플레이어는 아이템을 획득하고 인벤토리에서 관리하며, 스탯을 확인할 수 있습니다.  
UI는 직관적이고 확장 가능하도록 설계되었습니다.

---

## 🗂 프로젝트 구조

```
Assets/
 ├── Scripts/
 │    ├── Character.cs        // 플레이어 캐릭터 데이터 및 스탯 관리
 │    ├── GameManager.cs      // 게임 전체 흐름 관리 (Singleton)
 │    ├── Item.cs             // 아이템 기본 클래스
 │    ├── ItemData.cs         // 아이템 데이터 (ScriptableObject)
 │    ├── UIInventory.cs      // 인벤토리 UI 컨트롤
 │    ├── UIMainMenu.cs       // 메인 메뉴 UI 컨트롤
 │    ├── UIManager.cs        // UI 전반 관리 (Singleton)
 │    ├── UISlot.cs           // 인벤토리 슬롯 UI
 │    ├── UIStatus.cs         // 플레이어 스탯 UI
```
---

## 🔑 주요 스크립트 설명
- **Character.cs**  
  플레이어의 체력, 공격력, 방어력 등 스탯 관리 및 아이템 장착/해제 기능 포함

- **GameManager.cs (Singleton)**  
  게임 전체 상태 관리 (시작, 종료, 씬 전환 등)

- **Item.cs & ItemData.cs**  
  - `Item.cs`: 아이템의 기본 속성 및 동작 정의  
  - `ItemData.cs`: ScriptableObject로 아이템 데이터 관리

- **UIManager.cs (Singleton)**  
  모든 UI 요소를 중앙에서 관리 (UI 열기/닫기, 상태 업데이트 등)

- **UIInventory.cs & UISlot.cs**  
  인벤토리 UI 표시 및 슬롯 관리 (드래그 앤 드롭, 아이템 사용 기능)

- **UIStatus.cs**  
  플레이어 스탯 UI 업데이트 (Character.cs와 연동)

- **UIMainMenu.cs**  
  메인 메뉴 UI 처리 (게임 시작, 종료 버튼 등)

---

## 🛠 싱글톤 패턴 사용 이유
- **GameManager.cs**  
  게임 전체 상태를 어디서든 접근 가능하도록 하기 위해 사용
- **UIManager.cs**  
  UI 제어를 중앙 집중화하여 관리 효율성 향상

---

## 🚀 실행 방법
1. Unity에서 프로젝트 열기
2. `GameManager`와 `UIManager` 프리팹을 씬에 배치
3. `ItemData` ScriptableObject 생성 후 아이템 데이터 설정
4. 플레이 모드에서 인벤토리 및 스탯 UI 확인

---

## 📌 확장 포인트
- 저장/로드 기능 추가
- 전투시스템 구현
