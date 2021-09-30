using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public static LevelController instance = null;
    private int sceneIndex;
    private int levelComlete;

    void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        levelComlete = PlayerPrefs.GetInt("LevelComlete");
    }
    
    public void IsEndGame()
    {
            if(levelComlete < sceneIndex)
            {
                PlayerPrefs.SetInt("LevelComplete", sceneIndex);
            }
    }
}
