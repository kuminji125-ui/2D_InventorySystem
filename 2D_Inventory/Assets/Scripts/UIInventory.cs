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
    void Awake()
    {
        openButton.onClick.AddListener(OpenClicked);
        closeButton.onClick.AddListener(CloseClicked);
    }
    void Start()
    {
        InitInventoryUI(GameManager.Instance.player);    
    }
    private void OpenClicked()
    {
        UIManager.Instance.OpenInventory();
        InitInventoryUI(GameManager.Instance.player);
    }
    private void CloseClicked()
    {
        UIManager.Instance.CloseInventory();
        ResetScrollRect();
    }
    public void InitInventoryUI(Character character)
    {
        foreach(var slot in slots)
        {
            Destroy(slot.gameObject);
        }
        slots.Clear();
        foreach(var item in character.Inventory)
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
