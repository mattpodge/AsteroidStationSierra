using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class WaveManager : MonoBehaviour
{
    public IntVariable asteroidsDestroyed;
    public IntVariable currentWave;
    public IntReference wavePoolIncrease;
    public TextMeshProUGUI waveText;

    private int nextWave;
    private int currentWaveTarget;
    private int nextWaveTarget;

    [Space]
    public UnityEvent NextWave;

    void Start()
    {
        currentWave.SetValue(0);
        asteroidsDestroyed.SetValue(0);

        nextWave = currentWave.Value + 1;
        currentWaveTarget = currentWave.Value * wavePoolIncrease;
        nextWaveTarget = nextWave * wavePoolIncrease;
    }

    public void CountAsteroidsDestroyed()
    {
        asteroidsDestroyed.ApplyChange(1);

        int waveTarget = currentWaveTarget + nextWaveTarget;

        if (asteroidsDestroyed.Value == waveTarget)
        {
            NextWave.Invoke();
        }
    }

    public void UpdateWave()
    {
        int waveTarget = currentWaveTarget + nextWaveTarget;

        currentWave.ApplyChange(1);
        if (waveText != null)
        {
            waveText.text = "Wave: " + currentWave.Value.ToString("D3");
        }
        nextWave = currentWave.Value + 1;
        currentWaveTarget = waveTarget;
        nextWaveTarget = nextWave * wavePoolIncrease;
    }

}
