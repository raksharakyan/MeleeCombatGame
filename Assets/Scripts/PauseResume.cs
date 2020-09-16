using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseResume : MonoBehaviour
{
    public GameObject pausePanel;
    public GameObject keyMap;
    public void OnClickPause()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void OnClickResume()
    {
        pausePanel.SetActive(false);
        keyMap.SetActive(false);
        Time.timeScale = 1f;
    }

    public void OnClickKeyMap()
    {
        pausePanel.SetActive(false);
        keyMap.SetActive(true);
        Time.timeScale = 0f;

    }
}
