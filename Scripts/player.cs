using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public Animator anim;
    public float speed = 5f;
    public Rigidbody2D rb;
    Vector2 move;
    public AudioSource audioSource;

    enum States
    {
        IdleF, RunF, IdleB, RunB, IdleL, RunL, IdleR, RunR
    }
    States MV = 0;
    // Update is called once per frame
    void FixedUpdate()
    {
        move.x = Input.GetAxisRaw("Horizontal");
        move.y = Input.GetAxisRaw("Vertical");
        if (move.x == move.y) 
        {
            move.x = move.x / 1.41f;
            move.y = move.y / 1.41f;
        }
        rb.MovePosition(rb.position + move * speed * Time.fixedDeltaTime);
        if ( move.y < -0.01f || move.y > 0.01f)
        {
            switch (move.y)
            {
                case > 0:
                    MV = States.RunF;
                    break;
                case < 0:
                    MV = States.RunB;
                    break;
            }
        }
        else if(move.x < -0.01f || move.x > 0.01f)
        {
            switch (move.x)
            {
                case > 0:
                    MV = States.RunR;
                    break;
                case < 0:
                    MV = States.RunL;
                    break;
            }
        }
        else
        {
            switch (MV)
            {
                case States.RunF: case States.IdleF:
                    MV = States.IdleF;
                    break;
                case States.RunB: case States.IdleB:
                    MV = States.IdleB;
                    break;
                case States.RunL: case States.IdleL:
                    MV = States.IdleL;
                    break;
                case States.RunR: case States.IdleR:
                    MV = States.IdleR;
                    break;
                default:
                    MV = States.IdleF;
                    break;
            }
        }
        anim.SetInteger("Move", (int)MV);
        if ((int)MV % 2 != 1)
        {
            audioSource.Play();
        }
    }
}
