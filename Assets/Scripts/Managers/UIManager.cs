using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    [SerializeField] private InventoryManager inventoryManager;

    // 스탯, 인벤토리 창
    [Header("스탯, 인벤토리 창")]
    [SerializeField] private GameObject statusUI;
    [SerializeField] private GameObject inventoryUI;
    public TextMeshProUGUI slotCount;

    // 가려지는 버튼
    [SerializeField] private GameObject buttons;

    [Header("스탯 텍스트")]
    public TextMeshProUGUI attackText;
    public TextMeshProUGUI defenseText;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI criticalText;
    public TextMeshProUGUI goldText;
    public TextMeshProUGUI playerInfo;

    [Header("레벨, 경험치")]
    public Slider expSlider;
    public TextMeshProUGUI levelText;

    protected override void Awake()
    {
        // 싱글톤 초기화
        base.Awake();
        expSlider.value = 0;
    }

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

    // 경험치, 레벨 ui 갱신
    public void UpdateExpUI(int curExp, int maxExp)
    {
        expSlider.maxValue = maxExp;
        expSlider.value = curExp;
        levelText.text = PlayerStatus.Instance.level.ToString();
    }
}
