using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
  [HideInInspector]
  public static PlayerInput playerInput;
  public static Rigidbody2D rigidbody2D;
  public enum PlayerState
  {
    IDLE,
    MOVING,
    INAIR,
    JUMPING,
    ATTACKING,
    DASHING,
    INTERACTING
  }
  PlayerState currentState;
  public static int direction;

  public void Awake()
  {
    playerInput = GetComponent<PlayerInput>();
    rigidbody2D = GetComponent<Rigidbody2D>();
  }

  void Start()
  {
    currentState = PlayerState.IDLE;
  }

  void Update()
  {
    if (playerInput.HorizontalInput != 0)
    {
      currentState = PlayerState.MOVING;

    }
  }
  public static void SetDirection(int direction)
  {
    Player.direction = direction;
  }
  public static int GetDirection()
  {
    return direction;
  }

  public void FlipPlayer(int currentDirection, int newDirection)
  {
    if (currentDirection != newDirection)
    {
      UnityEngine.Debug.Log("Current direction: " + currentDirection);
      UnityEngine.Debug.Log("New direction: " + newDirection);
      transform.Rotate(0.0f, 180.0f, 0.0f);
    }
  }

}
