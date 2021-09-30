using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinButtonEvent : MonoBehaviour
{
    void Update()
    {
        if(GameObject.FindGameObjectWithTag("WinButton") == null)
        {
            WinPanel.WinGame = true;
        }
    }
}
