using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{    
    [SerializeField] float spawnPositionX;
    [SerializeField] float spawnPositionY;
    [SerializeField] float spawnPositionZ;
    [SerializeField] float spawnSpaceResize;
    [SerializeField] float respawnDelay;

    ObjectPoolManager objectPoolManager;

    private void Start()
    {
        objectPoolManager = ObjectPoolManager.SharedInstance;
        SpawnEnemies();
        
    }
    
    void SpawnEnemies()
    {
        InvokeRepeating("SpawnEnemyNormal", 0, respawnDelay);
        InvokeRepeating("SpawnEnemyBig", 0, respawnDelay);
        InvokeRepeating("SpawnEnemyFastLeft", 0, respawnDelay);
        InvokeRepeating("SpawnEnemyFastRight", 0, respawnDelay);
    }

    void SpawnEnemyNormal()
    {
        Vector3 spawnPos = new Vector3(-spawnPositionX, spawnPositionY, Random.Range(-spawnPositionZ, spawnPositionZ));

        objectPoolManager.SpawnFromPool("Normal", spawnPos, Quaternion.identity);        
    }

    void SpawnEnemyBig()
    {
        Vector3 spawnPos = new Vector3(spawnPositionX, spawnPositionY, Random.Range(-spawnPositionZ, spawnPositionZ));

        objectPoolManager.SpawnFromPool("Big", spawnPos, Quaternion.identity);
    }

    void SpawnEnemyFastLeft()
    {
        Vector3 spawnPos = new Vector3(-spawnPositionX, spawnPositionY, Random.Range(spawnPositionZ, (spawnPositionZ+spawnSpaceResize)));

        objectPoolManager.SpawnFromPool("Fast", spawnPos, Quaternion.identity);
    }

    void SpawnEnemyFastRight()
    {
        Vector3 spawnPos = new Vector3(spawnPositionX, spawnPositionY, Random.Range(spawnPositionZ, (spawnPositionZ+spawnSpaceResize)));

        objectPoolManager.SpawnFromPool("FastR", spawnPos, Quaternion.identity);
    }


}
