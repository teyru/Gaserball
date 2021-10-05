using UnityEngine;

public class GlobalSound : MonoBehaviour
{
    private int volume;

    void Start()
    {
        volume = PlayerPrefs.GetInt("Volume");
        if (volume == 1)
        {
            AudioListener.pause = true;
            PlayerPrefs.SetInt("Volume", 1);
        }
        else
        {
            AudioListener.pause = false;
            PlayerPrefs.SetInt("Volume", 0);
        }
    }
}
