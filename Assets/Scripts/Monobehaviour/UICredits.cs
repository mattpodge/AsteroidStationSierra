using UnityEngine;

public class UICredits : MonoBehaviour
{
    public GameObject creditsUI;
    public void ShowCredits()
    {
        creditsUI.SetActive(true);
    }

    public void CloseCredits()
    {
        creditsUI.SetActive(false);
    }
}
