using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIStartGame : MonoBehaviour
{
    private Button button;

    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(StartGame);
    }

    private void StartGame()
    {
        SceneManager.LoadScene("GameScreen", LoadSceneMode.Single);
    }
}
