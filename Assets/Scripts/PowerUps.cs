using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUps : MonoBehaviour
{
    private GameManager gm;
    private PlayerController pc;

    public static bool isShieldActive;
    public Button shieldButton;
    public int shieldCooldown = 15;
    public Image shieldCooldownImg;
    public GameObject shieldPowerUp;

    public static bool isBurstActive;
    public Button burstButton;
    public int burstCooldown = 30;
    public Image burstCooldownImg;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        pc = GameObject.Find("Player").GetComponent<PlayerController>();

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
        powerUpButton.enabled = false;

        while (timeLeft < 1f && gm.isGameActive)
        {
            coolDownImage.fillAmount = timeLeft;
            timeLeft +=  (Time.deltaTime / cooldown);
            yield return null;
        }

        powerUpButton.enabled = true;
        coolDownImage.fillAmount = 1;

    }
}
