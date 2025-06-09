using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] private GameObject slotPrefab;
    [SerializeField] private Transform slotParent;

    [Header("슬롯 개수")]
    [SerializeField] private int slotCount;

    // 현재 착용 중인 슬롯
    private InventorySlot equippedSlot = null;

    // 인벤토리 전체 슬롯 리스트
    private List<InventorySlot> slotList = new List<InventorySlot>();

    // 뽑기로 나올 수 있는 아이템 데이터 리스트
    [Header("아이템 풀")]
    [SerializeField] private List<ItemData> itemPool;     

    private void Start()
    {
        CreateSlots(slotCount);
    }

    // 초기 슬롯 생성 및 리스트 추가
    public void CreateSlots(int count)
    {
        for (int i = 0; i < count; i++)
        {
            GameObject newSlot = Instantiate(slotPrefab, slotParent);
            InventorySlot slot = newSlot.GetComponent<InventorySlot>();
            slotList.Add(slot);
        }
    }

    // 슬롯 클릭 시 아이템 중복 착용 못 하게 하기
    public void OnSlotClicked(InventorySlot clickedSlot)
    {
        // 현재 착용한 아이템이 있고, 클릭한 슬롯이 장착한 슬롯이 아닐 때
        if(equippedSlot != null && equippedSlot != clickedSlot)
        {
            // 다른 슬롯이 착용 중일 때 해제
            equippedSlot.UnEquipItem();
        }

        // 클릭된 슬롯이 장착되었으면 저장
        equippedSlot = clickedSlot.IsEquipped() ? clickedSlot : null;
    }

    // 아이템 뽑기
    public void TryAddRandomItem()
    {
        // 빈 슬롯 찾기
        InventorySlot emptySlot = null;

        foreach (InventorySlot slot in slotList)
        {
            if(!slot.HasItem())
            {
                // 첫 번째 빈 슬롯을 찾고 반복 종료
                emptySlot = slot;
                break;
            }
        }

        if(emptySlot == null)
        {
            Debug.Log("인벤토리가 꽉 찼습니다.");
            return;
        }

        // 아이템 뽑기
        int randomIndex = Random.Range(0, itemPool.Count);
        ItemData randomItem = itemPool[randomIndex];

        // 슬롯에 아이템 넣기
        emptySlot.SetItem(randomItem);
    }
}
