using UnityEngine;

public class Shield : MonoBehaviour
{
    private AudioSource shieldAudio;
    public AudioClip shieldSfx;

    private void Start()
    {
        shieldAudio = GetComponent<AudioSource>();
        shieldAudio.PlayOneShot(shieldSfx, 1.0f);
    }

    private void Update()
    {
        transform.Rotate(Vector3.forward, 90f * 1.0f * Time.deltaTime);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Asteroid"))
        {
            gameObject.SetActive(false);
        }
    }
}
