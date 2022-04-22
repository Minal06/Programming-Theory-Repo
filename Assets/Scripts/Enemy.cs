using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float spawnBoundry;

    
    // Update is called once per frame
    void Update()
    {
        SpawnCheck();
    }

    void SpawnCheck()
    {
        if (transform.position.x < spawnBoundry)
        {
            MoveRight();
        }
    }

    void MoveRight()
    {
        transform.Translate(Vector3.right * Time.deltaTime * speed);
    }

    void MoveLeft()
    {

    }
}
