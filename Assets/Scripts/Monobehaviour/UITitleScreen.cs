using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UITitleScreen : MonoBehaviour
{
    private Button button;

    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(TitleScreen);
    }

    public void TitleScreen()
    {
        SceneManager.LoadScene(0);
    }
}
