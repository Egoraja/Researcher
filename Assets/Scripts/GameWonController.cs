using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameWonController : MonoBehaviour
{
    [SerializeField] GameObject youWonPanel;    

    private void Start()
    {
        youWonPanel.SetActive(false);
    }
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Finish"))
        {
            StartCoroutine(GameOverProcess());
        }
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
}
