using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool isTouching;
    public GameObject gunEnd;
    public List<LaserType> laserType;
    public int selectedWeapon = 0;
    private float fireDelay;

    private Animator playerAnim;

    void Start()
    {
        playerAnim = GetComponent<Animator>();
        playerAnim.StopPlayback();
        fireDelay = laserType[selectedWeapon].fireRate;
    }

    void FixedUpdate()
    {
        for (int i = 0; i < Input.touchCount; i++)
        {
            Touch touch = Input.touches[i];
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);

            if (i == 0)
            {
                RotateShip(touchPosition);
                FireWeapon();
            }
        }

        if (Input.touchCount != 0) {
            playerAnim.SetBool("isFiring", true);
        } else
        {
            playerAnim.SetBool("isFiring", false);
        }
    }

    void RotateShip(Vector3 inputPosition)
    {
        Vector3 lookDirection = transform.position - inputPosition;
        transform.rotation = Quaternion.LookRotation(Vector3.forward, lookDirection);
    }

    void FireWeapon()
    {
        
        fireDelay -= Time.deltaTime;
        if(fireDelay <= 0f)
        {
            playerAnim.speed = 1 / laserType[selectedWeapon].fireRate;
            Instantiate(laserType[selectedWeapon].projectile, gunEnd.transform.position, transform.rotation);
            fireDelay = laserType[selectedWeapon].fireRate;
        }
    }
}
