using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMainMenu : MonoBehaviour
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
        Debug.Log("¿€µø");
        UIManager.Instance.OpenMainMenu();
    }
    private void CloseClicked()
    {
        UIManager.Instance.CloseMainMenu();
    }
}
