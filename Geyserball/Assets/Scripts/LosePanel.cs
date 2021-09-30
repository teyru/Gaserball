using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LosePanel : MonoBehaviour
{
    public static bool LoseGame;
    public GameObject LoseGameMenu;

    private void Start()
    {
        LoseGame = false;
        LoseGameMenu.SetActive(false);
    }

    private void Update()
    {
        if (ShootsAvailable.nullShoots && GameObject.FindGameObjectsWithTag("Anchor").Count() == ShootsAvailable.countOfShoots)
        {
           StartCoroutine(LostGame());
        }
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }


    public void Restart()
    {
        LoseGameMenu.SetActive(false);
        Time.timeScale = 1f;
        LoseGame = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 0, LoadSceneMode.Single);
    }


    IEnumerator LostGame()
    {
        yield return new WaitForSeconds(6f);
        Time.timeScale = 0f;
        LoseGameMenu.SetActive(true);
    }
}
