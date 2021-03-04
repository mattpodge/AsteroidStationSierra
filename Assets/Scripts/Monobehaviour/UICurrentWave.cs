using UnityEngine;
using TMPro;

public class UICurrentWave : MonoBehaviour
{
    public IntReference currentWave;
    private TextMeshProUGUI waveText;

    void Start()
    {
        waveText = GetComponent<TextMeshProUGUI>();
    }

    public void UpdateWave()
    {
        waveText.text = "Wave: " + currentWave.Value.ToString("D3");
    }
}
