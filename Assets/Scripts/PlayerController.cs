using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    private GameManager gameManager;

    [SerializeField] private GameObject laserFire;
    [SerializeField] private float laserFireRate = 1.0f;

    [SerializeField] private GameObject burstFire;
    [SerializeField] private float burstFireRate = 1.0f;


    [SerializeField] private GameObject gunSpawn;

    [SerializeField] ParticleSystem explosionEffect;

    private AudioSource playerAudio;
    [SerializeField] AudioClip laserSound;
    [SerializeField] AudioClip burstSound;
    [SerializeField] AudioClip explosionSound;

    private Animator playerAnim;


    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        playerAudio = GetComponent<AudioSource>();
        playerAnim = GetComponent<Animator>();

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

    }

    void ShipRotation(Vector3 inputPosition)
    {
        Vector3 lookDirection = transform.position - inputPosition;
        transform.rotation = Quaternion.LookRotation(Vector3.forward, lookDirection);
    }

    IEnumerator LaserFire()
    {
        while (gameManager.isGameActive)
        {
            while(!PowerUps.isBurstActive)
            {
                yield return new WaitForSeconds(laserFireRate);
                Instantiate(laserFire, gunSpawn.transform.position, transform.rotation);
                playerAudio.PlayOneShot(laserSound, 75.0f);
                playerAnim.speed = 1 / laserFireRate;
            }

            while (PowerUps.isBurstActive)
            {
                yield return new WaitForSeconds(burstFireRate);
                Instantiate(burstFire, gunSpawn.transform.position, transform.rotation);
                playerAudio.PlayOneShot(burstSound, 75.0f);
                playerAnim.speed = 1 / burstFireRate;

            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Asteroid"))
        {
            AudioSource.PlayClipAtPoint(explosionSound, gameObject.transform.position, 1.0f);
            Instantiate(explosionEffect, transform.position, transform.rotation);
            Destroy(gameObject);
            gameManager.GameOver();
        }
    }
}
