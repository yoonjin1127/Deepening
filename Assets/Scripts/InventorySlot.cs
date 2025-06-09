using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    [SerializeField] private Image icon;
    [SerializeField] private GameObject EquipImage;
    private ItemData itemData;

    // 장착 여부
    private bool isEquipped = false;

    // 장착 중인지 확인하는 읽기 전용
    public bool IsEquipped() => isEquipped;


    // 현재 슬롯에 들어 있는 아이템
    private ItemData currentItem = null;

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(OnClickSlot);
    }

    // 슬롯에 아이템이 들어 있는지 확인
    public bool HasItem()
    {
        return currentItem != null;
    }

    // 슬롯에 아이템 추가
    public void SetItem(ItemData newItem)
    {
        itemData = newItem;
        currentItem = newItem;
        icon.sprite = itemData.icon;
        icon.gameObject.SetActive(true);
        isEquipped = false;

        // 슬롯 개수 세기
        InventoryManager.Instance.OnItemAdd();
    }

    // 장착
    public void EquipItem()
    {
        EquipImage.SetActive(true);
        PlayerStatus.Instance.ApplyItem(itemData);
        isEquipped = true;
    }

    // 장착 해제
    public void UnEquipItem()
    {
        EquipImage.SetActive(false);
        PlayerStatus.Instance.RemoveItem(itemData);
        isEquipped = false;
    }

    // 슬롯을 클릭했을 때 장착
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

        // 인벤토리 매니저에 현재 상태 전달
        InventoryManager.Instance.OnSlotClicked(this);
    }
}
