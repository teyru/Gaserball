using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool PauseGame = false;
    public GameObject PauseGameMenu;
    private GameObject EnabledElement;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (PauseGame)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    public void Resume()
    {
        PauseGameMenu.SetActive(false);
        Time.timeScale = 1f;
        StartCoroutine(ResumeBg());
    }

    public void Pause()
    {
        PauseGameMenu.SetActive(true);
        Time.timeScale = 0f;
        PauseGame = true;
    }

    public void Restart()
    {
        PauseGameMenu.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 0, LoadSceneMode.Single);
        PauseGame = false;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        PauseGame = false;
        SceneManager.LoadScene("MainMenu");
    }

    IEnumerator ResumeBg()
    {
        yield return new WaitForSeconds(0.1f);
        PauseGame = false;
    }
}
