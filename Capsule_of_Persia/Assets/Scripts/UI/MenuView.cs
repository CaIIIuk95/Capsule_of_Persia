using System;
using UnityEngine;
using UnityEngine.UI;

public class MenuView : MonoBehaviour
{
    [SerializeField] private Button menuButton;
    [SerializeField] private Button continueButton;
    [SerializeField] private Button restartButton;
    [SerializeField] private GameObject menuWindow;
    [SerializeField] private MonoBehaviour[] scriptsToDeactivate;

    public event Action<bool> OnMenuOpen;
    public event Action OnRestartClick;

    public void Start()
    {
        menuButton.onClick.AddListener(() => OnMenuOpen?.Invoke(true));
        continueButton.onClick.AddListener(() => OnMenuOpen?.Invoke(false));
        restartButton.onClick.AddListener(() => OnRestartClick?.Invoke());
    }

    public void SetButtonActive(bool isActive)
    {
        menuButton.gameObject.SetActive(isActive);
    }

    public void SetMenuWindowActive(bool isActive)
    {
        menuWindow.SetActive(isActive);
    }

    public void DeactivateScripts(bool isActive)
    {
        foreach (var script in scriptsToDeactivate)
        {
            script.enabled = isActive;
        }
    }
}