using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu (menuName = "Object Data / Ability")]
public class AbilityType : ScriptableObject
{
    public string abilityName;
    public bool abilityIsActive;

    public GameObject abilityPrefab;

    public float abilityChargeTime;
    public float abilityCooldownTime;

    public Sprite abilityButtonImg;
    public Sprite abilityButtonCooldownImg;

    public GameEvent gameEvent;

    [HideInInspector] public Button abilityBtn;
}
