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
        }
        else
        {
            AudioListener.pause = false;
        }
    }
}
