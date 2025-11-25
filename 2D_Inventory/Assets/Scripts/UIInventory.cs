using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIInventory : MonoBehaviour
{
    [SerializeField] private Button openButton;
    [SerializeField] private Button closeButton;
    [SerializeField] private Transform slotParent;
    [SerializeField] private UISlot slotPrefab;
    [SerializeField] private ScrollRect scrollRect;

    private List<UISlot> slots = new List<UISlot>();
    [SerializeField] private List<ItemData> items;
    void Awake()
    {
        openButton.onClick.AddListener(OpenClicked);
        closeButton.onClick.AddListener(CloseClicked);
    }
    void Start()
    {
        InitInventoryUI();    
    }
    private void OpenClicked()
    {
        UIManager.Instance.OpenInventory();
    }
    private void CloseClicked()
    {
        UIManager.Instance.CloseInventory();
        ResetScrollRect();
    }
    private void InitInventoryUI()
    {
        foreach(var slot in slots)
        {
            Destroy(slot.gameObject);
        }
        foreach(var item in items)
        {
            UISlot newSlot = Instantiate(slotPrefab, slotParent);
            newSlot.SetItem(item);
            slots.Add(newSlot);
        }
    }
    public void ResetScrollRect()
    {
        scrollRect.normalizedPosition = new Vector2(0,1);
    }
}
