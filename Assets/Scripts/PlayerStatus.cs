using TMPro;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    [Header("�÷��̾� ����")]
    [SerializeField] private int attack;
    [SerializeField] private int defense;
    [SerializeField] private int health;
    [SerializeField] private float critical;

    [Header("���� �ؽ�Ʈ")]
    [SerializeField] private TextMeshProUGUI attackText;
    [SerializeField] private TextMeshProUGUI defenseText;
    [SerializeField] private TextMeshProUGUI healthText;
    [SerializeField] private TextMeshProUGUI criticalText;

    // ������ ����
    public void ApplyItem(ItemData item)
    {
        attack += item.attack;
        defense += item.defense;
        health += item.health;
        critical += item.critical;

        attackText.text = attack.ToString();
        defenseText.text = defense.ToString();
        healthText.text = health.ToString();
        criticalText.text = critical.ToString();
    }

    // ������ ���� ����
    public void RemoveItem(ItemData item)
    {
        attack -= item.attack;
        defense -= item.defense;
        health -= item.health;
        critical -= item.critical;

        attackText.text = attack.ToString();
        defenseText.text = defense.ToString();
        healthText.text = health.ToString();
        criticalText.text = critical.ToString();
    }
}
