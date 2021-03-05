using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilitiesManager : MonoBehaviour
{
    public static bool isShieldActive;
    public Button shieldButton;
    public int shieldCooldown = 15;
    public Image shieldCooldownImg;
    public GameObject shieldPowerUp;

    private AudioSource shieldAudio;
    public AudioClip shieldStartUp;

    public static bool isBurstActive;
    public Button burstButton;
    public int burstCooldown = 30;
    public Image burstCooldownImg;

    // Start is called before the first frame update
    void Start()
    {

        shieldAudio = shieldPowerUp.GetComponent<AudioSource>();

        shieldButton.onClick.AddListener(ActivateShield);
        burstButton.onClick.AddListener(ActivateBurstFire);

        StartCoroutine(CoolDown(shieldButton, shieldCooldownImg, shieldCooldown));
        StartCoroutine(CoolDown(burstButton, burstCooldownImg, burstCooldown));
    }

    // Update is called once per frame
    void FixedUpdate()
    {
            if (isShieldActive)
            {
                shieldPowerUp.SetActive(true);
            }
            else
            {
                shieldPowerUp.SetActive(false);
            }
    }

    public void ActivateShield()
    {
        isShieldActive = true;
        AudioSource.PlayClipAtPoint(shieldStartUp, Vector3.zero, 1.0f);
        StartCoroutine(CoolDown(shieldButton, shieldCooldownImg, shieldCooldown));
    }

    public void ActivateBurstFire()
    {
        StartCoroutine(BurstFire());
    }

    IEnumerator BurstFire()
    {
        isBurstActive = true;

        float timeLeft = 1f;
        burstCooldownImg.fillAmount = 1;
        
        while (timeLeft > 0f)
        {
            burstCooldownImg.fillAmount = timeLeft;
            timeLeft -= Time.deltaTime / 10;
            yield return null;
        }

        burstCooldownImg.fillAmount = 0;
        isBurstActive = false;
        StartCoroutine(CoolDown(burstButton, burstCooldownImg, burstCooldown));
    }

    IEnumerator CoolDown(Button powerUpButton, Image coolDownImage, int cooldown)
    {
        float timeLeft = 0;
        coolDownImage.fillAmount = 0;
        powerUpButton.interactable = false;

        while (timeLeft < 1f)
        {
            coolDownImage.fillAmount = timeLeft;
            timeLeft +=  (Time.deltaTime / cooldown);
            yield return null;
        }

        powerUpButton.interactable = true;
        coolDownImage.fillAmount = 1;

    }
}
