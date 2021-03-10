using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public BoolVariable isGameActive;
    public GameObject gameOverScreen;

    private void Start()
    {
        isGameActive.SetValue(true);
    }

    public void OnGameOver()
    {
        StartCoroutine(QuickDelay(1f));
        isGameActive.SetValue(false);
    }

    IEnumerator QuickDelay(float time)
    {
        yield return new WaitForSeconds(time);
        gameOverScreen.SetActive(true);
    }
}
