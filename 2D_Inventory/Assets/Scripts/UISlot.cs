using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;
public class UISlot : MonoBehaviour
{
    [SerializeField] private Image iconImg;
    [SerializeField] private TextMeshProUGUI itemCountTXT;

    [SerializeField] private Button openButton;
 
    public Item currentItem;

    void Awake()
    {
        openButton.onClick.AddListener(() =>UIManager.Instance.OpenInventoryDetail(currentItem));    
    }

    public void SetItem(Item item)
    {
        if(item == null)
        {
            currentItem = null;
            RefreshUI();
            return;
        }
        currentItem = item;
        RefreshUI();
    }
    public void RefreshUI()
    {
        if(iconImg == null|| itemCountTXT == null)
        {
            Debug.LogError("UISlot UI references are missing!");
            return;
        }
        if (currentItem != null)
        {
            iconImg.sprite = currentItem.Icon;
            iconImg.enabled = true;
            itemCountTXT.text = currentItem.CurrentCount > 1 ? currentItem.CurrentCount.ToString() : "";
            if (currentItem.Data.type == ItemType.Equipable && currentItem.IsEquipped)
            {
                itemCountTXT.text = "E";
            }
        }
        else
        {
            iconImg.enabled = false;
            itemCountTXT.text = "";
        }
    }
}
