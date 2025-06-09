using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    [SerializeField] private Image icon;
    [SerializeField] private GameObject EquipImage;
    private ItemData itemData;

    // ���� ����
    private bool isEquipped = false;

    // ���� ������ Ȯ���ϴ� �б� ����
    public bool IsEquipped() => isEquipped;


    // ���� ���Կ� ��� �ִ� ������
    private ItemData currentItem = null;


    private PlayerStatus status;
    private InventoryManager inventoryManager;

    private void Start()
    {
        status = FindObjectOfType<PlayerStatus>();
        inventoryManager = FindObjectOfType<InventoryManager>();
        GetComponent<Button>().onClick.AddListener(OnClickSlot);
    }

    // ���Կ� �������� ��� �ִ��� Ȯ��
    public bool HasItem()
    {
        return currentItem != null;
    }

    // ���Կ� ������ �߰�
    public void SetItem(ItemData newItem)
    {
        itemData = newItem;
        currentItem = newItem;
        icon.sprite = itemData.icon;
        icon.gameObject.SetActive(true);
        isEquipped = false;

        // ���� ���� ����
        inventoryManager.OnItemAdd();
    }

    // ����
    public void EquipItem()
    {
        EquipImage.SetActive(true);
        status.ApplyItem(itemData);
        isEquipped = true;
    }

    // ���� ����
    public void UnEquipItem()
    {
        EquipImage.SetActive(false);
        status.RemoveItem(itemData);
        isEquipped = false;
    }

    // ������ Ŭ������ �� ����
    public void OnClickSlot()
    {
        if (itemData == null) return;

        if(isEquipped)
        {
            UnEquipItem();
        }
        else
        {
            EquipItem();
        }

        // �κ��丮 �Ŵ����� ���� ���� ����
        inventoryManager.OnSlotClicked(this);
    }
}
