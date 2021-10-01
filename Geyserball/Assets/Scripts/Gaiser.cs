using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gaiser : MonoBehaviour
{
    private Joystick joystic;
    public GameObject bulletPrefab;
    TrajectoryRenderer Trajectory;
    [SerializeField] Rigidbody2D shootRigidbody;
    [SerializeField] float maxDistance = 6f;
    Vector2 speed;

    public float power = 100;
    void Start()
    {
        Trajectory = GameObject.FindGameObjectWithTag("Traject").GetComponent<TrajectoryRenderer>();
        joystic = GameObject.FindGameObjectWithTag("Joystick").GetComponent<Joystick>();
        this.enabled = true;
    }


    void Update()
    {
        if (Input.GetMouseButtonUp(0) && !PauseMenu.PauseGame)
        {
            Rigidbody2D bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity).GetComponent<Rigidbody2D>();
            bullet.AddForce(speed * 100, ForceMode2D.Impulse);
            this.enabled = false;
        }

        Vector2 direction = new Vector2(joystic.Horizontal, joystic.Vertical);
        speed = direction;
        if (joystic.Horizontal > .71f && joystic.Vertical > .71f)
            speed = direction * maxDistance;

        if (joystic.Horizontal >= .68f && joystic.Vertical >= .68f && joystic.Horizontal <= .71f && joystic.Vertical <= .71f)
        {
            Trajectory.ShowTrajectory(transform.position, speed * 10);
            speed = direction;
        }
        else
        {
            Trajectory.ShowTrajectory(transform.position, speed * 10);
        }
        Trajectory.showLine();



        if (joystic.Horizontal >= -1 || joystic.Vertical >= -1)
        {
            if(joystic.Horizontal != 0 || joystic.Vertical != 0)
            transform.up = direction;
        }

        if (joystic.Horizontal == 0 && joystic.Vertical == 0)
        {
            Trajectory.hideLine();
        }
    }
}