using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class UIStatus : MonoBehaviour
{
    [SerializeField] private Button openButton;
    [SerializeField] private Button closeButton;

    public TextMeshProUGUI attackTXT;
    public TextMeshProUGUI defenseTXT;
    public TextMeshProUGUI healthTXT;
    public TextMeshProUGUI criticalTXT;
    void Awake()
    {
        openButton.onClick.AddListener(OpenClicked);
        closeButton.onClick.AddListener(CloseClicked);
    }
    public void SetCharacterStat()
    {
        attackTXT.text = GameManager.Instance.player.Attack.ToString();
        defenseTXT.text = GameManager.Instance.player.Defense.ToString();
        healthTXT.text = GameManager.Instance.player.Health.ToString();
        criticalTXT.text = GameManager.Instance.player.Critical.ToString();
    }
    private void OpenClicked()
    {
        UIManager.Instance.OpenStatus();
        SetCharacterStat();
    }
    private void CloseClicked()
    {
        UIManager.Instance.CloseStatus();
    }
}
