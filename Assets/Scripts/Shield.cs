using UnityEngine;

public class Shield : MonoBehaviour
{

    private void Update()
    {
        transform.Rotate(Vector3.forward, 360.0f * 1f * Time.deltaTime);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Asteroid"))
        {
            gameObject.SetActive(false);
        }
    }
}
