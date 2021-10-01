using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Ball : MonoBehaviour
{
    public GameObject bulletPrefab;
    private Joystick joystic;
    TrajectoryRenderer Trajectory;    
    [SerializeField] Rigidbody2D shootRigidbody;
    [SerializeField] float maxDistance = 4f;

    private Vector2 speed;


    void Start()
    {
        Trajectory = GameObject.FindGameObjectWithTag("Traject").GetComponent<TrajectoryRenderer>();
        joystic = GameObject.FindGameObjectWithTag("Joystick").GetComponent<Joystick>();
    }

    void Update()
    {

        if (Input.GetMouseButtonUp(0) && !PauseMenu.PauseGame)
        {
            Rigidbody2D bullet = Instantiate(bulletPrefab, transform.position, Quaternion.Euler(0, 0, 180)).GetComponent<Rigidbody2D>();
            bullet.AddForce(speed * 130, ForceMode2D.Impulse);
            Destroy(GetComponent<Ball>());
            GameObject.FindGameObjectWithTag("Gaiser").GetComponent<Gaiser>().enabled = true;
        }


        Vector2 direction = new Vector2(joystic.Horizontal, joystic.Vertical);
        speed = direction;
        if (joystic.Horizontal > .71f && joystic.Vertical > .71f)
        {
            speed = direction * maxDistance;
        }


        if (joystic.Horizontal >= .68f && joystic.Vertical >= .68f && joystic.Horizontal <= .71f && joystic.Vertical <= .71f)
        {
            Trajectory.ShowTrajectory(transform.position, speed * 13);
            speed = direction;
        }
        else
        {
            Trajectory.ShowTrajectory(transform.position, speed * 13);
        }
        Trajectory.showLine();

        if (joystic.Horizontal >= -1 || joystic.Vertical >= -1)
        {
            if (joystic.Horizontal != 0 || joystic.Vertical != 0)
                transform.up = direction;
        }

        if (joystic.Horizontal == 0 && joystic.Vertical == 0)
        {
            Trajectory.hideLine();
        }

    }


}