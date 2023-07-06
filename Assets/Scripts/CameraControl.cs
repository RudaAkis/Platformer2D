using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
  public GameObject Player;
  Vector3 desiredPosition;
  public float smoothness = 0.5f;
  public float offsetX = 0.5f;
  public float offsetY = 0.3f;

  void LateUpdate()
  {
    desiredPosition = (new Vector3(Player.transform.position.x + offsetX, Player.transform.position.y + offsetY, -1.0f));
    transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothness * Time.deltaTime);
  }
}
