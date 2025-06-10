using UnityEngine;

public class PlayerStatus : Singleton<PlayerStatus>
{
    // [Header("�÷��̾� ����")]
    public int attack { get; private set; } = 35;
    public int defense { get; private set; } = 40;
    public int health { get; private set; } = 100;
    public float critical { get; private set; } = 25;

    public int gold { get; private set; } = 20000;

    public int level { get; private set; } = 1;
    public int exp { get; private set; } = 0;
    public int requiredExp { get; private set; } = 100;

    private void Start()
    {
        UIManager.Instance.playerInfo.text = "�Ϳ��� �����Դϴ�. �������� �̰� �����ϴ� �� �ܿ��� �� �� �ƴ� �ൿ�� �����ϴ�.\n�������� ���� ������ ����ġ�� �����մϴ�.";
    }

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

    // ��� �Ҹ�
    public bool TrySpendGold(int amount)
    {
        if(gold >= amount)
        {
            gold -= amount;
            UIManager.Instance.goldText.text = gold.ToString("N0");
            return true;
        }

        else
        {
            Debug.Log("��尡 �����մϴ�.");
            return false;
        }
    }

    // ����ġ ����
    public void ExpUp(int amount)
    {
        exp += amount;

        while(exp >= requiredExp)
        {
            exp -= requiredExp;
            LevelUp();
        }

        UIManager.Instance.UpdateExpUI(exp, requiredExp);
    }

    // ���� ��
    public void LevelUp()
    {
        level++;
        Debug.Log("���� ��!");
    }
}
