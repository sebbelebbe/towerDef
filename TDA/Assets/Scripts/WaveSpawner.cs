
using UnityEngine;
using System.Collections;

public class WaveSpawner : MonoBehaviour
{
    public Transform spawPoint;
    public Transform enemyPrefab;
    public float timeBetweenWaves = 5f;
    private float countdown = 2f;
    private int waveNumber = 0;




    void Update()
    {
        if (countdown <= 0)
        {
            StartCoroutine(spawnWave());
            countdown = timeBetweenWaves;
        }
        countdown -= Time.deltaTime;

    }

     IEnumerator spawnWave()
    {
        waveNumber++;
        for (int i = 0; i < waveNumber; i++)
        {
            spawnEnemy();
            yield return new WaitForSeconds(0.5f);
        
        }
        

    }

    void spawnEnemy()
    {
        Instantiate(enemyPrefab, spawPoint.position, spawPoint.rotation);

    }


}