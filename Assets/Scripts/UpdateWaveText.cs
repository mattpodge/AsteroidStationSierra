using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpdateWaveText : MonoBehaviour
{
    private TextMeshProUGUI waveText;
    public IntVariable currentWave;

    // Start is called before the first frame update
    void Start()
    {
        waveText = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    public void UpdateWave()
    {
        waveText.text = "Wave: " + currentWave.Value.ToString("D3");
    }
}
