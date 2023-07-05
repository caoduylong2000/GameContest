using Assets.Script.Base;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : BaseMovement
{
    private void Update()
    {
        Move();
    }
    protected override void Move()
    {
        base.Move();
        float moveX = Input.GetAxis("Horizontal");

        // Move the player horizontally
        Rigidbody2D.velocity = new Vector2(moveX * MoveSpeed, Rigidbody2D.velocity.y);
    }
}
