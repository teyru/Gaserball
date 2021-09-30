using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioControle : MonoBehaviour
{
    private int volume;
    private bool firsttap = true;

    private void Start()
    {
        volume = PlayerPrefs.GetInt("Volume");

        if (volume == 1)
        {
            GetComponent<Image>().color = new Color(255, 0, 0, 255);
        }
        else
        {
            firsttap = true;
            GetComponent<Image>().color = new Color(255, 255, 255, 255);
        }
    }

    public void volumeBtn()
    {
        if (firsttap)
        {
            firsttap = false;
            if (volume == 1)
            {
                Camera.main.GetComponent<AudioListener>().enabled = false;
                PlayerPrefs.SetInt("Volume", 1);
                volume = 0;
                GetComponent<Image>().color = new Color(255, 0, 0, 255);
            }
            else
            {
                Camera.main.GetComponent<AudioListener>().enabled = true;
                PlayerPrefs.SetInt("Volume", 0);
                volume = 1;
                GetComponent<Image>().color = new Color(255, 255, 255, 255);
            }
        }


        if (volume == 1)
        {
            PlayerPrefs.SetInt("Volume", 1);
            Camera.main.GetComponent<AudioListener>().enabled = false;
            volume = 0;
            GetComponent<Image>().color = new Color(255, 0, 0, 255);
        }
        else
        {
            Camera.main.GetComponent<AudioListener>().enabled = true;
            PlayerPrefs.SetInt("Volume", 0);
            volume = 1;
            GetComponent<Image>().color = new Color(255, 255, 255, 255);
        }
    }
}
