using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrajectoryRenderer : MonoBehaviour
{
    private LineRenderer lineRendererComponent;

    public void hideLine()
    {
        lineRendererComponent.enabled = false;
    }

    public void showLine()
    {
        lineRendererComponent.enabled = true;
    }

    void Start()
    {
        lineRendererComponent = GetComponent<LineRenderer>();
    }
    
    public void ShowTrajectory(Vector3 origin, Vector3 speed)
    {
        Vector3[] points = new Vector3[12];
        lineRendererComponent.positionCount = points.Length;
        for (int i = 0; i < points.Length; i++ )
        {
            float time = i * 0.1f;

            points[i] = origin + speed * time + Physics.gravity * time * time / 2;

        }

        lineRendererComponent.SetPositions(points);
    }
}
