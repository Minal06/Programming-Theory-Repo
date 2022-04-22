using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IPooledObjects
{
    [SerializeField] float speed;
    [SerializeField] float spawnBoundry;

    public void OnObjectSpawn()
    {
        SpawnCheck();
    }

    void SpawnCheck()
    {
        if (transform.position.x < spawnBoundry)
        {
            MoveRight();
        }       
        /*if (transform.position.x > -spawnBoundry)
        {
            MoveLeft();
        }*/
    }

    void MoveRight()
    {
        transform.Translate(Vector3.right * Time.deltaTime * speed);
    }

    void MoveLeft()
    {
        transform.Translate(Vector3.left * Time.deltaTime * speed);
    }
}
