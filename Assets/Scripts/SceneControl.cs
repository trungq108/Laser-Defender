using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControl : MonoBehaviour
{
    [SerializeField] float delay = 1.0f;
    
    public void LoadMenuScene()
    {
        SceneManager.LoadScene("MenuScene");
    }

    public void LoadMainGameScene()
    {
        SceneManager.LoadScene("MainGame");
        FindAnyObjectByType<ScoreKeeper>().ResetScore();
    }

    public void LoadGameOverScene()
    {
        StartCoroutine(PlayerDeath("GameOver", delay));
    }

    public void ExitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }

    IEnumerator PlayerDeath(string sceneName, float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
    }
}
