using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jointMove : MonoBehaviour
{
    [SerializeField] PlatformMovement platform;
    public float posX;
    public float posY;
    private Vector2 btnToPlfrmVector;

    private void Start()
    {
        transform.position = new Vector2(platform.transform.position.x + posX, platform.transform.position.y + posY);
        btnToPlfrmVector = transform.position - platform.transform.position;
    }

    private void Update()
    {
        Vector2 platformPos = new Vector2(platform.transform.position.x, platform.transform.position.y);
        transform.position = platformPos + btnToPlfrmVector;
    }
}
