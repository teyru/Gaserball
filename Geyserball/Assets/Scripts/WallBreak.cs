using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallBreak : MonoBehaviour
{
    public GameObject part1;
    public GameObject part2;

    [SerializeField] AudioClip tapSound;
        
    private void OnTriggerEnter2D(Collider2D collision)
    {
        part1.GetComponent<Rigidbody2D>().simulated = true;
        part2.GetComponent<Rigidbody2D>().simulated = true;
        AudioSource.PlayClipAtPoint(tapSound, Camera.main.transform.position);
        Destroy(gameObject);
    }
}
