using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameStart : MonoBehaviour
{
  public TextMeshProUGUI gameTitle;
  void Start()
  {
    Invoke("TurnOffTittle", 4.0f);
  }

  public void TurnOffTittle()
  {
    gameTitle.enabled = false;
  }
}
