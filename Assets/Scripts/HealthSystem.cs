using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthSystem : MonoBehaviour
{
  private int numberOfShieldsAvailable = 4;
  private int numberOfHealthAvailable = 4;
  private int numberOfShieldsCurrent = 4;// The total number of shields allowed to be displayed
  private int numberOfHeartsCurrent = 4;// total number of hearts allowed to be displayed
  public TextMeshProUGUI gameOverText;

  //Stores all of the UI elements that represent health and shields**********************
  public Image[] healthHearts;
  public Image[] shieldHearts;
  //Sprite that contain different heart images******************************************
  public Sprite emptyHealthHeart;
  public Sprite fullHealthHeart;
  public Sprite fullShieldHeart;
  // ******************** Unity Built in methods****************************************
  void Start()
  {
    gameOverText.enabled = false;
  }
  void Update()
  {
    HealthCounterUpadate(healthHearts, numberOfHeartsCurrent, numberOfHealthAvailable);
    HealthCounterUpadate(shieldHearts, numberOfShieldsCurrent, numberOfShieldsAvailable);
  }
  // ******************************* Setter & Getters **********************************
  // ******************************* User Created methods ************************************
  public void TakeDamage(int damage)
  {
    if (numberOfShieldsCurrent > 0) { numberOfShieldsCurrent -= damage; }
    else { numberOfHeartsCurrent -= damage; }
    GameOver();
  }
  public void GameOver()
  {
    if (numberOfHeartsCurrent == 0)
    {
      gameOverText.enabled = true;
    }
  }
  public void HealthCounterUpadate(Image[] arrayToCheck, int numberToDisplay, int canBeDisplayed)
  {
    for (int i = 0; i < arrayToCheck.Length; i++)
    {
      if (i < numberToDisplay) { arrayToCheck[i].enabled = true; }
      else if (i < canBeDisplayed) { arrayToCheck[i].sprite = emptyHealthHeart; }
      else { arrayToCheck[i].enabled = false; }
    }
  }
  // **************************** Collision & Trigger methods
  void OnTriggerEnter2D(Collider2D other)
  {
    if (other.gameObject.tag == "Enemy")
    {
      TakeDamage(1);
    }
  }
}
