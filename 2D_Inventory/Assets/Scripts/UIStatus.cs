using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIStatus : MonoBehaviour
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
        UIManager.Instance.OpenStatus();
    }
    private void CloseClicked()
    {
        UIManager.Instance.CloseStatus();
    }
}
