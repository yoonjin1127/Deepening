using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    [SerializeField] private InventoryManager inventoryManager;

    // ����, �κ��丮 â
    [Header("����, �κ��丮 â")]
    [SerializeField] private GameObject statusUI;
    [SerializeField] private GameObject inventoryUI;
    public TextMeshProUGUI slotCount;

    // �������� ��ư
    [SerializeField] private GameObject buttons;

    [Header("���� �ؽ�Ʈ")]
    public TextMeshProUGUI attackText;
    public TextMeshProUGUI defenseText;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI criticalText;
    public TextMeshProUGUI goldText;
    public TextMeshProUGUI playerInfo;

    [Header("����, ����ġ")]
    public Slider expSlider;
    public TextMeshProUGUI levelText;

    protected override void Awake()
    {
        // �̱��� �ʱ�ȭ
        base.Awake();
        expSlider.value = 0;
    }

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

    // ����ġ, ���� ui ����
    public void UpdateExpUI(int curExp, int maxExp)
    {
        expSlider.maxValue = maxExp;
        expSlider.value = curExp;
        levelText.text = PlayerStatus.Instance.level.ToString();
    }
}
