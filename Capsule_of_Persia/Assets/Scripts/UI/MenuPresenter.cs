using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DefaultNamespace
{
    public class MenuPresenter : MonoBehaviour
    {
        [SerializeField] private MenuView view;

        private void Start()
        {
            view.OnMenuOpen += OpenOrCloseMenuWindow;
            view.OnRestartClick += RestartGame;
        }

        private void OpenOrCloseMenuWindow(bool isOpen)
        {
            view.SetButtonActive(!isOpen);
            view.SetMenuWindowActive(isOpen);
            view.DeactivateScripts(!isOpen);
            Time.timeScale = isOpen ? 0.0001f : 1f;
        }

        private void RestartGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}