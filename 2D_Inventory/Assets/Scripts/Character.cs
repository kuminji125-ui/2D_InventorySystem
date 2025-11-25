using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] public string _name { get; private set; }
    [SerializeField] public int _level { get; private set; }
    [SerializeField] public int _gold { get; private set; }
    [SerializeField] public string _description { get; private set; }
    [SerializeField] public string _job { get; private set; }
    [SerializeField] public int _attack {  get; private set; }
    [SerializeField] public int _defense {  get; private set; }
    [SerializeField] public int _health {  get; private set; }
    [SerializeField] public int _critical {  get; private set; }

    public List<Item> Inventory {  get; private set; }
    public string Name => _name;
    public int Level => _level;
    public int Gold => _gold;
    public string Description => _description;
    public string Job => _job;

    public int Attack => _attack;
    public int Defense => _defense;
    public int Health => _health;
    public int Critical => _critical;
    public void SetData(string name, int level, int gold, string description, string job,int attack, int defense, int health, int critical)
    {
        _name = name;
        _level = level;
        _gold = gold;
        _description = description;
        _job = job;
        _attack = attack;
        _defense = defense;
        _health = health;
        _critical = critical;
    }
    void Awake()
    {
        Inventory = new List<Item>();
        GameManager.Instance.player = this;    
    }
    public void AddItem(Item item)
    {
        Item existingItem = Inventory.Find(i => i.Data == item.Data);
        if (existingItem != null)
        {
            Debug.Log("똑같은거 있음");
            if (existingItem.Data.canStack && existingItem.CurrentCount < existingItem.Data.maxStackAmount)
            {
                existingItem.CurrentCount += item.CurrentCount;
            }
            else
            {
                Inventory.Add(item);
            }
        }
        else
        {
            Inventory.Add(item);

        }
        UIManager.Instance.UIInventory.GetComponent<UIInventory>().InitInventoryUI(this);
    }
    public void EquipItem(Item item)
    {
        if(item!=null&&item.Data != null && item.Data.type == ItemType.Equipable&&!item.IsEquipped)
        {
            item.IsEquipped = true;
            foreach(var equip in item.Data.equipables)
            {
                switch (equip.type)
                {
                    case EquipableType.Attack:
                        _attack += (int)equip.value;
                        break;
                    case EquipableType.Defense:
                        _defense += (int)equip.value;
                        break;
                }
            }
        }
        UIManager.Instance.UIInventory.GetComponent<UIInventory>().InitInventoryUI(this);
    }
    public void UnEquipItem(Item item)
    {
        if (item.IsEquipped)
        {
            item.IsEquipped = false;
            foreach(var equip in item.Data.equipables)
            {
                switch (equip.type)
                {
                    case EquipableType.Attack:
                        _attack -= (int)equip.value;
                        break;
                    case EquipableType.Defense:
                        _defense -= (int)equip.value;
                        break;
                }
            }
        }
        UIManager.Instance.UIInventory.GetComponent<UIInventory>().InitInventoryUI(this);
    }
    public void EatItem(Item item)
    {
        if(item != null && item.Data !=null&& item.Data.type == ItemType.Consumable&&item.CurrentCount>0)
        {
            foreach (var _item in item.Data.consumables)
            {
                switch (_item.type)
                {
                    case ConsumableType.Health:
                        _health += (int)_item.value;
                        break;
                    case ConsumableType.Level:
                        _level += (int)_item.value;
                        break;
                }
            }
            item.CurrentCount--;
            if(item.Data.count <= 0)
            {
                Inventory.Remove(item);
            }
        }
        UIManager.Instance.UIInventory.GetComponent<UIInventory>().InitInventoryUI(this);
    }
}
