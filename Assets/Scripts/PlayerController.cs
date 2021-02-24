using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private GameManager gameManager;

    [SerializeField] private GameObject laserBolt;
    [SerializeField] private float fireRate = 0.5f;
    [SerializeField] private GameObject laserSpawn;

    [SerializeField] ParticleSystem explosionEffect;

    private AudioSource playerAudio;
    [SerializeField] AudioClip pewPew;

    [SerializeField] private GameObject shield;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        playerAudio = gameObject.GetComponent<AudioSource>();
    }

    void Awake()
    {
        StartCoroutine(LaserFire());
    }

    void Update()
    {

        for (int i = 0; i < Input.touchCount; i++)
        {

            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(Input.touches[i].position);

            if (i == 0)
            {
                ShipRotation(touchPosition);
            }
        }

        if (gameManager.shieldActive)
        {
            shield.SetActive(true);
        }
        else
        {
            shield.SetActive(false);
        }

    }

    void ShipRotation(Vector3 inputPosition)
    {
        Vector3 lookDirection = transform.position - inputPosition;
        transform.rotation = Quaternion.LookRotation(Vector3.forward, lookDirection);
    }

    IEnumerator LaserFire()
    {
        while(true)
        {
            yield return new WaitForSeconds(fireRate);
            Instantiate(laserBolt, laserSpawn.transform.position, transform.rotation);
            playerAudio.PlayOneShot(pewPew, fireRate);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Asteroid"))
        {
            Destroy(gameObject);
            Instantiate(explosionEffect, transform.position, transform.rotation);
            gameManager.GameOver();
        }
    }
}
