using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AbilitiesManager : MonoBehaviour
{
    public AbilityType[] abilities;
    public GameObject buttonPrefab;
    public BoolVariable isGameActive;

    void Start()
    {
        // Instantiate and update a button for each ability
        int i = 0;

        foreach (AbilityType ability in abilities)
        {

            ability.abilityIsActive = false;

            int yPos = -100 - (i * 250);

            GameObject abilityButton = Instantiate(buttonPrefab);
            abilityButton.transform.name = ability.abilityName + "Button";
            abilityButton.transform.SetParent(GameObject.Find("Canvas").GetComponent<RectTransform>(), false);
            abilityButton.transform.position += new Vector3(-100, yPos, 0);

            Button abilityBtn = abilityButton.GetComponent<Button>();
            ability.abilityBtn = abilityBtn;

            Image btnImg = abilityButton.GetComponent<Image>();
            btnImg.sprite = ability.abilityButtonImg;

            Image cooldownImg = abilityButton.transform.Find("CooldownProg").GetComponent<Image>();
            cooldownImg.sprite = ability.abilityButtonCooldownImg;

            TextMeshProUGUI btnName = abilityButton.transform.Find("AbilityName").GetComponent<TextMeshProUGUI>();
            btnName.text = ability.abilityName;

            StartCoroutine(AbilityCharge(ability));

            ability.gameEvent.sentInt = i;

            abilityButton.GetComponent<Button>().onClick.AddListener(() => ability.gameEvent.Raise());

            i++;
        }
    }

    public void ActivateAbility(int abIndex)
    {
        AbilityType ability = abilities[abIndex];
        ability.abilityIsActive = true;
        StartCoroutine(AbilityCooldown(ability));
    }

    IEnumerator AbilityCooldown(AbilityType ability)
    {
        Image progressImg = ability.abilityBtn.transform.Find("CooldownProg").GetComponent<Image>();

        float timeLeft = 1f;
        progressImg.fillAmount = 1;
        ability.abilityBtn.interactable = false;

        while (timeLeft > 0)
        {
            progressImg.fillAmount = timeLeft;
            timeLeft -= (Time.deltaTime / ability.abilityCooldownTime);
            yield return null;
        }

        progressImg.fillAmount = 0;
        ability.abilityIsActive = false;

        StartCoroutine(AbilityCharge(ability));
    }

    IEnumerator AbilityCharge(AbilityType ability)
    {
        Image progressImg = ability.abilityBtn.transform.Find("CooldownProg").GetComponent<Image>();

        float timeLeft = 0;
        progressImg.fillAmount = 0;

        while (timeLeft < 1f)
        {
            progressImg.fillAmount = timeLeft;
            timeLeft +=  (Time.deltaTime / ability.abilityChargeTime);
            yield return null;
        }

        ability.abilityBtn.interactable = true;
        progressImg.fillAmount = 1;
    }

}
