using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinPanel : MonoBehaviour
{
    public static bool WinGame;
    private int sceneIndex;
    private int levelComplete;
    public GameObject WinGameMenu;

    private void Start()
    {
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        levelComplete = PlayerPrefs.GetInt("LevelComplete");
        WinGame = false;
        WinGameMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    private void Update()
    {
        
        if (WinGame)
        {
            StartCoroutine(winGame());
            if (levelComplete < sceneIndex)
            {
                PlayerPrefs.SetInt("LevelComplete", sceneIndex);
            }
            GameObject.FindGameObjectWithTag("Gaiser").GetComponent<Gaiser>().enabled = false;
        }
    }

    public void NextLevel()
    { if(sceneIndex == 20)
        {
            SceneManager.LoadScene("MainMenu");
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1, LoadSceneMode.Single);
        }
    }


    public void Restart()
    {
        WinGameMenu.SetActive(false);
        WinGame = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 0, LoadSceneMode.Single);
        Time.timeScale = 1f;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    IEnumerator winGame()
    {
        yield return new WaitForSeconds(1f);
        Time.timeScale = 0f;
        WinGameMenu.SetActive(true);
    }
}