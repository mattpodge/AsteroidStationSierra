using UnityEngine;
using TMPro;

public class UICurrentWave : MonoBehaviour
{
    public IntReference currentWave;
    private int wave;
    private TextMeshProUGUI waveText;

    void Start()
    {
        waveText = GetComponent<TextMeshProUGUI>();
        wave = currentWave.Value;
    }

    public void UpdateWave()
    {
        waveText.text = "Wave: " + wave.ToString("D3");
    }
}
