using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject uiMainMenu;
    [SerializeField] private GameObject uiStatus;
    [SerializeField] private GameObject uiInventory;

    public GameObject UIMainMenu => uiMainMenu;
    public GameObject UIStatus => uiStatus;
    public GameObject UIInventory => uiInventory;
    public static UIManager Instance;

    [Header("ItemDetail")]
    [SerializeField] private Button closeButton;
    [SerializeField] private Button useButton;
    [SerializeField] private Button equipButton;
    [SerializeField] private Button unEquipButton;
    [SerializeField] private Button deleteButton;
    [SerializeField] private GameObject _panel;
    [SerializeField] private Image _icon;
    [SerializeField] private TextMeshProUGUI _count;
    [SerializeField] private TextMeshProUGUI _name;
    [SerializeField] private TextMeshProUGUI _description;


    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        closeButton.onClick.AddListener(CloseInventoryDetail);
    }
    void Start()
    {
        uiMainMenu.SetActive(false);
        uiStatus.SetActive(false);
        uiInventory.SetActive(false);
        _panel.SetActive(false);
    }
    public void OpenMainMenu()
    {
        uiMainMenu.SetActive(true);
        uiStatus.SetActive(false);
        uiInventory.SetActive(false);
    }
    public void CloseMainMenu()
    {
        uiMainMenu.SetActive(false);
        uiStatus.SetActive(false);
        uiInventory.SetActive(false);
        _panel.SetActive(false);
    }
    public void OpenStatus()
    {
        uiStatus.SetActive(true);
        uiInventory.SetActive(false);
    }
    public void CloseStatus()
    {
        uiStatus.SetActive(false);
    }
    public void OpenInventory()
    {
        uiInventory.SetActive(true);
        uiStatus.SetActive(false);
    }
   public void CloseInventory()
    {
        uiInventory.SetActive(false);
    }
    public void OpenInventoryDetail(Item item)
    {
        _panel.SetActive(true);
        RefreshUIInventoryDetail(item);
        
        if(item != null)
        {
            _icon.sprite = item.Icon;
            _count.text = item.CurrentCount.ToString();
            _name.text = item.Name;
            _description.text = item.Data.description;

            useButton.onClick.RemoveAllListeners();
            equipButton.onClick.RemoveAllListeners();
            unEquipButton.onClick.RemoveAllListeners();
            deleteButton.onClick.RemoveAllListeners();

            useButton.onClick.AddListener(() => { GameManager.Instance.player.EatItem(item);
                RefreshUIInventoryDetail(item);});
            equipButton.onClick.AddListener(() =>
            {
                GameManager.Instance.player.EquipItem(item);
                equipButton.gameObject.SetActive(false);
                unEquipButton.gameObject.SetActive(true);
                RefreshUIInventoryDetail(item);});
            unEquipButton.onClick.AddListener(() => {GameManager.Instance.player.UnEquipItem(item);
                equipButton.gameObject.SetActive(true);
                unEquipButton.gameObject.SetActive(false);
                RefreshUIInventoryDetail(item);});
            deleteButton.onClick.AddListener(() => {
                DeleteItem(item);
                CloseInventoryDetail();
            });

        if (item.Data.type == ItemType.Equipable)
            {
                useButton.gameObject.SetActive(false);
                if (item.IsEquipped)
                {
                    equipButton.gameObject.SetActive(false);
                    unEquipButton.gameObject.SetActive(true);
                }
                else
                {
                    equipButton.gameObject.SetActive(true);
                    unEquipButton.gameObject.SetActive(false);
                }
            }
            else
            {
                useButton.gameObject.SetActive(true);
                equipButton.gameObject.SetActive(false);
                unEquipButton.gameObject.SetActive(false);
            }
        }
    }
    public void DeleteItem(Item item)
    {
        if (item.IsEquipped)
        {
            GameManager.Instance.player.UnEquipItem(item);
        }
        GameManager.Instance.player.Inventory.Remove(item);  
    }
    public void RefreshUIInventoryDetail(Item item)
    {
        _icon.sprite = item.Icon;
        _count.text = item.CurrentCount.ToString();
        _name.text = item.Name;
        _description.text = item.Data.description;
    }
    public void CloseInventoryDetail()
    {
        _panel.SetActive(false);
        uiInventory.GetComponent<UIInventory>().InitInventoryUI(GameManager.Instance.player);
    }
}
