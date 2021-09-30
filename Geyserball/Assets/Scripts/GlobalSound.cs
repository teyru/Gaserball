using UnityEngine;

public class GlobalSound : MonoBehaviour
{
    private int volume;
    void Start()
    {
        volume = PlayerPrefs.GetInt("Volume");
        if (volume == 1)
        {
            GetComponent<AudioListener>().enabled = false;
        }
        else
        {
            GetComponent<AudioListener>().enabled = true;
        }
    }
}
