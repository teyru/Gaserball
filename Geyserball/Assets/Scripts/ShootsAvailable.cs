using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShootsAvailable : MonoBehaviour
{
    public int shootCount;
    public static bool nullShoots;
    public static int countOfShoots;
    [SerializeField] Text textinp;
    private bool firstShoot = true;


    private void Start()
    {
        textinp.text = shootCount.ToString();
        nullShoots = false;
        countOfShoots = shootCount;
    }


    void Update()
    {
        if (shootCount == 0)
        {
            nullShoots = true;
            GameObject.FindGameObjectWithTag("Gaiser").GetComponent<Gaiser>().enabled = false;
        }
        else
        if (Input.GetMouseButtonUp(0) && GameObject.FindGameObjectWithTag("Gaiser").GetComponent<Gaiser>().enabled || firstShoot  && Input.GetMouseButtonUp(0))
        {
            if (!PauseMenu.PauseGame)
            {
                firstShoot = false;
                shootCount--;
                textinp.text = shootCount.ToString();
            }
        }
    }
}
