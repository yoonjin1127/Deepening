using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : Singleton<InventoryManager>
{
    [SerializeField] private GameObject slotPrefab;
    [SerializeField] private Transform slotParent;

    [Header("���� ����")]
    [SerializeField] private int slotCount;

    // ���� ���� ���� ����
    private InventorySlot equippedSlot = null;

    // �κ��丮 ��ü ���� ����Ʈ
    private List<InventorySlot> slotList = new List<InventorySlot>();

    // �̱�� ���� �� �ִ� ������ ������ ����Ʈ
    [Header("������ Ǯ")]
    [SerializeField] private List<ItemData> itemPool;     

    private void Start()
    {
        CreateSlots(slotCount);
    }

    // �ʱ� ���� ���� �� ����Ʈ �߰�
    public void CreateSlots(int count)
    {
        for (int i = 0; i < count; i++)
        {
            GameObject newSlot = Instantiate(slotPrefab, slotParent);
            InventorySlot slot = newSlot.GetComponent<InventorySlot>();
            slotList.Add(slot);
        }
    }

    // ���� Ŭ�� �� ������ �ߺ� ���� �� �ϰ� �ϱ�
    public void OnSlotClicked(InventorySlot clickedSlot)
    {
        // ���� ������ �������� �ְ�, Ŭ���� ������ ������ ������ �ƴ� ��
        if(equippedSlot != null && equippedSlot != clickedSlot)
        {
            // �ٸ� ������ ���� ���� �� ����
            equippedSlot.UnEquipItem();
        }

        // Ŭ���� ������ �����Ǿ����� ����
        equippedSlot = clickedSlot.IsEquipped() ? clickedSlot : null;
    }

    // ������ �̱�
    public void TryAddRandomItem()
    {
        // �̱� ���
        int gatchaCost = 1000;

        // ��尡 ������� Ȯ��
        if(!PlayerStatus.Instance.TrySpendGold(gatchaCost))
        {
            return;
        }

        // �� ���� ã��
        InventorySlot emptySlot = null;

        foreach (InventorySlot slot in slotList)
        {
            if(!slot.HasItem())
            {
                // ù ��° �� ������ ã�� �ݺ� ����
                emptySlot = slot;
                break;
            }
        }

        if(emptySlot == null)
        {
            Debug.Log("�κ��丮�� �� á���ϴ�.");
            return;
        }

        // ������ �̱�
        int randomIndex = Random.Range(0, itemPool.Count);
        ItemData randomItem = itemPool[randomIndex];

        // ���Կ� ������ �ֱ�
        emptySlot.SetItem(randomItem);
    }

    // ������ ���� ���� ����
    public void OnItemAdd()
    {
        int itemCount = 0;

        foreach(InventorySlot slot in slotList)
        {
            if(slot.HasItem())
            {
                itemCount++;
            }
        }

        // ui ����
        UIManager.Instance.slotCount.text = itemCount.ToString("N0");
    }
}
