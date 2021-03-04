using UnityEngine;
using UnityEngine.Events;

public class WaveManager : MonoBehaviour
{
    public IntVariable asteroidsDestroyed;
    public IntVariable currentWave;
    public IntReference wavePoolIncrease;
    
    private int nextWave;
    private int currentWaveTarget;
    private int nextWaveTarget;

    [Space]
    public UnityEvent NextWave;

    void Start()
    {
        currentWave.SetValue(0);
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
            UpdateWave();
        }
    }

    public void UpdateWave()
    {
        int waveTarget = currentWaveTarget + nextWaveTarget;

        currentWave.ApplyChange(1);
        nextWave = currentWave.Value + 1;
        currentWaveTarget = waveTarget;
        nextWaveTarget = nextWave * wavePoolIncrease;
        NextWave.Invoke();
    }

}
