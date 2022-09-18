using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snowboard : MonoBehaviour
{
    [SerializeField] float torqueAmount;
    [SerializeField] float boostspeed;
    [SerializeField] float basespeed;
    bool move = true;

    Rigidbody2D rb2d;
    SurfaceEffector2D surfaceEffector2D;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>();
    }

    void Update()
    {
        if (move)
        {
            rotate();
            boost();
        }
    }

    public void DisableControls()
    {
        move = false;
        surfaceEffector2D.enabled = false;
    }

    void boost()
    {
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            surfaceEffector2D.speed = boostspeed;
        }
        else
        {
            surfaceEffector2D.speed = basespeed;
        }
    }

    private void rotate()
    {
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            rb2d.AddTorque(torqueAmount);
        }

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            rb2d.AddTorque(-torqueAmount);
        }
    }

}
