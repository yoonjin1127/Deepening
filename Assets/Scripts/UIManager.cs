using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private InventoryManager inventoryManager;

    // 스탯, 인벤토리 창
    [Header("스탯, 인벤토리 창")]
    [SerializeField] private GameObject statusUI;
    [SerializeField] private GameObject inventoryUI;

    // 가려지는 버튼
    [SerializeField] private GameObject buttons;

    // 아이템 랜덤 뽑기 버튼
    public void OnClickSpawn()
    {
        inventoryManager.TryAddRandomItem();
    }

    // Status 보기 버튼
    public void OnClickStatus()
    {
        statusUI.SetActive(true);
        buttons.SetActive(false);
    }

    // Inventory 보기 버튼
    public void OnClickInventory()
    {
        inventoryUI.SetActive(true);
        buttons.SetActive(false);
    }

    // Status 닫기 버튼
    public void OnClickCloseStatus()
    {
        statusUI.SetActive(false);
        buttons.SetActive(true);
    }

    // Inventory 닫기 버튼
    public void OnClickCloseInventory()
    {
        inventoryUI.SetActive(false);
        buttons.SetActive(true);
    }
}
