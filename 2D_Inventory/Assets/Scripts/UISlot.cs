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

    public ItemData currentItem;
    public void SetItem(ItemData item)
    {
        currentItem = item;
        RefreshUI();
    }
    public void RefreshUI()
    {
        if (currentItem != null)
        {
            iconImg.sprite = currentItem.icon;
            iconImg.enabled = true;
            itemCountTXT.text = currentItem.count > 1 ? currentItem.count.ToString() : "";
        }
        else
        {
            iconImg.enabled = false;
            itemCountTXT.text = "";
        }
    }
}
