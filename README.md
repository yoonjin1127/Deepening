# 🎮 심화 주차 인벤토리 과제입니다.

---

## 📋 기능 정리

### ✅ 1. 플레이어 스탯 UI 갱신
- 공격력, 방어력, 체력, 치명타 수치를 `PlayerStatus`에서 관리
- UI 텍스트는 `UIManager.Instance`를 통해 자동 갱신

**사용 예시**
```csharp
PlayerStatus.Instance.ApplyItem(item);
PlayerStatus.Instance.RemoveItem(item);
```

---

### ✅ 2. 골드 소모 시스템
- `TrySpendGold(int amount)` 호출로 소모 시도
- 소모 성공 시 UI 갱신

**사용 예시**
```csharp
if (PlayerStatus.Instance.TrySpendGold(1000))
{
    // 뽑기 성공 처리
}
```

---

### ✅ 3. 경험치 & 레벨업 슬라이더
- 경험치를 얻으면 슬라이더와 레벨 텍스트 갱신
- `PlayerStatus.ExpUp()` 호출

**사용 예시**
```csharp
PlayerStatus.Instance.ExpUp(25);
```

---

### ✅ 4. 인벤토리 시스템
- `InventoryManager`가 슬롯을 자동 생성
- 슬롯 클릭 시 아이템 장착/해제 가능
- `TryAddRandomItem()` 호출 시 빈 슬롯에 랜덤 아이템 추가

**사용 예시**
```csharp
InventoryManager.Instance.TryAddRandomItem();
```

---

### ✅ 5. 인벤토리 슬롯 수 갱신
- 슬롯에 아이템이 추가될 때마다 `UIManager`의 슬롯 수 텍스트 갱신

**자동 처리됨** (`InventorySlot.SetItem()` 내부에서 호출)

---

## 🗂️ 주요 스크립트

| 파일 | 기능 |
|------|------|
| `PlayerStatus.cs` | 플레이어 스탯, 경험치, 골드 관리 |
| `UIManager.cs` | UI 텍스트 및 슬라이더 관리 |
| `InventoryManager.cs` | 인벤토리 슬롯 생성 및 뽑기 처리 |
| `InventorySlot.cs` | 개별 슬롯에서 아이템 처리 |
| `ItemData.cs` | 아이템 정보 정의 (ScriptableObject) |
| `Singleton.cs` | 제네릭 싱글톤 패턴 |
