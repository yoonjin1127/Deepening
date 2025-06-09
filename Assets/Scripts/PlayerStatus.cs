using TMPro;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    // [Header("�÷��̾� ����")]
    public int attack { get; private set; } = 35;
    public int defense { get; private set; } = 40;
    public int health { get; private set; } = 100;
    public float critical { get; private set; } = 25;
    public int gold { get; private set; } = 20000;

    // ������ ����
    public void ApplyItem(ItemData item)
    {
        attack += item.attack;
        defense += item.defense;
        health += item.health;
        critical += item.critical;

        UIManager.Instance.attackText.text = attack.ToString();
        UIManager.Instance.defenseText.text = defense.ToString();
        UIManager.Instance.healthText.text = health.ToString();
        UIManager.Instance.criticalText.text = critical.ToString();
    }

    // ������ ���� ����
    public void RemoveItem(ItemData item)
    {
        attack -= item.attack;
        defense -= item.defense;
        health -= item.health;
        critical -= item.critical;

        UIManager.Instance.attackText.text = attack.ToString();
        UIManager.Instance.defenseText.text = defense.ToString();
        UIManager.Instance.healthText.text = health.ToString();
        UIManager.Instance.criticalText.text = critical.ToString();
    }
}
