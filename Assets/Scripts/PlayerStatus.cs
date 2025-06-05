using TMPro;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    [Header("플레이어 스탯")]
    [SerializeField] private int attack;
    [SerializeField] private int defense;
    [SerializeField] private int health;
    [SerializeField] private float critical;

    [Header("스탯 텍스트")]
    [SerializeField] private TextMeshProUGUI attackText;
    [SerializeField] private TextMeshProUGUI defenseText;
    [SerializeField] private TextMeshProUGUI healthText;
    [SerializeField] private TextMeshProUGUI criticalText;

    // 아이템 장착
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

    // 아이템 장착 해제
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
