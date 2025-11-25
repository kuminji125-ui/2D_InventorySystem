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

    public Item currentItem;
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
        }
        else
        {
            iconImg.enabled = false;
            itemCountTXT.text = "";
        }
    }
}
