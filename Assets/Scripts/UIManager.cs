using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private InventoryManager inventoryManager;

    // ����, �κ��丮 â
    [Header("����, �κ��丮 â")]
    [SerializeField] private GameObject statusUI;
    [SerializeField] private GameObject inventoryUI;

    // �������� ��ư
    [SerializeField] private GameObject buttons;

    // ������ ���� �̱� ��ư
    public void OnClickSpawn()
    {
        inventoryManager.TryAddRandomItem();
    }

    // Status ���� ��ư
    public void OnClickStatus()
    {
        statusUI.SetActive(true);
        buttons.SetActive(false);
    }

    // Inventory ���� ��ư
    public void OnClickInventory()
    {
        inventoryUI.SetActive(true);
        buttons.SetActive(false);
    }

    // Status �ݱ� ��ư
    public void OnClickCloseStatus()
    {
        statusUI.SetActive(false);
        buttons.SetActive(true);
    }

    // Inventory �ݱ� ��ư
    public void OnClickCloseInventory()
    {
        inventoryUI.SetActive(false);
        buttons.SetActive(true);
    }
}
