using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoving : Player
{
  PlayerInput playerInput;
  private float moveSpeedLow = 2.0f;//Beggining move speed
  private float acceleration = 0.1f;
  private float decceleration = 0.1f;
  public float currentSpeed = 0;
  private float maxSpeed = 5.5f;
  int currentDirection = 1;

  void Start()
  {
    currentSpeed = moveSpeedLow;
    playerInput = GetComponent<PlayerInput>();
  }
  void Update()
  {
    if (playerInput.HorizontalInput > 0) { SetDirection(1); FlipPlayer(currentDirection, GetDirection()); Move(); }
    else if (playerInput.HorizontalInput < 0) { SetDirection(-1); FlipPlayer(currentDirection, GetDirection()); Move(); }
    else { Stop(); }
    currentDirection = GetDirection();
    UnityEngine.Debug.Log("Current direction: " + currentDirection);
  }
  // Move the object to either direction
  public void Move()
  {
    currentSpeed = currentSpeed + acceleration;
    if (currentSpeed >= maxSpeed) { currentSpeed = maxSpeed; }
    rigidbody2D.velocity = new Vector2((GetDirection() * currentSpeed), rigidbody2D.velocity.y);
  }
  //Deaccelerate the object to either direction
  public void Stop()
  {
    currentSpeed = moveSpeedLow;
    if (rigidbody2D.velocity.x > 0.2)
    {
      rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x - decceleration, rigidbody2D.velocity.y);
    }
    else if (rigidbody2D.velocity.x < -0.2)
    {
      rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x + decceleration, rigidbody2D.velocity.y);
    }
    else
    {
      rigidbody2D.velocity = new Vector2(0, rigidbody2D.velocity.y);
    }
  }




}
