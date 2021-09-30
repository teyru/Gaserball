using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class АnchorRope : MonoBehaviour
{
    bool x = false;

    private void Update()
    {
        if (!x)
        {
            transform.rotation *= Quaternion.AngleAxis(3, Vector3.back);
        }

    }


      void OnCollisionEnter2D(Collision2D collision)
      {
        x = true;
      }




}
