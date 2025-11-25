using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Equipable,
    Consumable
}
public enum ConsumableType
{
    Health,
    Level
}
public enum EquipableType
{
    Attack,
    Defense
}
[Serializable]
public class ItemDataConsumable
{
    public ConsumableType type;
    public float value;
}
[Serializable]
public class ItemDataEquipableType
{
    public EquipableType type;
    public float value;
}
[CreateAssetMenu(fileName ="NewItem",menuName ="Item")]
public class ItemData : ScriptableObject
{
    public string _name;
    public Sprite icon;
    public int count;

    public bool canStack;
    public int maxStackAmount;

    public ItemType type;
    public ItemDataConsumable[] consumables;
    public ItemDataEquipableType[] equipables;
}
