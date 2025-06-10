using UnityEngine;

public class PlayerStatus : Singleton<PlayerStatus>
{
    // [Header("플레이어 스탯")]
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
        UIManager.Instance.playerInfo.text = "귀여운 전사입니다. 아이템을 뽑고 장착하는 것 외에는 할 줄 아는 행동이 없습니다.\n아이템을 뽑을 때마다 경험치가 증가합니다.";
    }

    // 아이템 장착
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

    // 아이템 장착 해제
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

    // 골드 소모
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
            Debug.Log("골드가 부족합니다.");
            return false;
        }
    }

    // 경험치 증가
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

    // 레벨 업
    public void LevelUp()
    {
        level++;
        Debug.Log("레벨 업!");
    }
}
