using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject mainMenuPanel;
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject settingsPanel;

    private void Awake()
    {
        DisablePausePanel();
        settingsPanel.SetActive(false);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1f;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        EnablePausePanel();
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        DisablePausePanel();
    }

    public void OpenSettings()
    {
        DisablePausePanel();
        DisableMainMenuPanel();
        settingsPanel.SetActive(true);
    }

    public void CloseSettings()
    {
        settingsPanel.SetActive(false);
        EnablePausePanel();
        EnableMainPanel();
    }

    public void ExitGame()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }

    void EnableMainPanel()
    {
        if (mainMenuPanel != null)
        {
            mainMenuPanel.SetActive(true);
        }
        else
        {
            return;
        }
    }

    void DisableMainMenuPanel()
    {
        if (mainMenuPanel != null)
        {
            mainMenuPanel.SetActive(false);
        }
        else
        {
            return;
        }
    }

    void EnablePausePanel()
    {
        if (pausePanel != null)
        {
            pausePanel.SetActive(true);
        }
        else
        {
            return;
        }
    }

    void DisablePausePanel()
    {
        if (pausePanel != null)
        {
            pausePanel.SetActive(false);
        }
        else
        {
            return;
        }
    }
}
