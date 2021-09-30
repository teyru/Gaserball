using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour
{
    private AudioSource clip;
    private Animator anim;
    bool x = false;
    void Start()
    {
        clip = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
        anim.SetBool("collisionAnimation", false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        x = true;
        clip.Play();
        StartCoroutine(colHappens());
    }

    private void Update()
    {
        if (!x)
        {
            anim.SetBool("collisionAnimation", false);
        }
    }

    IEnumerator colHappens()
    {
        anim.SetBool("collisionAnimation", true);
        yield return new WaitForSeconds(0.44f);
        x = false;
    }
}
