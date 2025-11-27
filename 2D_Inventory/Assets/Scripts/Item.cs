using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public ItemData Data { get; private set; }
    public bool IsEquipped { get; set; }
    public int CurrentCount {  get; set; }
    
    public Item(ItemData data)
    {
        Data = data;
        IsEquipped = false;
        CurrentCount = data.count;
    }
    
    public string Name => Data._name;
    public Sprite Icon => Data.icon;
    public int InitialCount => Data.count;
}
