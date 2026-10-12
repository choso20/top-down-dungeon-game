using System;
using UnityEngine;

public class player : Mover
{
    public Animator animator;

    float xa;
    float ya;

    private void OnEnable()
    {
        MobileJoystick.OnnMove += InbetweenJump;
    }

    private void OnDisable()
    {
        MobileJoystick.OnnMove -= InbetweenJump;
    }

    protected override void Start()
    {
        base.Start();
        DontDestroyOnLoad(gameObject);
    }

    private void InbetweenJump(Vector2 vector2)
    {
        xa = vector2.x;
        ya = vector2.y;
    }


    private void FixedUpdate()
    {
        float x = xa;
        float y = ya;

        // animator parameters
        animator.SetBool("Run", x != 0 || y != 0);


        UpdateMotor(new Vector3(x, y, 0));
    }
}