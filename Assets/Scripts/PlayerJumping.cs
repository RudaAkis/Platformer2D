using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumping : Player
{
  public float jumpForce;// The force with which the player is propeled to the Vector2.up
  public bool isGrounded;// True if the player is touching the ground layer from which it can jump
  public LayerMask JumpGround;// Layer from which the player is able to perform a jump
  public Transform feetPosition; //Position from which the groun checking is done
  public float GroundCheckRadius; //Radius of the circle which will check if it is colliding with the ground layer around the feetPosition
  public float JumpTime;// The amount of time player can keep rising whiel holding the jump button
  public float JumpTimeCounter;// Counter of the time the player is able to keep jumping that is reset at every jump
  bool isJumping;
  void Start()
  {
  }

  void Update()
  {
    isGrounded = GroundCheck();// Assign the value true false by performing overlap circle funtion
    if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
    {
      isJumping = true;
      JumpTimeCounter = JumpTime;
      Jump();
    }
    if (Input.GetKey(KeyCode.Space) && isJumping)
    {
      if (JumpTimeCounter > 0)
      {
        rigidbody2D.AddForce(Vector2.up * (jumpForce - 1.0f), ForceMode2D.Force);
        JumpTimeCounter -= Time.deltaTime;
      }
      else
      {
        JumpTimeCounter = -0.1f;
        isJumping = false;
      }
    }
    if (Input.GetKeyUp(KeyCode.Space))
    {
      isJumping = false;
    }
  }

  void Jump()
  {
    rigidbody2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
  }

  bool GroundCheck()
  {
    return Physics2D.OverlapCircle(feetPosition.position, GroundCheckRadius, JumpGround);
  }
}
