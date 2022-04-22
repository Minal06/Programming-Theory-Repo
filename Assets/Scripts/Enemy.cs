using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float spawnBoundry;

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
        else if (transform.position.x > spawnBoundry)
        {
            gameObject.SetActive(false);
        }
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
