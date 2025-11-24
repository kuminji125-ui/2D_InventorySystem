using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject uiMainMenu;
    [SerializeField] private GameObject uiStatus;
    [SerializeField] private GameObject uiInventory;

    public GameObject UIMainMenu => uiMainMenu;
    public GameObject UIStatus => uiStatus;
    public GameObject UIInventory => uiInventory;
    public static UIManager Instance;

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
    }
    void Start()
    {
        uiMainMenu.SetActive(false);
        uiStatus.SetActive(false);
        uiInventory.SetActive(false);
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
}
