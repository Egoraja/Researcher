using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    [SerializeField] GameObject youWonPanel;

    private void Start()
    {
        youWonPanel.SetActive(false);
    }

    public void GameOver()
    {
        StartCoroutine(GameOverProcess());
    }
    private IEnumerator GameOverProcess()
    {
        yield return new WaitForSeconds(1f);
        Time.timeScale = 0;
        youWonPanel.SetActive(true);
    }

    public void MainMenuButtonPressed()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

    public void PauseButtonPressed()
    {

        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }
}
