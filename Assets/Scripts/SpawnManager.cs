using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{    
    [SerializeField] float spawnPositionX;
    [SerializeField] float spawnPositionY;
    [SerializeField] float spawnPositionZ;
    [SerializeField] float respawnDelay = 1f;

    ObjectPoolManager objectPoolManager;

    private void Start()
    {
        objectPoolManager = ObjectPoolManager.SharedInstance;

        InvokeRepeating("SpawnEnemy", 0, respawnDelay);
    }

    /*private void FixedUpdate()
    {
        objectPoolManager.SpawnFromPool("Normal", transform.position, Quaternion.identity);
    }*/

    void SpawnEnemy()
    {
        Vector3 spawnPos = new Vector3(spawnPositionX, spawnPositionY, Random.Range(-spawnPositionZ, spawnPositionZ));

        objectPoolManager.SpawnFromPool("Normal", spawnPos, Quaternion.identity);
    }


}
