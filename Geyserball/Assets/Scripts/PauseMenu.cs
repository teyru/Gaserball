using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private float _persentShowAds;

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
        float tempPersent = Random.Range(0f, 1f);
        if (tempPersent < _persentShowAds)
        {
            AdsCore.ShowAdsVideo("Interstitial_Android");
            PauseGameMenu.SetActive(false);
        }
        else
        {
            PauseGame = false;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 0, LoadSceneMode.Single);
            Time.timeScale = 1f;
            PauseGameMenu.SetActive(false);
        }
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
