using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIMainMenu : MonoBehaviour
{
    [SerializeField] private Button openButton;
    [SerializeField] private Button closeButton;

    public TextMeshProUGUI jobTXT;
    public TextMeshProUGUI nameTXT;
    public TextMeshProUGUI levelTXT;
    public TextMeshProUGUI descriptionTXT;
    public TextMeshProUGUI goldTXT;
    void Awake()
    {
        openButton.onClick.AddListener(OpenClicked);
        closeButton.onClick.AddListener(CloseClicked);
    }
    public void SetCharacterInfo()
    {
        jobTXT.text = GameManager.Instance.player.Job;
        nameTXT.text = GameManager.Instance.player.Name;
        levelTXT.text = $"Lv. {GameManager.Instance.player.Level.ToString()}";
        descriptionTXT.text = GameManager.Instance.player.Description;
        goldTXT.text = $"{GameManager.Instance.player.Gold.ToString()} G";
    }
    private void OpenClicked()
    {
        Debug.Log("¿€µø");
        UIManager.Instance.OpenMainMenu();
        SetCharacterInfo();
    }
    private void CloseClicked()
    {
        UIManager.Instance.CloseMainMenu();
    }
    public void UpdateLevel()
    {
        levelTXT.text = $"Lv. {GameManager.Instance.player.Level.ToString()}";
    }
    public void UpdateGold()
    {
        goldTXT.text = $"{GameManager.Instance.player.Gold.ToString()} G";
    }

}
