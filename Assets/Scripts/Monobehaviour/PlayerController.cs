using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    public GameObject gunEnd;
    public GameObject shield;

    public List<AbilityType> abilities;
    public List<LaserType> weapons;
    private int selectedWeapon;

    private float fireDelay;

    private Animator playerAnim;
    private AudioSource playerAudio;

    public GameObject explosionEffect;
    public AudioClip explosionSfx;
    public GameEvent gameOver;

    void Start()
    {
        playerAnim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        fireDelay = weapons[selectedWeapon].projectileDelay;
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

        foreach (AbilityType ability in abilities)
        {
            if (!ability.abilityIsActive && ability.abilityName == "Shield")
            {
                shield.SetActive(false);
            }

            if (ability.abilityIsActive && ability.abilityName == "Burst")
            {
                selectedWeapon = 1;
            } else
            {
                selectedWeapon = 0;
            }
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
            playerAnim.speed = 1 / weapons[selectedWeapon].projectileDelay;
            playerAudio.PlayOneShot(weapons[selectedWeapon].soundFx, 1.0f);
            Instantiate(weapons[selectedWeapon].abilityPrefab, gunEnd.transform.position, transform.rotation);
            fireDelay = weapons[selectedWeapon].projectileDelay;
        }
    }

    public bool IsPointerOverUI(int fingerId)
    {
        EventSystem eventSystem = EventSystem.current;
        return (eventSystem.IsPointerOverGameObject(fingerId) && eventSystem.currentSelectedGameObject != null);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Asteroid"))
        {
            gameObject.SetActive(false);
            AudioSource.PlayClipAtPoint(explosionSfx, transform.position, 1.0f);
            Instantiate(explosionEffect, transform.position, transform.rotation);
            gameOver.Raise();
        }
    }
}
