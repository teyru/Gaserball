using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomScript : MonoBehaviour
{
    bool firstShoot = true;
    void Start()
    {
       gameObject.GetComponent<SpriteRenderer>().enabled = false;
    }

    void Update()
    {
        if (Input.GetMouseButtonUp(0) && GameObject.FindGameObjectWithTag("Gaiser").GetComponent<Gaiser>().enabled || Input.GetMouseButtonUp(0) && firstShoot && !PauseMenu.PauseGame)
        {
            if (!PauseMenu.PauseGame)
            {
                firstShoot = false;
                GetComponent<AudioSource>().Play();
                StartCoroutine(boomDisappear());
            }
        }



        IEnumerator boomDisappear()
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
            transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            for (float q = 0.4f; q < 1f; q += 0.03f)
            {
            transform.localScale = new Vector3(q, q, q);
            yield return new WaitForSeconds(0.01f);
            }
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            
        }
    }
}