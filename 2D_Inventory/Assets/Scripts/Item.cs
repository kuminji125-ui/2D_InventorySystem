using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
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
    
    public string Name => Data.name;
    public Sprite Icon => Data.icon;
    public int InitialCount => Data.count;
}
