using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerActionController : MonoBehaviour
{
  public bool ActionOnCooldown;
  public float ActionCooldown;
  public int direction;
  void Start()
  {

  }

  void Update()
  {
  }

  void DoUpdate() { }
  void DoStart() { }

  void ActivateAction()
  {

  }
  public void SetDirection(int direction)
  {
    this.direction = direction;
  }
  public int GetDirection()
  {
    return direction;
  }
}
