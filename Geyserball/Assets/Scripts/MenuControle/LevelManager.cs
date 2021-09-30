using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public Button[] LevelButton;
    public static int LevelComplete;
    void Start()
    {
        LevelComplete = PlayerPrefs.GetInt("LevelComplete");
        for (int i = 1; i < LevelButton.Length; i++)
        {
            LevelButton[i].interactable = false;
        }

        for (int i = 1; i < LevelComplete; i++)
        {
            LevelButton[i].interactable = true;
        }
    }
    

    public void LoadLvl(int level)
    {
        SceneManager.LoadScene(level);
    }

    public void Reset()
    {
        for (int i = 1; i < LevelButton.Length; i++)
        {
            LevelButton[i].interactable = false;
        }
        PlayerPrefs.DeleteAll();
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }
}
