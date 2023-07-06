using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDashing : Player
{
  private float dashForce = 10.0f;
  public KeyCode dashKey;

  void Start()
  {
  }
  void Update()
  {
    direction = GetDirection();
    if (Input.GetKeyDown(dashKey))
    {
      Dash();
    }
  }

  void Dash()
  {
    UnityEngine.Debug.Log(GetDirection());
    UnityEngine.Debug.Log("Dashing right");
    rigidbody2D.AddForce(new Vector2(GetDirection(), 0) * dashForce, ForceMode2D.Impulse);
  }
}
