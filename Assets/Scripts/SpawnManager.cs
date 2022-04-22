using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    [SerializeField] float spawnPositionX;
    [SerializeField] float spawnPositionY;
    [SerializeField] float spawnPositionZ;
    [SerializeField] float respawnDelay = 1f;    
    // Start is called before the first frame update
   /* void Start()
    {
        InvokeRepeating("SpawnRandomEnemy", 0, respawnDelay);
    }

    void SpawnRandomEnemy()
    {
        Vector3 spawnPos = new Vector3(spawnPositionX, 9, Random.Range(-spawnPositionZ, spawnPositionZ));

        int enemyIndex = Random.Range(0, enemyPrefabs.Length);

        Instantiate(enemyPrefabs[enemyIndex], spawnPos, Quaternion.identity);      
    }*/


    
}
