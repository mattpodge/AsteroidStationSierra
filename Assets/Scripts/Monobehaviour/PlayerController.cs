using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    public GameObject gunEnd;
    public int selectedWeapon = 0;
    public List<LaserType> laserType;

    public List<AbilityType> abilities;

    private float fireDelay;

    private Animator playerAnim;

    void Start()
    {
        playerAnim = GetComponent<Animator>();
        playerAnim.StopPlayback();
        fireDelay = laserType[selectedWeapon].fireRate;
    }

    void Update()
    {
        for (int i = 0; i < Input.touchCount; i++)
        {
            // Ignore when we touch the UI
            if (!IsPointerOverUI(i))
            {
                Touch touch = Input.touches[i];
                Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);

                FireWeapon();

                if (Input.touches[i].phase == TouchPhase.Moved)
                {
                    RotateShip(touchPosition);
                }

            }
        }

        if (Input.touchCount > 0 && !IsPointerOverUI(0)) {
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

    public bool IsPointerOverUI(int fingerId)
    {
        EventSystem eventSystem = EventSystem.current;
        return (eventSystem.IsPointerOverGameObject(fingerId) && eventSystem.currentSelectedGameObject != null);
    }
}
