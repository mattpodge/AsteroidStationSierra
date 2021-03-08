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
        gameOverScreen.SetActive(true);
        isGameActive.SetValue(false);
    }
}
