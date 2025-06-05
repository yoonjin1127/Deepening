using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    [SerializeField] private int attack;
    [SerializeField] private int defense;
    [SerializeField] private int health;
    [SerializeField] private float critical;

    // 아이템 장착
    public void ApplyItem(ItemData item)
    {
        attack += item.attack;
        defense += item.defense;
        health += item.health;
        critical += item.critical;
    }

    // 아이템 장착 해제
    public void RemoveItem(ItemData item)
    {
        attack -= item.attack;
        defense -= item.defense;
        health -= item.health;
        critical -= item.critical;
    }
}
