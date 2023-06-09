using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeSpawner : MonoBehaviour
{
    [SerializeField]
    private Spike[]     spikes;
    [SerializeField]
    private float       activateX;
    [SerializeField]
    private float       deactivateX;

    public void ActivateAll()
    {
        // 등장하는 가시의 개수
        int count = Random.Range(1, spikes.Length);

        // 등장하는 가시의 순번
        int[] numerics = RandomNumerics(spikes.Length, count);

        for (int i = 0; i < numerics.Length; i++)
        {
            spikes[numerics[i]].OnMove(activateX);
        }
    }

    public void DeactivateAll()
    {
        for (int i = 0; i < spikes.Length; i++)
        {
            spikes[i].OnMove(deactivateX);
        }
    }

    private int[] RandomNumerics(int maxCount, int n)
    {
        int[] defaults  = new int[maxCount];
        int[] results   = new int[n];

        for (int i = 0; i < defaults.Length; i++)
        {
            defaults[i] = i;
        }

        for (int i = 0; i < n; i++)
        {
            int index = Random.Range(0, maxCount);

            results[i] = defaults[index];
            defaults[index] = defaults[maxCount - 1];

            maxCount --;
        }

        return results;
    }
}
