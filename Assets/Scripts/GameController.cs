using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private SpikeSpawner[] spikeSpawners;
    private int currentSpawn = 0;

    public void CollisionWithWall()
    {
        UpdateSpikes();
    }

    private void UpdateSpikes()
    {
        spikeSpawners[currentSpawn].ActivateAll();

        // 상태를 반대로 스위치할때 나머지를 많이 쓴다.
        currentSpawn = (currentSpawn+1) % spikeSpawners.Length;

        spikeSpawners[currentSpawn].DeactivateAll();
    }
}
