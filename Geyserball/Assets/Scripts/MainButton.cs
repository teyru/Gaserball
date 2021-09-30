using UnityEngine;

public class MainButton : MonoBehaviour
{
    [SerializeField] AudioClip tapSound;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        AudioSource.PlayClipAtPoint(tapSound, Camera.main.transform.position);
        Destroy(gameObject);
    }
}
