using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AbilitiesManager : MonoBehaviour
{
    public AbilityType[] abilities;
    public GameObject buttonPrefab;

    void Start()
    {
        // Instantiate and update a button for each ability
        int i = 0;

        foreach (AbilityType ability in abilities)
        {
            int yPos = -100 - (i * 250);

            GameObject abilityButton = Instantiate(buttonPrefab);
            abilityButton.transform.SetParent(GameObject.Find("Canvas").GetComponent<RectTransform>(), false);
            abilityButton.transform.position += new Vector3(-100, yPos, 0);

            Button abilityBtn = abilityButton.GetComponent<Button>();

            Image btnImg = abilityButton.GetComponent<Image>();
            btnImg.sprite = ability.abilityButtonImg;

            Image cooldownImg = abilityButton.transform.Find("CooldownProg").GetComponent<Image>();
            cooldownImg.sprite = ability.abilityButtonCooldownImg;

            TextMeshProUGUI btnName = abilityButton.transform.Find("AbilityName").GetComponent<TextMeshProUGUI>();
            btnName.text = ability.abilityName;

            StartCoroutine(CoolDown(abilityBtn, cooldownImg, ability.abilityCooldownTime));

            abilityButton.GetComponent<Button>().onClick.AddListener(() => ability.gameEvent.Raise());

            i++;
        }
    }

    IEnumerator CoolDown(Button powerUpButton, Image coolDownImage, float cooldown)
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
