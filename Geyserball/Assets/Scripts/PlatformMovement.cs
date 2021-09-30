using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    public float speed;
    private float waitTime;
    public float startWaitTime;
    public Transform[] moveSpots;
    private int spotCount;



    void Start()
    {
        spotCount = 0;
        waitTime = startWaitTime;
        transform.position = moveSpots[0].position;
    }   

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, moveSpots[spotCount].position, speed * Time.deltaTime);

        if(Vector2.Distance(transform.position, moveSpots[spotCount].position)<.2f)
        {
            if (waitTime <= 0)
            {
                if (spotCount == moveSpots.Length-1)
                {
                    spotCount = 0;
                }
                else
                {
                    spotCount++;
                }
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }

        }

    }
}
