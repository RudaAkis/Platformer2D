using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
  public GameObject bulletPrefab;
  private float shotCooldown;
  private float reloadTime;
  [HideInInspector]
  public int magazineSize;
  [HideInInspector]
  public int bulletsLeftInMagazine;
  [HideInInspector]
  public int totalBulletsLeft;
  int shootingDirection;
  public Transform bulletSpawnPoint;
  public KeyCode shootKey;


  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {
    Shoot();
  }

  public void Shoot()
  {
    if (Input.GetKey(shootKey))
    {
      GameObject bullet = Instantiate(bulletPrefab, new Vector2(bulletSpawnPoint.position.x + 0.5f, bulletSpawnPoint.position.y), Quaternion.identity);
    }
  }
}
