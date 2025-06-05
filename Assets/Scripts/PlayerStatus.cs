using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    [SerializeField] private int attack;
    [SerializeField] private int defense;
    [SerializeField] private int health;
    [SerializeField] private float critical;

    // ������ ����
    public void ApplyItem(ItemData item)
    {
        attack += item.attack;
        defense += item.defense;
        health += item.health;
        critical += item.critical;
    }

    // ������ ���� ����
    public void RemoveItem(ItemData item)
    {
        attack -= item.attack;
        defense -= item.defense;
        health -= item.health;
        critical -= item.critical;
    }
}
