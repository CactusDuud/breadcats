using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public Transform creepParent;
    public Transform creepPrefab;
    public Transform spawnPoint;

    public float timeBetweenWaves = 10.0f;
    public float waveTimer {get; private set;} = 0;
    public float creepSpacingTime {get; private set;} = 0.2f;

    public int waveIndex {get; private set;} = 0;

    /// <summary> Update is called every frame, if the MonoBehaviour is enabled. </summary>
    private void Update()
    {
        if (waveTimer <= 0)
        {
            StartCoroutine(SpawnWave());
            waveTimer = timeBetweenWaves; 
        }

        waveTimer -= Time.deltaTime;
    }

    //TODO: Configurable AND/OR algorithmic waves
    IEnumerator SpawnWave()
    {
        Debug.Log($"{name}: Spawning wave {waveIndex}");
        waveIndex++;

        for (int i = 0; i < waveIndex; i++)
        {
            SpawnCreep();
            yield return new WaitForSeconds(creepSpacingTime);
        }
    }

    private void SpawnCreep()
    {
        Instantiate(creepPrefab, spawnPoint.position, spawnPoint.rotation, creepParent);
    }
}
