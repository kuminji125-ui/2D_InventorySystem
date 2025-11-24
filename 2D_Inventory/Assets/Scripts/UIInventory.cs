using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIInventory : MonoBehaviour
{
    [SerializeField] private Button openButton;
    [SerializeField] private Button closeButton;
    void Awake()
    {
        openButton.onClick.AddListener(OpenClicked);
        closeButton.onClick.AddListener(CloseClicked);
    }

    private void OpenClicked()
    {
        UIManager.Instance.OpenInventory();
    }
    private void CloseClicked()
    {
        UIManager.Instance.CloseInventory();
    }
}
