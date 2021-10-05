using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;

public class AdsCore : MonoBehaviour
{
    [SerializeField] private bool _testMode = false;
    private string _gameId = "4391207";
    public static bool videoactivated;
    private string _video = "Interstitial_Android";



    void Start()
    {
        Advertisement.Initialize(_gameId, _testMode);
        videoactivated = false;
    }

    private void Update()
    {
        if(!Advertisement.isShowing && videoactivated)
        {
            videoactivated = false;
            PauseMenu.PauseGame = false;
            Time.timeScale = 1f;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 0, LoadSceneMode.Single);
        }
    }

    public static void ShowAdsVideo(string placementId)
    {
        if (Advertisement.IsReady())
        {
            Advertisement.Show(placementId);
            Time.timeScale = 0f;
            PauseMenu.PauseGame = true;
            videoactivated = true;
        }
        else
        {
            Debug.Log("Not Ready");
        }
    }
}
